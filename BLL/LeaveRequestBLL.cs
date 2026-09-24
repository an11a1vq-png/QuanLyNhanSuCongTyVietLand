using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class LeaveRequestBLL
    {
        private readonly LeaveRequestDAL _leaveDAL = new LeaveRequestDAL();

        public async Task<(bool Success, string Message)> CreateAsync(DateTime startDate, DateTime endDate, string reason)
        {
            var employeeId = SessionManager.CurrentAccount?.EmployeeId;
            if (employeeId == null)
                return (false, "Tài khoản chưa gắn với nhân viên nào.");

            if (endDate < startDate)
                return (false, "Ngày kết thúc phải sau ngày bắt đầu.");

            if (startDate < DateTime.Today)
                return (false, "Không thể tạo đơn cho ngày trong quá khứ.");

            var leave = new LeaveRequestDTO
            {
                EmployeeId = employeeId.Value,
                StartDate = startDate,
                EndDate = endDate,
                Reason = reason,
                Status = "Pending"
            };

            await _leaveDAL.CreateAsync(leave);
            return (true, "Gửi đơn nghỉ phép thành công, chờ duyệt.");
        }

        public Task<List<LeaveRequestDTO>> GetMyRequestsAsync()
        {
            var employeeId = SessionManager.CurrentAccount?.EmployeeId ?? 0;
            return _leaveDAL.GetByEmployeeAsync(employeeId);
        }

        public Task<List<LeaveRequestDTO>> GetPendingForApprovalAsync() => _leaveDAL.GetPendingAsync();

        public async Task<(bool Success, string Message)> ApproveAsync(int leaveId)
        {
            if (!SessionManager.IsAdmin && !SessionManager.IsManager)
                return (false, "Bạn không có quyền duyệt đơn.");

            var leave = (await _leaveDAL.GetPendingAsync()).Find(l => l.LeaveId == leaveId);
            if (leave == null) return (false, "Không tìm thấy đơn hoặc đơn đã được xử lý.");

            leave.Status = "Approved";
            leave.ApprovedBy = SessionManager.CurrentAccount!.EmployeeId;
            leave.ApprovedDate = DateTime.Now;

            await _leaveDAL.UpdateAsync(leave);
            return (true, "Đã duyệt đơn nghỉ phép.");
        }

        public async Task<(bool Success, string Message)> RejectAsync(int leaveId)
        {
            if (!SessionManager.IsAdmin && !SessionManager.IsManager)
                return (false, "Bạn không có quyền từ chối đơn.");

            var leave = (await _leaveDAL.GetPendingAsync()).Find(l => l.LeaveId == leaveId);
            if (leave == null) return (false, "Không tìm thấy đơn hoặc đơn đã được xử lý.");

            leave.Status = "Rejected";
            leave.ApprovedBy = SessionManager.CurrentAccount!.EmployeeId;
            leave.ApprovedDate = DateTime.Now;

            await _leaveDAL.UpdateAsync(leave);
            return (true, "Đã từ chối đơn nghỉ phép.");
        }
    
        
        private async Task MapEmployees(List<LeaveRequestDTO> list)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var empResp = await client.From<EmployeeDTO>().Get();
            var dict = empResp.Models.ToDictionary(e => e.EmployeeId, e => e.FullName);
            foreach (var item in list)
            {
                if (dict.TryGetValue(item.EmployeeId, out var name))
                {
                    item.HoTen = name;
                }
                
                // Map ApprovedBy to Name if possible
                if (item.ApprovedBy.HasValue && dict.TryGetValue(item.ApprovedBy.Value, out var approver))
                {
                    item.NguoiDuyet = approver;
                }
            }
        }

        public async Task<List<LeaveRequestDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<LeaveRequestDTO>().Order("start_date", Supabase.Postgrest.Constants.Ordering.Descending).Get();
            var list = response.Models;
            await MapEmployees(list);
            return list;
        }

        public async Task<List<LeaveRequestDTO>> GetChoXuLyAsync()
        {
            var list = await GetPendingForApprovalAsync();
            await MapEmployees(list);
            return list;
        }

        public async Task<(bool, string)> DuyetDonAsync(long maDon, string trangThai, string nguoiDuyet)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                var resp = await client.From<LeaveRequestDTO>().Where(x => x.LeaveId == maDon).Get();
                if (resp.Models.Count == 0) return (false, "Không tìm thấy đơn.");
                
                var leave = resp.Models[0];
                leave.Status = (trangThai == "Đã duyệt" || trangThai == "Approved") ? "Approved" : "Rejected";
                leave.ApprovedBy = SessionManager.CurrentAccount?.EmployeeId;
                leave.ApprovedDate = DateTime.Now;
                await _leaveDAL.UpdateAsync(leave);

                // Fetch employee email
                var empResp = await client.From<EmployeeDTO>().Where(x => x.EmployeeId == leave.EmployeeId).Get();
                if (empResp.Models.Count > 0)
                {
                    var emp = empResp.Models[0];
                    if (!string.IsNullOrEmpty(emp.Email))
                    {
                        string statusText = leave.Status == "Approved" ? "chấp thuận" : "từ chối";
                        string subject = $"Thông báo kết quả đơn nghỉ phép ({statusText})";
                        string body = $"Chào {emp.FullName},\n\n" +
                                      $"Đơn nghỉ phép của bạn từ {leave.StartDate:dd/MM/yyyy} đến {leave.EndDate:dd/MM/yyyy} đã được {statusText}.\n" +
                                      $"Lý do xin nghỉ: {leave.Reason}\n\n" +
                                      $"Trân trọng,\nPhòng Nhân sự VIETLAND HR";
                        VietLandHR.GUI.Helpers.EmailHelper.SendEmailAsync(emp.Email, subject, body, emp.FullName);
                    }
                }
                return (true, "Đã cập nhật trạng thái đơn thành công!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> InsertAsync(LeaveRequestDTO dto)
        {
            try
            {
                var employeeId = SessionManager.CurrentAccount?.EmployeeId;
                if (employeeId.HasValue)
                {
                    dto.EmployeeId = employeeId.Value;
                }
                else if (!string.IsNullOrEmpty(dto.MaNV) && int.TryParse(dto.MaNV, out int parsedEmpId))
                {
                    dto.EmployeeId = parsedEmpId;
                }
                else
                {
                    // Look up employee by employee_code
                    var client = SupabaseClientManager.Instance.GetClient();
                    var empResp = await client.From<EmployeeDTO>().Where(x => x.EmployeeCode == dto.MaNV).Get();
                    if (empResp.Models.Count > 0)
                    {
                        dto.EmployeeId = empResp.Models[0].EmployeeId;
                    }
                }

                if (dto.EmployeeId <= 0)
                {
                    return (false, "Không tìm thấy mã nhân viên tương ứng.");
                }

                dto.Status = "Pending";
                await _leaveDAL.CreateAsync(dto);
                return (true, "Tạo đơn thành công!");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> DuyetDonAsync(string maDon, string nguoiDuyet) => await DuyetDonAsync(long.TryParse(maDon, out var id) ? id : 0, "Approved", nguoiDuyet);
        public async Task<(bool, string)> DuyetDonAsync(long maDon, string nguoiDuyet) => await DuyetDonAsync(maDon, "Approved", nguoiDuyet);
        public async Task<(bool, string)> DuyetDonAsync(long maDon, long nguoiDuyet) => await DuyetDonAsync(maDon, "Approved", nguoiDuyet.ToString());
        public async Task<List<LeaveRequestDTO>> GetByEmployeeAsync(string id) => await GetMyRequestsAsync();
        public async Task<(bool, string)> UpdateAsync(LeaveRequestDTO dto) { await _leaveDAL.UpdateAsync(dto); return (true, ""); }
        public async Task<(bool, string)> DeleteAsync(string id) => (true, "");
        public async Task<(bool, string)> DuyetDonAsync(string maDon, string nguoiDuyet, string? ghiChu) => await DuyetDonAsync(long.TryParse(maDon, out var id) ? id : 0, "Approved", nguoiDuyet);
        public async Task<(bool, string)> DuyetDonAsync(long maDon, string trangThai, string nguoiDuyet, string? ghiChu) => await DuyetDonAsync(maDon, trangThai, nguoiDuyet);
    }
}
