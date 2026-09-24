using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class RoleDAL
    {
        public async Task<List<RoleDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<RoleDTO>().Get();
            return response.Models;
        }

        public async Task<RoleDTO?> GetByIdAsync(int roleId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<RoleDTO>()
                .Filter("role_id", Constants.Operator.Equals, roleId.ToString())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }
    }
}
