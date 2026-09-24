using System;
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("feedbacks")]
    public class FeedbackDTO : BaseModel
    {
        [PrimaryKey("feedback_id", false)]
        public int FeedbackId { get; set; }

        [Column("feedback_code")]
        public string FeedbackCode { get; set; } = "";

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("submit_date")]
        public DateTime SubmitDate { get; set; } = DateTime.UtcNow;

        [Column("title")]
        public string Title { get; set; } = "";

        [Column("content")]
        public string Content { get; set; } = "";

        [Column("reply_content")]
        public string? ReplyContent { get; set; }

        [Column("replied_by")]
        public int? RepliedBy { get; set; }

        [Column("replied_at")]
        public DateTime? RepliedAt { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Chờ phản hồi";

        // Navigation properties for UI compatibility
        [JsonIgnore] public string MaGopY { get => FeedbackCode; set => FeedbackCode = value; }
        [JsonIgnore] public string? MaNV { get; set; }
        [JsonIgnore] public string? TenNhanVien { get; set; }
        [JsonIgnore] public string? EmailNhanVien { get; set; }
        [JsonIgnore] public DateTime NgayGui { get => SubmitDate; set => SubmitDate = value; }
        [JsonIgnore] public string? TieuDe { get => Title; set => Title = value; }
        [JsonIgnore] public string NoiDung { get => Content; set => Content = value; }
        [JsonIgnore] public string? PhanHoi { get => ReplyContent; set => ReplyContent = value; }
        [JsonIgnore] public int? NguoiPhanHoi { get => RepliedBy; set => RepliedBy = value; }
        [JsonIgnore] public DateTime? NgayPhanHoi { get => RepliedAt; set => RepliedAt = value; }
        [JsonIgnore] public string? TrangThai { get => Status; set => Status = value; }
    }
}

