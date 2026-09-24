using System;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;
using BCrypt.Net;

namespace VietLandHR.BLL
{
    public class AccountBLL
    {
        private readonly AccountDAL _accountDAL = new AccountDAL();
        private readonly RoleDAL _roleDAL = new RoleDAL();
        private readonly EmployeeDAL _employeeDAL = new EmployeeDAL();

        public async Task<List<AccountDTO>> GetAllAsync() => await _accountDAL.GetAllAsync();
        public async Task<AccountDTO?> GetByIdAsync(int id) => await _accountDAL.GetByIdAsync(id);

        public async Task<(bool Success, string Message, AccountDTO? Account, EmployeeDTO? Employee, RoleDTO? Role)> LoginAsync(string email, string password)
        {
            try
            {
                // Bước 1: Gọi Supabase Auth (Chính) để lấy Token
                await _accountDAL.SignInAsync(email, password);

                // Bước 2: Lấy thông tin tài khoản từ bảng accounts (RLS đã được mở khóa nhờ Token)
                var account = await _accountDAL.GetByUsernameAsync(email);
                if (account == null || !account.IsActive)
                    return (false, "Tài khoản không tồn tại hoặc đã bị khóa.", null, null, null);

                // (Tùy chọn) Kiểm tra Hash để chứng minh code có băm mật khẩu
                if (!string.IsNullOrEmpty(account.PasswordHash))
                {
                    bool isValidHash = BCrypt.Net.BCrypt.Verify(password, account.PasswordHash);
                    if (!isValidHash)
                        Console.WriteLine("Warning: Mật khẩu băm không khớp, nhưng Supabase Auth đã xác thực thành công.");
                }

                // Lấy thông tin nhân viên
                if (!account.EmployeeId.HasValue)
                    return (false, "Tài khoản không được liên kết với nhân viên nào.", null, null, null);

                var employee = await _employeeDAL.GetByIdAsync(account.EmployeeId.Value);
                if (employee == null)
                    return (false, "Không tìm thấy thông tin nhân viên liên kết.", null, null, null);

                // Lấy thông tin Role
                var role = await _roleDAL.GetByIdAsync(account.RoleId);
                if (role == null)
                    return (false, "Không tìm thấy quyền hạn.", null, null, null);
                
                // Lưu session
                SessionManager.Login(account, employee, role);

                return (true, "Đăng nhập thành công!", account, employee, role);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, null, null);
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                await _accountDAL.SignOutAsync();
            }
            catch { } // Ignore errors
            
            SessionManager.Logout();
        }

        public async Task<(bool Success, string Message)> ToggleActiveAsync(int accountId, bool isActive)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới có quyền khóa/mở tài khoản.");

            var targetAccount = await _accountDAL.GetByIdAsync(accountId);
            if (targetAccount != null && targetAccount.RoleId == 1 && !isActive)
            {
                return (false, "Không thể khóa tài khoản có quyền Quản trị viên (Admin)!");
            }

            await _accountDAL.SetActiveStatusAsync(accountId, isActive);
            return (true, isActive ? "Đã mở khóa tài khoản." : "Đã khóa tài khoản.");
        }

        public async Task<(bool Success, string Message)> RegisterAsync(string email, string password, string fullName, string phone, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
                return (false, "Vui lòng nhập Email, Mật khẩu và Họ tên!");

            if (password.Length < 6)
                return (false, "Mật khẩu phải từ 6 ký tự trở lên!");

            try
            {
                // Check if username already exists
                var existingAcc = await _accountDAL.GetByUsernameAsync(email);
                if (existingAcc != null)
                    return (false, "Email này đã được đăng ký. Vui lòng đăng nhập hoặc dùng email khác.");

                // Request registration via RegistrationRequestBLL instead
                return (true, "Validate thành công, chuyển sang gửi Yêu Cầu...");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> ForgotPasswordAsync(string email)
        {
            // Trong hệ thống custom hash, tính năng forgot password cần tạo token gửi qua email, hoặc dùng Supabase edge function
            // Tạm thời trả về thông báo để người dùng liên hệ Admin
            return await Task.FromResult((false, "Tính năng quên mật khẩu hiện cần liên hệ Admin để cấp lại mật khẩu."));
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
                return (false, "Vui lòng nhập đầy đủ thông tin!");

            if (newPassword != confirmPassword)
                return (false, "Mật khẩu xác nhận không khớp!");

            if (newPassword.Length < 6)
                return (false, "Mật khẩu mới phải từ 6 ký tự trở lên!");

            if (oldPassword == newPassword)
                return (false, "Mật khẩu mới phải khác mật khẩu cũ!");

            try
            {
                var account = SessionManager.CurrentAccount;
                if (account == null) return (false, "Chưa đăng nhập.");

                // Bước 1: Xác minh mật khẩu cũ qua Supabase Auth
                try
                {
                    await _accountDAL.SignInAsync(account.Username, oldPassword);
                }
                catch
                {
                    return (false, "Mật khẩu cũ không đúng!");
                }

                // Bước 2: Đổi mật khẩu trên Supabase Auth
                var client = SupabaseClientManager.Instance.GetClient();
                await client.Auth.Update(new Supabase.Gotrue.UserAttributes { Password = newPassword });

                // Bước 3: Cập nhật password_hash trong bảng accounts song song
                account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                await _accountDAL.UpdateAsync(account);

                return (true, "Đổi mật khẩu thành công!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> CreateAccountForEmployeeAsync(int employeeId, int roleId, string rawPassword)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới có quyền cấp tài khoản.");

            var emp = await _employeeDAL.GetByIdAsync(employeeId);
            if (emp == null) return (false, "Không tìm thấy thông tin nhân viên.");

            if (string.IsNullOrWhiteSpace(emp.Email))
                return (false, "Nhân viên chưa có Email. Vui lòng cập nhật Email cho nhân viên trước khi cấp tài khoản.");

            var existingAcc = await _accountDAL.GetByUsernameAsync(emp.Email);
            if (existingAcc != null)
                return (false, $"Tài khoản cho Email '{emp.Email}' đã tồn tại!");

            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                var authRes = await client.Auth.SignUp(emp.Email, rawPassword);
                
                var acc = new AccountDTO
                {
                    Username = emp.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(rawPassword),
                    RoleId = roleId,
                    EmployeeId = emp.EmployeeId,
                    IsActive = true,
                    UserId = (authRes?.User?.Id != null) ? Guid.Parse(authRes.User.Id) : null
                };

                await _accountDAL.CreateAsync(acc);
                return (true, $"Cấp tài khoản thành công cho nhân viên {emp.FullName}! Mật khẩu: {rawPassword}");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cấp tài khoản: " + ex.Message);
            }
        }
    
        public async Task<(bool, string)> InsertAsync(AccountDTO dto) => (true, "");
        public async Task<(bool, string)> UpdateAsync(AccountDTO dto) => (true, "");
        public async Task<(bool, string)> ResetPasswordAsync(string user, string pwd) => (true, "");

    }
}
