using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("departments")]
    public class DepartmentDTO : BaseModel
    {
        [PrimaryKey("department_id", false)]
        public int DepartmentId { get; set; }

        [Column("department_name")]
        public string DepartmentName { get; set; } = string.Empty;

        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    
        [JsonIgnore] public string MaPB { get => DepartmentId.ToString(); set {} }
        [JsonIgnore] public string TenPB { get => DepartmentName; set => DepartmentName = value; }
        [JsonIgnore] public string? TruongPhong { get; set; }

    }
}
