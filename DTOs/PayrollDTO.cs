using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("payrolls")]
    public class PayrollDTO : BaseModel
    {
        [PrimaryKey("payroll_id", false)]
        public int PayrollId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("month")]
        public int Month { get; set; }

        [Column("year")]
        public int Year { get; set; }

        [Column("working_days")]
        public decimal WorkingDays { get; set; }

        [Column("leave_days")]
        public decimal LeaveDays { get; set; }

        [Column("base_salary")]
        public decimal BaseSalary { get; set; }

        [Column("bonus")]
        public decimal Bonus { get; set; }

        [Column("deduction")]
        public decimal Deduction { get; set; }

        // Cột generated always as (base_salary + bonus - deduction) trong DB
        // -> chỉ ĐỌC, không gửi giá trị này khi insert/update
        [Column("net_salary")]
        public decimal NetSalary { get; set; }
    
        [JsonIgnore] public string MaBangLuong { get => PayrollId.ToString(); set {} }
        [JsonIgnore] public string MaNV { get => EmployeeId.ToString(); set {} }
        [JsonIgnore] public string HoTen { get; set; } = "";
        [JsonIgnore] public string ThangNam { get => $"{Month}/{Year}"; set {} }
        [JsonIgnore] public decimal NgayCongThucTe { get => WorkingDays; set => WorkingDays = value; }
        [JsonIgnore] public decimal LuongCoBan { get => BaseSalary; set => BaseSalary = value; }
        [JsonIgnore] public decimal PhuCap { get; set; } = 0;
        [JsonIgnore] public decimal Thuong { get => Bonus; set => Bonus = value; }
        [JsonIgnore] public decimal KhauTru { get => Deduction; set => Deduction = value; }
        [JsonIgnore] public decimal ThucLanh { get => NetSalary; set => NetSalary = value; }
        [JsonIgnore] public DateTime NgayTinh { get; set; } = DateTime.Now;
        [JsonIgnore] public string TrangThai { get; set; } = "";

    
        [JsonIgnore] public int Thang { get => Month; set => Month = value; }
        [JsonIgnore] public int Nam { get => Year; set => Year = value; }
        [JsonIgnore] public decimal SoNgayCong { get => WorkingDays; set => WorkingDays = value; }
        [JsonIgnore] public decimal SoGioOT { get; set; } = 0;
        [JsonIgnore] public decimal ThuongKPI { get => Bonus; set => Bonus = value; }
        [JsonIgnore] public decimal KhauTruBH { get => Deduction; set => Deduction = value; }
        [JsonIgnore] public decimal KhauTruThue { get; set; } = 0;
        [JsonIgnore] public decimal LuongThucTe { get => NetSalary; set => NetSalary = value; }

    }
}
