using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class AttendanceBLL
    {
        private readonly AttendanceDAL _attendanceDAL = new AttendanceDAL();

        // Nhân viên bấm Check-in
        public async Task<(bool Success, string Message)> CheckInAsync()
        {
            var employeeId = SessionManager.CurrentAccount?.EmployeeId;
            if (employeeId == null)
                return (false, "Tài khoản chưa gắn với nhân viên nào.");

            var today = DateTime.Today;
            // 0. Tự động quét & chốt giờ chuẩn (17:30) cho tất cả các ngày cũ nhân viên lỡ quên Check-out
            await AutoFixMissingCheckOutsAsync(employeeId.Value);

            var existing = await _attendanceDAL.GetByEmployeeAndDateAsync(employeeId.Value, today);

            if (existing != null)
                return (false, $"Bạn đã check-in lúc {existing.CheckIn.Value.ToLocalTime():HH:mm} hôm nay rồi.");

            var now = DateTime.Now;
            var nowUtc = DateTime.UtcNow;
            var status = now.TimeOfDay > new TimeSpan(8, 15, 0) ? "Late" : "Present";

            var attendance = new AttendanceDTO
            {
                EmployeeId = employeeId.Value,
                WorkDate = today,
                CheckIn = nowUtc,
                Status = status
            };

            await _attendanceDAL.CreateAsync(attendance);
            return (true, $"Check-in thành công lúc {now:HH:mm}!");
        }

        /// <summary>
        /// Tự động quét và xử lý các bản ghi quên Check-out trong quá khứ:
        /// Gán Check-out = 17:30 (Mặc định 8.0h công chuẩn, 0h OT) để không bị mất công của nhân viên.
        /// </summary>
        public async Task AutoFixMissingCheckOutsAsync(int employeeId)
        {
            try
            {
                var records = await _attendanceDAL.GetByEmployeeAsync(employeeId);
                var unclosedPastRecords = records.Where(r => r.CheckOut == null && r.CheckIn.HasValue && r.WorkDate.Date < DateTime.Today).ToList();

                foreach (var r in unclosedPastRecords)
                {
                    var defaultCheckOut = r.WorkDate.Date.AddHours(17).AddMinutes(30);
                    r.CheckOut = defaultCheckOut;
                    var (workHrs, otHrs) = CalculateWorkAndOTHours(r.CheckIn.Value, defaultCheckOut);
                    r.TotalHours = workHrs + otHrs;
                    await _attendanceDAL.UpdateAsync(r);
                }
            }
            catch { }
        }

        // Nhân viên bấm Check-out - tự tính TotalHours
        public async Task<(bool Success, string Message)> CheckOutAsync()
        {
            var employeeId = SessionManager.CurrentAccount?.EmployeeId;
            if (employeeId == null)
                return (false, "Tài khoản chưa gắn với nhân viên nào.");

            var today = DateTime.Today;
            var existing = await _attendanceDAL.GetByEmployeeAndDateAsync(employeeId.Value, today);

            if (existing == null || existing.CheckIn == null)
                return (false, "Bạn chưa check-in hôm nay.");

            if (existing.CheckOut != null)
                return (false, $"Bạn đã check-out lúc {existing.CheckOut.Value.ToLocalTime():HH:mm} rồi.");

            var now = DateTime.Now;
            existing.CheckOut = now.ToUniversalTime();
            var (workHrs, otHrs) = CalculateWorkAndOTHours(existing.CheckIn.Value, now);
            existing.TotalHours = workHrs + otHrs; // Tổng giờ bao gồm ca chính và OT

            await _attendanceDAL.UpdateAsync(existing);
            return (true, $"Check-out thành công lúc {now:HH:mm}! (Giờ làm: {workHrs}h, OT: {otHrs}h)");
        }

        /// <summary>
        /// Thuật toán tính giờ làm thực tế & giờ OT chuẩn theo yêu cầu:
        /// 1. Trừ 1.5 tiếng nghỉ trưa (12:00 - 13:30) nếu ca làm đi vắt qua giờ nghỉ trưa.
        /// 2. Ca chính tối đa 8.0 giờ/ngày.
        /// 3. Số phút vượt quá 8h được tính OT: Cứ mỗi 30 phút trở lên tính 0.5 giờ OT (dưới 30p = 0).
        /// </summary>
        public static (decimal WorkHours, decimal OTHours) CalculateWorkAndOTHours(DateTime checkIn, DateTime checkOut)
        {
            DateTime localIn = checkIn.Kind == DateTimeKind.Utc ? checkIn.ToLocalTime() : checkIn;
            DateTime localOut = checkOut.Kind == DateTimeKind.Utc ? checkOut.ToLocalTime() : checkOut;

            if (localOut <= localIn) return (0, 0);

            // Gọt giờ Check-in sớm trước 08:00 về mốc 08:00 để không bị tính thừa công do đến sớm
            DateTime effectiveCheckIn = localIn;
            DateTime workStartTime = localIn.Date.AddHours(8);
            if (localIn < workStartTime)
            {
                effectiveCheckIn = workStartTime;
            }

            if (localOut <= effectiveCheckIn) return (0, 0);

            double totalMinutes = (localOut - effectiveCheckIn).TotalMinutes;

            // 1. Tính số phút trùng với khung giờ nghỉ trưa (12:00 -> 13:30)
            DateTime lunchStart = localIn.Date.AddHours(12);
            DateTime lunchEnd = localIn.Date.AddHours(13).AddMinutes(30);

            double breakMinutes = 0;
            if (effectiveCheckIn < lunchEnd && localOut > lunchStart)
            {
                DateTime overlapStart = effectiveCheckIn > lunchStart ? effectiveCheckIn : lunchStart;
                DateTime overlapEnd = localOut < lunchEnd ? localOut : lunchEnd;
                breakMinutes = (overlapEnd - overlapStart).TotalMinutes;
            }

            double netWorkMinutes = Math.Max(0, totalMinutes - breakMinutes);

            // 2. Ca chính tối đa 8.0 giờ = 480 phút
            double standardMinutes = Math.Min(480, netWorkMinutes);
            decimal workHours = Math.Round((decimal)(standardMinutes / 60.0), 1);

            // 3. Số phút làm thêm OT (vượt quá 480 phút)
            double otMinutes = Math.Max(0, netWorkMinutes - 480);

            // Quy tắc: Cứ đủ 30 phút trở lên thì tính 0.5 giờ OT (dưới 30 phút = 0.0 giờ)
            double otBlocks = Math.Floor(otMinutes / 30.0);
            decimal otHours = (decimal)(otBlocks * 0.5);

            return (workHours, otHours);
        }

        public async Task<List<AttendanceDTO>> GetMyAttendanceAsync()
        {
            var employeeId = SessionManager.CurrentAccount?.EmployeeId ?? 0;
            if (employeeId > 0)
            {
                await AutoFixMissingCheckOutsAsync(employeeId);
            }
            return await _attendanceDAL.GetByEmployeeAsync(employeeId);
        }

        public Task<List<AttendanceDTO>> GetByEmployeeAsync(int employeeId) =>
            _attendanceDAL.GetByEmployeeAsync(employeeId);

        public Task<List<AttendanceDTO>> GetAttendanceListAsync(DateTime from, DateTime to)
        {
            return _attendanceDAL.GetByDateRangeAsync(from, to);
        }

        public async Task<(bool Success, string Message)> DeleteAttendanceAsync(int id)
        {
            if (!SessionManager.IsAdmin) return (false, "Chỉ Admin/Quản lý mới được xóa chấm công.");
            await _attendanceDAL.DeleteAsync(id);
            return (true, "Xóa thành công.");
        }

        public async Task<(bool Success, string Message)> AutoCheckOutYesterdayAsync()
        {
            if (!SessionManager.IsAdmin) return (false, "Chỉ Admin/Quản lý mới được chốt sổ.");

            var yesterday = DateTime.Today.AddDays(-1);
            var records = await _attendanceDAL.GetByDateAsync(yesterday);
            
            int count = 0;
            foreach (var r in records)
            {
                if (r.CheckOut == null && r.CheckIn != null)
                {
                    // Checkout at 17:30
                    var checkoutTime = yesterday.AddHours(17).AddMinutes(30);
                    r.CheckOut = checkoutTime;
                    r.TotalHours = (decimal)(checkoutTime - r.CheckIn.Value).TotalHours;
                    await _attendanceDAL.UpdateAsync(r);
                    count++;
                }
            }

            return (true, $"Đã chốt sổ thành công cho {count} bản ghi!");
        }
        public async Task<(bool Success, string Message)> CheckInAdminAsync(int employeeId)
        {
            var today = DateTime.Today;
            var existing = await _attendanceDAL.GetByEmployeeAndDateAsync(employeeId, today);
            if (existing != null)
                return (false, $"Bạn đã check-in lúc {existing.CheckIn.Value.ToLocalTime():HH:mm} hôm nay rồi.");

            var now = DateTime.Now;
            var nowUtc = DateTime.UtcNow;
            var status = now.TimeOfDay > new TimeSpan(8, 15, 0) ? "Late" : "Present";
            var attendance = new AttendanceDTO { EmployeeId = employeeId, WorkDate = today, CheckIn = nowUtc, Status = status };
            await _attendanceDAL.CreateAsync(attendance);
            return (true, $"Check-in thành công lúc {now:HH:mm}!");
        }

        public async Task<(bool Success, string Message)> CheckOutAdminAsync(int employeeId)
        {
            var today = DateTime.Today;
            var existing = await _attendanceDAL.GetByEmployeeAndDateAsync(employeeId, today);
            if (existing == null || existing.CheckIn == null)
                return (false, "Nhân viên chưa check-in hôm nay.");
            if (existing.CheckOut != null)
                return (false, $"Nhân viên đã check-out lúc {existing.CheckOut.Value.ToLocalTime():HH:mm} rồi.");

            var now = DateTime.Now;
            var nowUtc = DateTime.UtcNow;
            existing.CheckOut = nowUtc;
            var (workHrs, otHrs) = CalculateWorkAndOTHours(existing.CheckIn.Value, now);
            existing.TotalHours = workHrs + otHrs;
            await _attendanceDAL.UpdateAsync(existing);
            return (true, $"Check-out thành công lúc {now:HH:mm}!");
        }

        public async Task<(bool Success, string Message)> UpdateAttendanceAdminAsync(int attendanceId, DateTime? checkIn, DateTime? checkOut, string status)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin/Quản lý mới có quyền điều chỉnh chấm công.");

            var existing = await _attendanceDAL.GetByIdAsync(attendanceId);
            if (existing == null)
                return (false, "Không tìm thấy bản ghi chấm công.");

            existing.CheckIn = checkIn;
            existing.CheckOut = checkOut;
            existing.Status = string.IsNullOrWhiteSpace(status) ? "Present" : status;

            if (checkIn.HasValue && checkOut.HasValue)
            {
                var (workHrs, otHrs) = CalculateWorkAndOTHours(checkIn.Value, checkOut.Value);
                existing.TotalHours = workHrs + otHrs;
            }
            else
            {
                existing.TotalHours = 0;
            }

            await _attendanceDAL.UpdateAsync(existing);
            return (true, "Điều chỉnh giờ chấm công thành công!");
        }
    }
}
