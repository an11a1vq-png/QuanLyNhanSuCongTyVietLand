using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class AttendanceDAL
    {
        public async Task<AttendanceDTO?> GetByIdAsync(int attendanceId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AttendanceDTO>()
                .Filter("attendance_id", Constants.Operator.Equals, attendanceId.ToString())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<List<AttendanceDTO>> GetByEmployeeAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AttendanceDTO>()
                .Filter("employee_id", Constants.Operator.Equals, employeeId.ToString())
                .Order("work_date", Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }

        public async Task<AttendanceDTO?> GetByEmployeeAndDateAsync(int employeeId, DateTime workDate)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AttendanceDTO>()
                .Filter("employee_id", Constants.Operator.Equals, employeeId.ToString())
                .Filter("work_date", Constants.Operator.Equals, workDate.ToString("yyyy-MM-dd"))
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<AttendanceDTO> CreateAsync(AttendanceDTO attendance)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<AttendanceDTO>().Insert(attendance);
            return response.Models[0];
        }

        public async Task UpdateAsync(AttendanceDTO attendance)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<AttendanceDTO>().Update(attendance);
        }

        public async Task DeleteAsync(int attendanceId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<AttendanceDTO>()
                .Filter("attendance_id", Constants.Operator.Equals, attendanceId.ToString())
                .Delete();
        }

        public async Task<List<AttendanceDTO>> GetByDateAsync(DateTime workDate)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AttendanceDTO>()
                .Filter("work_date", Constants.Operator.Equals, workDate.ToString("yyyy-MM-dd"))
                .Get();
            return response.Models;
        }

        public async Task<List<AttendanceDTO>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AttendanceDTO>()
                .Filter("work_date", Constants.Operator.GreaterThanOrEqual, fromDate.ToString("yyyy-MM-dd"))
                .Filter("work_date", Constants.Operator.LessThanOrEqual, toDate.ToString("yyyy-MM-dd"))
                .Order("work_date", Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }
    }
}
