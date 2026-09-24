using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("employees")]
    public class EmployeeDTO : BaseModel
    {
        [PrimaryKey("employee_id", false)]
        public int EmployeeId { get; set; }

        [Column("employee_code")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("gender")]
        public string? Gender { get; set; }          // "Male" | "Female" | "Other"

        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("cccd")]
        public string? CitizenId { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [Column("position_id")]
        public int? PositionId { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Active"; // Active | Inactive | Resigned
        [Column("base_salary")]
        public decimal BaseSalary { get; set; } = 0;
    
        [JsonIgnore] public string MaNV { get => EmployeeCode; set => EmployeeCode = value; }
        [JsonIgnore] public string HoTen { get => FullName; set => FullName = value; }
        [JsonIgnore] public string? GioiTinh { get => Gender; set => Gender = value; }
        [JsonIgnore] public DateTime? NgaySinh { get => BirthDate; set => BirthDate = value; }
        [JsonIgnore] public string? CCCD { get => CitizenId; set => CitizenId = value; }
        [JsonIgnore] public string? SDT { get => Phone; set => Phone = value; }
        [JsonIgnore] public string? DiaChi { get => Address; set => Address = value; }
        [JsonIgnore] public string? MaPB { get => DepartmentId?.ToString(); set {} }
        [JsonIgnore] public string? TenPhongBan { get; set; }
        [JsonIgnore] public string? ChucVu { get => PositionId?.ToString(); set {} }
        [JsonIgnore] public DateTime? NgayVaoLam { get => HireDate; set => HireDate = value ?? DateTime.Now; }
        [JsonIgnore] public decimal LuongCoBan { get => BaseSalary; set => BaseSalary = value; }
        [JsonIgnore] public string TrangThai { get => Status; set => Status = value; }

    }
}
