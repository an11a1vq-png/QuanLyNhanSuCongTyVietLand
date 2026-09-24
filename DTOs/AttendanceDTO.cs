using System;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;

namespace VietLandHR.DTOs
{
    [Table("attendance")]
    public class AttendanceDTO : BaseModel
    {
        [PrimaryKey("attendance_id", false)]
        public int AttendanceId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        private DateTime _workDate;
        [Column("work_date")]
        public DateTime WorkDate 
        { 
            get => _workDate; 
            set => _workDate = DateTime.SpecifyKind(value.Date, DateTimeKind.Utc); 
        }

        [Column("check_in")]
        public DateTime? CheckIn { get; set; }

        [Column("check_out")]
        public DateTime? CheckOut { get; set; }

        [Column("total_hours")]
        public decimal? TotalHours { get; set; }

        [Column("status")]
        public string Status { get; set; } = "Present"; // Present | Late | Absent | OnLeave
    
        [JsonIgnore] public string MaChamCong { get => AttendanceId.ToString(); set {} }
        [JsonIgnore] public string MaNV { get => EmployeeId.ToString(); set {} }
        [JsonIgnore] public string HoTen { get; set; } = "";
        [JsonIgnore] public DateTime Ngay { get; set; }
        [JsonIgnore] public TimeSpan? GioVao { get; set; }
        [JsonIgnore] public TimeSpan? GioRa { get; set; }
        [JsonIgnore] public string TrangThai { get => Status; set => Status = value; }

    
        [JsonIgnore] public DateTime NgayCham { get; set; }
        [JsonIgnore] public decimal SoGioLam { get; set; } = 0;
        [JsonIgnore] public decimal SoGioOT { get; set; } = 0;

    }
}
