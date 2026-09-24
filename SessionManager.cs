using VietLandHR.DTOs;

namespace VietLandHR
{
    // Lưu thông tin phiên đăng nhập hiện tại, dùng chung cho toàn bộ Form sau khi login
    public static class SessionManager
    {
        public static AccountDTO? CurrentAccount { get; private set; }
        public static EmployeeDTO? CurrentEmployee { get; private set; }
        public static RoleDTO? CurrentRole { get; private set; }
        public static string? CurrentRoleName { get; private set; }

        public static void Login(AccountDTO account, EmployeeDTO employee, RoleDTO role)
        {
            CurrentAccount = account;
            CurrentEmployee = employee;
            CurrentRole = role;
            CurrentRoleName = role.RoleName;
        }

        public static void Logout()
        {
            CurrentAccount = null;
            CurrentEmployee = null;
            CurrentRole = null;
            CurrentRoleName = null;
        }

        public static bool IsLoggedIn => CurrentAccount != null;

        public static bool IsAdmin => CurrentRoleName == "Admin";
        public static bool IsManager => CurrentRoleName == "Manager";
        public static bool IsEmployee => CurrentRoleName == "Employee";
    }
}
