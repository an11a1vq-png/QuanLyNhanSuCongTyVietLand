using System;
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("contracts")]
    public class ContractDTO : BaseModel
    {
        [PrimaryKey("contract_id", true)]
        public int ContractId { get; set; }

        [Column("contract_code")]
        public string ContractCode { get; set; } = "";

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("contract_type")]
        public string? ContractType { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("salary")]
        public decimal? Salary { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Active";

        // Navigation properties for legacy UI compatibility
        [JsonIgnore] public string MaHD { get => ContractCode; set => ContractCode = value; }
        [JsonIgnore] public string MaNV { get; set; } = ""; // Populated in BLL for display
        [JsonIgnore] public string? LoaiHD { get => ContractType; set => ContractType = value; }
        [JsonIgnore] public DateTime NgayBatDau { get => StartDate; set => StartDate = value; }
        [JsonIgnore] public DateTime? NgayKetThuc { get => EndDate; set => EndDate = value; }
        [JsonIgnore] public decimal? LuongThoa { get => Salary; set => Salary = value; }
        [JsonIgnore] public string? GhiChu { get => Notes; set => Notes = value; }
        [JsonIgnore] public string? TrangThai { get => Status; set => Status = value; }
        [JsonIgnore] public string? HoTen { get; set; }
    }
}

