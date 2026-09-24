using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("email_logs")]
    public class EmailLogDTO : BaseModel
    {
        [PrimaryKey("email_log_id", false)]
        public int EmailLogId { get; set; }

        [Column("subject")]
        public string? Subject { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("receiver")]
        public string Receiver { get; set; } = string.Empty;

        [Column("sent_by")]
        public int? SentBy { get; set; }

        [Column("sent_at")]
        public DateTime SentAt { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Sent"; // Sent | Failed | Pending
    }
}
