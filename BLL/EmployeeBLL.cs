using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _employeeDAL = new EmployeeDAL();

        // Admin: tất cả | Manager: chỉ phòng ban mình | Employee: chỉ thông tin của mình
        public async Task<List<EmployeeDTO>> GetVisibleEmployeesAsync()
        {
            if (SessionManager.IsAdmin)
                return await _employeeDAL.GetAllAsync();

            if (SessionManager.IsManager)
            {
                var myEmployeeId = SessionManager.CurrentAccount!.EmployeeId;
                // Lấy department_id của chính Manager rồi lọc theo phòng ban đó
                var me = myEmployeeId.HasValue ? await _employeeDAL.GetByIdAsync(myEmployeeId.Value) : null;
                if (me?.DepartmentId != null)
                    return await _employeeDAL.GetByDepartmentAsync(me.DepartmentId.Value);
                return new List<EmployeeDTO>();
            }

            // Employee: chỉ thấy chính mình
            var employeeId = SessionManager.CurrentAccount?.EmployeeId;
            if (employeeId == null) return new List<EmployeeDTO>();
            var self = await _employeeDAL.GetByIdAsync(employeeId.Value);
            return self != null ? new List<EmployeeDTO> { self } : new List<EmployeeDTO>();
        }

        public Task<EmployeeDTO?> GetByIdAsync(int id) => _employeeDAL.GetByIdAsync(id);

        public async Task<string> GetNextEmployeeCodeAsync()
        {
            var maxCode = await _employeeDAL.GetMaxEmployeeCodeAsync();
            if (string.IsNullOrEmpty(maxCode) || !maxCode.StartsWith("NV"))
                return "NV001";
            
            string numStr = maxCode.Substring(2);
            if (int.TryParse(numStr, out int num))
                return "NV" + (num + 1).ToString("D3");
            
            return "NV001";
        }

        public async Task<(bool Success, string Message)> CreateAsync(EmployeeDTO employee)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được thêm nhân viên.");

            if (string.IsNullOrWhiteSpace(employee.FullName))
                return (false, "Họ tên không được để trống.");

            if (string.IsNullOrWhiteSpace(employee.EmployeeCode))
                return (false, "Mã nhân viên không được để trống.");

            // 1. Chặn trùng Mã nhân viên (EmployeeCode)
            var existingCode = await _employeeDAL.GetByEmployeeCodeAsync(employee.EmployeeCode);
            if (existingCode != null)
                return (false, $"Mã nhân viên '{employee.EmployeeCode}' đã tồn tại trong hệ thống. Vui lòng sử dụng Mã NV khác!");

            // 2. Chặn trùng và kiểm tra định dạng Email nhân viên (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(employee.Email))
            {
                if (!Utils.ValidationHelper.IsValidEmail(employee.Email))
                    return (false, "Email không đúng định dạng. Vui lòng nhập đúng định dạng Email (VD: name@domain.com)!");

                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.Email?.Trim().ToLower() == employee.Email.Trim().ToLower()))
                    return (false, $"Email '{employee.Email}' đã được đăng ký cho một nhân viên khác!");
            }

            // 3. Chặn trùng Số CCCD nhân viên (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(employee.CitizenId))
            {
                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.CitizenId?.Trim() == employee.CitizenId.Trim()))
                    return (false, $"Số CCCD '{employee.CitizenId}' đã được đăng ký cho một nhân viên khác trong hệ thống!");
            }

            // 4. Chặn trùng Số điện thoại nhân viên (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(employee.Phone))
            {
                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.Phone?.Trim() == employee.Phone.Trim()))
                    return (false, $"Số điện thoại '{employee.Phone}' đã được đăng ký cho một nhân viên khác trong hệ thống!");
            }

            var createdEmp = await _employeeDAL.CreateAsync(employee);
            
            // Tự động tạo tài khoản nếu có Email
            if (createdEmp != null && !string.IsNullOrWhiteSpace(createdEmp.Email))
            {
                Guid? authUid = null;
                try
                {
                    var client = SupabaseClientManager.Instance.GetClient();
                    var adminSession = client.Auth.CurrentSession; // lưu session admin
                    var authRes = await client.Auth.SignUp(createdEmp.Email, "123456");
                    if (authRes?.User?.Id != null) authUid = Guid.Parse(authRes.User.Id);
                    // khôi phục session admin
                    if (adminSession?.AccessToken != null)
                        await client.Auth.SetSession(adminSession.AccessToken, adminSession.RefreshToken ?? "");
                }
                catch
                {
                    // Tránh crash nếu tài khoản Auth đã tồn tại
                }

                try
                {
                    var acc = new AccountDTO
                    {
                        Username = createdEmp.Email,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
                        RoleId = 3, // Employee
                        EmployeeId = createdEmp.EmployeeId,
                        IsActive = true,
                        UserId = authUid
                    };
                    var accDAL = new AccountDAL();
                    await accDAL.CreateAsync(acc);
                }
                catch (Exception ex)
                {
                     return (true, $"Thêm nhân viên thành công nhưng không thể tạo tài khoản nội bộ: {ex.Message}");
                }
            }

            return (true, "Thêm nhân viên thành công! (Tài khoản đã tự động được khởi tạo với MK mặc định: 123456)");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(EmployeeDTO employee)
        {
            bool isSelf = SessionManager.CurrentAccount?.EmployeeId == employee.EmployeeId;

            if (!SessionManager.IsAdmin && !isSelf)
                return (false, "Bạn không có quyền sửa thông tin nhân viên này. Chỉ Admin mới được quyền sửa.");

            // Kiểm tra định dạng Email khi cập nhật
            if (!string.IsNullOrWhiteSpace(employee.Email))
            {
                if (!Utils.ValidationHelper.IsValidEmail(employee.Email))
                    return (false, "Email không đúng định dạng. Vui lòng nhập đúng định dạng Email (VD: name@domain.com)!");

                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.Email?.Trim().ToLower() == employee.Email.Trim().ToLower()))
                    return (false, $"Email '{employee.Email}' đã được đăng ký cho một nhân viên khác!");
            }

            // Chặn trùng số CCCD khi cập nhật
            if (!string.IsNullOrWhiteSpace(employee.CitizenId))
            {
                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.CitizenId?.Trim() == employee.CitizenId.Trim()))
                    return (false, $"Số CCCD '{employee.CitizenId}' đã được đăng ký cho một nhân viên khác!");
            }

            // Chặn trùng Số điện thoại khi cập nhật
            if (!string.IsNullOrWhiteSpace(employee.Phone))
            {
                var allEmps = await _employeeDAL.GetAllAsync();
                if (allEmps.Exists(e => e.EmployeeId != employee.EmployeeId && e.Phone?.Trim() == employee.Phone.Trim()))
                    return (false, $"Số điện thoại '{employee.Phone}' đã được đăng ký cho một nhân viên khác!");
            }

            await _employeeDAL.UpdateAsync(employee);

            // Đồng bộ Email mới sang Tên đăng nhập (Username) của Tài khoản
            if (!string.IsNullOrWhiteSpace(employee.Email))
            {
                try
                {
                    var accDal = new AccountDAL();
                    var allAccs = await accDal.GetAllAsync();
                    var userAcc = allAccs.FirstOrDefault(a => a.EmployeeId == employee.EmployeeId);
                    if (userAcc != null && userAcc.Username != employee.Email.Trim())
                    {
                        userAcc.Username = employee.Email.Trim();
                        await accDal.UpdateAsync(userAcc);
                    }
                }
                catch { }
            }

            // Đồng bộ mức lương mới sang Hợp đồng đang có hiệu lực (Active Contract) nếu có
            if (employee.BaseSalary > 0)
            {
                try
                {
                    var contractDal = new ContractDAL();
                    var userContracts = await contractDal.GetByEmployeeIdAsync(employee.EmployeeId);
                    var activeContract = userContracts.FirstOrDefault(c => c.Status == "Active");
                    if (activeContract != null)
                    {
                        activeContract.Salary = employee.BaseSalary;
                        await contractDal.UpdateAsync(activeContract);
                    }
                }
                catch { }
            }

            return (true, "Cập nhật thành công.");
        }

        public async Task<(bool Success, string Message)> ToggleStatusAsync(int employeeId)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được thay đổi trạng thái nhân viên.");

            var emp = await _employeeDAL.GetByIdAsync(employeeId);
            if (emp == null) return (false, "Không tìm thấy nhân viên.");

            string newStatus = (emp.Status == "Resigned" || emp.Status == "Inactive") ? "Active" : "Resigned";
            await _employeeDAL.SetStatusAsync(employeeId, newStatus);
            
            string msg = newStatus == "Active" ? "Đã kích hoạt nhân viên đi làm lại thành công." : "Đã chuyển trạng thái nhân viên sang Nghỉ việc.";
            return (true, msg);
        }

        public async Task<(bool Success, string Message)> DeactivateAsync(int employeeId)
        {
            return await ToggleStatusAsync(employeeId);
        }
    
        public async Task<(bool Success, string Message)> DeleteAsync(int employeeId)
        {
            if (!SessionManager.IsAdmin && !SessionManager.IsManager)
                return (false, "Bạn không có quyền xóa nhân viên.");

            await _employeeDAL.DeleteCascadeAsync(employeeId);
            return (true, "Đã xóa vĩnh viễn nhân viên và tất cả dữ liệu liên quan thành công.");
        }

        public async Task<(bool ok, string msg)> ThemMoiAsync(EmployeeDTO dto) => await CreateAsync(dto);
        public async Task<(bool ok, string msg)> CapNhatAsync(EmployeeDTO dto) => await UpdateAsync(dto);
        public async Task<(bool, string)> XoaAsync(string id)
        {
            if (int.TryParse(id, out int empId))
            {
                return await DeleteAsync(empId);
            }
            return (false, "Mã nhân viên không hợp lệ.");
        }
        public async Task<List<EmployeeDTO>> LayDanhSachAsync() => await GetVisibleEmployeesAsync();
        public async Task<List<VietLandHR.DTOs.DepartmentDTO>> LayDanhSachPhongBanAsync() => new List<VietLandHR.DTOs.DepartmentDTO>();

    }
}
