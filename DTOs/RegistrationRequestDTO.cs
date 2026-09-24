using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("registration_requests")]
    public class RegistrationRequestDTO : BaseModel
    {
        [PrimaryKey("registration_id", true)]
        public int RegistrationId { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        [Column("gender")]
        public string? Gender { get; set; }

        [Column("cccd")]
        public string? CitizenId { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Pending"; // Pending | Approved | Rejected

        [Column("reviewed_by")]
        public int? ReviewedBy { get; set; }

        [Column("reviewed_at")]
        public DateTime? ReviewedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
