using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("roles")]
    public class RoleDTO : BaseModel
    {
        [PrimaryKey("role_id", false)]
        public int RoleId { get; set; }

        [Column("role_name")]
        public string RoleName { get; set; } = string.Empty;
    }
}
