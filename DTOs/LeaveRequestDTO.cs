using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models; using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("leave_requests")]
    public class LeaveRequestDTO : BaseModel
    {
        [PrimaryKey("leave_id", false)]
        public int LeaveId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("reason")]
        public string? Reason { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Pending"; // Pending | Approved | Rejected

        [Column("approved_by")]
        public int? ApprovedBy { get; set; }

        [Column("approved_date")]
        public DateTime? ApprovedDate { get; set; }
    
        
        [Column("leave_type")]
        public string LeaveType { get; set; } = "";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore] public string MaDon { get => LeaveId.ToString(); set {} }
        [JsonIgnore] public string MaNV { get => EmployeeId.ToString(); set {} }
        [JsonIgnore] public string HoTen { get; set; } = "";
        [JsonIgnore] public string LoaiNghi { get => LeaveType; set => LeaveType = value; }
        [JsonIgnore] public DateTime NgayBatDau { get => StartDate; set => StartDate = value; }
        [JsonIgnore] public DateTime NgayKetThuc { get => EndDate; set => EndDate = value; }
        [JsonIgnore] public string LyDo { get => Reason ?? ""; set => Reason = value; }
        [JsonIgnore] public string TrangThai { get => Status == "Pending" ? "Chờ duyệt" : Status == "Approved" ? "Đã duyệt" : Status == "Rejected" ? "Từ chối" : Status; set {} }
        [JsonIgnore] public string NguoiDuyet { get => ApprovedBy?.ToString() ?? ""; set {} }
        [JsonIgnore] public DateTime NgayGui { get => CreatedAt; set => CreatedAt = value; }

    }
}

