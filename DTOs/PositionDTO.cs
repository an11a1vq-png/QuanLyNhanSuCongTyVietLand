using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace VietLandHR.DTOs
{
    [Table("positions")]
    public class PositionDTO : BaseModel
    {
        [PrimaryKey("position_id", false)]
        public int PositionId { get; set; }

        [Column("position_name")]
        public string PositionName { get; set; } = string.Empty;

        [Column("base_salary")]
        public decimal BaseSalary { get; set; }
    }
}
