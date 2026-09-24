using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class PayrollBLL
    {
        private readonly PayrollDAL _payrollDAL = new PayrollDAL();

        public async Task<List<PayrollDTO>> GetVisiblePayrollsAsync(int? employeeIdFilter = null)
        {
            // Employee: chỉ xem lương của chính mình, bất kể filter truyền vào
            if (SessionManager.IsEmployee)
            {
                var myId = SessionManager.CurrentAccount?.EmployeeId ?? 0;
                return await _payrollDAL.GetByEmployeeAsync(myId);
            }

            // Admin/Manager: xem theo employeeIdFilter nếu có
            if (employeeIdFilter.HasValue)
                return await _payrollDAL.GetByEmployeeAsync(employeeIdFilter.Value);

            // Nếu Admin nhưng không lọc -> trả về list trống (vì Payrolls thường được lọc theo tháng/năm ở FrmPayroll)
            return new List<PayrollDTO>();
        }

        public async Task<List<PayrollDTO>> GetPayrollsByMonthYearAsync(int month, int year)
        {
            return await _payrollDAL.GetByMonthYearAsync(month, year);
        }

        public async Task<List<PayrollDTO>> TinhLuongThangAsync(int month, int year)
        {
            if (!SessionManager.IsAdmin) throw new Exception("Chỉ Admin/Quản lý mới được tính lương.");

            var client = SupabaseClientManager.Instance.GetClient();
            var empResponse = await client.From<EmployeeDTO>().Where(x => x.Status == "Active").Get();
            var employees = empResponse.Models;

            var posResponse = await client.From<PositionDTO>().Get();
            var positions = posResponse.Models;

            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var ccResponse = await client.From<AttendanceDTO>()
                .Filter("work_date", Constants.Operator.GreaterThanOrEqual, startDate.ToString("yyyy-MM-dd"))
                .Filter("work_date", Constants.Operator.LessThanOrEqual, endDate.ToString("yyyy-MM-dd"))
                .Get();
            var attendances = ccResponse.Models;

            var leaveResponse = await client.From<LeaveRequestDTO>()
                .Where(x => x.Status == "Approved")
                .Get();
            var leaveRequests = leaveResponse.Models;

            var payrolls = new List<PayrollDTO>();

            foreach (var emp in employees)
            {
                var empAttendances = attendances.Where(x => x.EmployeeId == emp.EmployeeId && x.CheckIn.HasValue && x.CheckOut.HasValue).ToList();
                
                // 1. Tính tổng số giờ ca chính & tổng số giờ OT trong tháng
                decimal totalStandardHours = 0;
                decimal totalOTHours = 0;
                foreach (var att in empAttendances)
                {
                    if (att.CheckIn.HasValue && att.CheckOut.HasValue)
                    {
                        var (wHrs, otHrs) = AttendanceBLL.CalculateWorkAndOTHours(att.CheckIn.Value, att.CheckOut.Value);
                        totalStandardHours += wHrs;
                        totalOTHours += otHrs;
                    }
                }

                // Quy đổi ra số ngày công ca chính (1 ngày chuẩn = 8 giờ)
                decimal workingDays = totalStandardHours / 8m;

                var empLeaves = leaveRequests.Where(x => x.EmployeeId == emp.EmployeeId).ToList();
                int leaveDays = 0;
                foreach (var don in empLeaves)
                {
                    leaveDays += GetValidLeaveDays(don.StartDate, don.EndDate, month, year);
                }

                decimal baseSalary = emp.BaseSalary;
                if (baseSalary == 0 && emp.PositionId.HasValue)
                {
                    var pos = positions.FirstOrDefault(p => p.PositionId == emp.PositionId.Value);
                    if (pos != null) baseSalary = pos.BaseSalary;
                }

                // Lương 1 giờ chuẩn = Lương cơ bản tháng / 176 giờ chuẩn (22 ngày x 8h/ngày)
                decimal hourlyRate = baseSalary > 0 ? (baseSalary / 176m) : 0;

                // Lương ca chính
                decimal basePay = workingDays * (baseSalary > 0 ? baseSalary / 22m : 0);

                // Lương OT (tính hệ số 150% = x1.5 tiền lương giờ)
                decimal otPay = totalOTHours * hourlyRate * 1.5m;

                // Thưởng chuyên cần 500.000đ nếu làm đủ >= 22 ngày công
                decimal bonus = (workingDays + leaveDays) >= 22m ? 500000m : 0m;

                // Khấu trừ Bảo hiểm Xã hội (10.5% Lương cơ bản)
                decimal deduction = baseSalary * 0.105m;

                // Thực lĩnh = Lương ca chính + Lương OT + Thưởng - Khấu trừ Bảo hiểm
                decimal netSalary = Math.Max(0, basePay + otPay + bonus - deduction);

                payrolls.Add(new PayrollDTO
                {
                    EmployeeId = emp.EmployeeId,
                    Month = month,
                    Year = year,
                    WorkingDays = Math.Round(workingDays, 1),
                    LeaveDays = leaveDays,
                    BaseSalary = baseSalary,
                    Bonus = Math.Round(bonus + otPay, 0), // Cộng phụ cấp OT vào Bonus để hiển thị
                    Deduction = Math.Round(deduction, 0),
                    NetSalary = Math.Round(netSalary, 0),
                    HoTen = emp.FullName 
                });
            }
            return payrolls;
        }

        private int GetValidLeaveDays(DateTime tuNgay, DateTime denNgay, int targetMonth, int targetYear)
        {
            int days = 0;
            DateTime start = tuNgay < new DateTime(targetYear, targetMonth, 1) ? new DateTime(targetYear, targetMonth, 1) : tuNgay;
            int daysInMonth = DateTime.DaysInMonth(targetYear, targetMonth);
            DateTime end = denNgay > new DateTime(targetYear, targetMonth, daysInMonth) ? new DateTime(targetYear, targetMonth, daysInMonth) : denNgay;

            if (start > end) return 0; // Không nằm trong tháng này

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                // Bỏ qua Chủ nhật (không trừ ngày phép của nhân viên vào Chủ nhật)
                if (date.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
            }
            return days;
        }

        public async Task<(bool Success, string Message)> ExportToExcelAsync(List<PayrollDTO> data, string filePath)
        {
            try
            {
                var employees = await SupabaseClientManager.Instance.GetClient().From<EmployeeDTO>().Get();
                var empList = employees.Models;

                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var sheet = workbook.Worksheets.Add("Bảng Lương");

                    string[] headers = { "Mã NV", "Họ Tên", "Tháng/Năm", "Ngày Công", "Ngày Phép", "Lương Cơ Bản", "Phụ Cấp/Thưởng", "Khấu Trừ", "Thực Lĩnh" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        sheet.Cell(1, i + 1).Value = headers[i];
                        sheet.Cell(1, i + 1).Style.Font.Bold = true;
                        sheet.Cell(1, i + 1).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
                        sheet.Cell(1, i + 1).Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                    }

                    int row = 2;
                    foreach (var item in data)
                    {
                        var emp = empList.FirstOrDefault(x => x.EmployeeId == item.EmployeeId);

                        sheet.Cell(row, 1).Value = emp?.EmployeeCode ?? item.EmployeeId.ToString();
                        sheet.Cell(row, 2).Value = emp?.FullName ?? "";
                        sheet.Cell(row, 3).Value = $"{item.Month}/{item.Year}";
                        
                        sheet.Cell(row, 4).Value = item.WorkingDays;
                        sheet.Cell(row, 5).Value = item.LeaveDays;
                        
                        sheet.Cell(row, 6).Value = item.BaseSalary;
                        sheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0";
                        
                        sheet.Cell(row, 7).Value = item.Bonus;
                        sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0";
                        
                        sheet.Cell(row, 8).Value = item.Deduction;
                        sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0";

                        sheet.Cell(row, 9).Value = item.NetSalary;
                        sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0";
                        
                        for (int c = 1; c <= 9; c++)
                        {
                            sheet.Cell(row, c).Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                        }
                        row++;
                    }

                    sheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }

                return (true, "Xuất file Excel thành công!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    
        public async Task<List<PayrollDTO>> GetAllAsync() => new List<PayrollDTO>();
        public async Task<List<PayrollDTO>> GetByMonthAsync(int month, int year) => new List<PayrollDTO>();
        public async Task<List<PayrollDTO>> GetByEmployeeAsync(string id) => new List<PayrollDTO>();
        public async Task<PayrollDTO?> TinhLuongNhanVienAsync(string id, int m, int y) => null;
        public async Task<PayrollDTO?> LayBangLuongThangAsync(string id, int month, int year) => null;

        public async Task<(bool Success, string Message)> LuuBangLuongAsync(List<PayrollDTO> payrolls)
        {
            if (!payrolls.Any()) return (false, "Không có dữ liệu.");
            try
            {
                int month = payrolls.First().Month;
                int year = payrolls.First().Year;
                await _payrollDAL.DeleteByMonthYearAsync(month, year);
                await _payrollDAL.CreateMultipleAsync(payrolls);
                return (true, "Lưu thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi lưu: " + ex.Message);
            }
        }

        public async Task<List<PayrollDTO>> LayBangLuongThangAsync(int month, int year)
        {
            var list = await _payrollDAL.GetByMonthYearAsync(month, year);
            var client = SupabaseClientManager.Instance.GetClient();
            var emps = await client.From<EmployeeDTO>().Get();
            var empDict = emps.Models.ToDictionary(e => e.EmployeeId);

            foreach (var p in list)
            {
                if (empDict.TryGetValue(p.EmployeeId, out var e))
                {
                    p.HoTen = e.FullName;
                }
            }
            return list;
        }

    }
}
