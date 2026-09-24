using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("accounts")]
    public class AccountDTO : BaseModel
    {
        [PrimaryKey("account_id", false)]
        public int AccountId { get; set; }

        [Column("user_id")]
        public Guid? UserId { get; set; }        // liên kết auth.users.id (Supabase Auth)

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("password_hash")]
        public string? PasswordHash { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    
        [JsonIgnore] public string MaTK { get => AccountId.ToString(); set {} }
        [JsonIgnore] public string? MaNV { get => EmployeeId?.ToString(); set {} }
        [JsonIgnore] public string TenDangNhap { get => Username; set => Username = value; }
        [JsonIgnore] public string MatKhauHash { get => PasswordHash; set => PasswordHash = value; }
        [JsonIgnore] public string VaiTro { get => RoleId.ToString(); set {} }
        [JsonIgnore] public bool TrangThai { get => IsActive; set => IsActive = value; }

    }
}
