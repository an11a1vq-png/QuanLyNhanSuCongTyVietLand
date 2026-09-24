using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class LeaveRequestDAL
    {
        public async Task<List<LeaveRequestDTO>> GetByEmployeeAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<LeaveRequestDTO>()
                .Filter("employee_id", Constants.Operator.Equals, employeeId.ToString())
                .Order("start_date", Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }

        public async Task<List<LeaveRequestDTO>> GetPendingAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<LeaveRequestDTO>()
                .Filter("status", Constants.Operator.Equals, "Pending")
                .Get();
            return response.Models;
        }

        public async Task<LeaveRequestDTO> CreateAsync(LeaveRequestDTO leave)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<LeaveRequestDTO>().Insert(leave);
            return response.Models[0];
        }

        public async Task UpdateAsync(LeaveRequestDTO leave)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<LeaveRequestDTO>().Update(leave);
        }
    }
}
