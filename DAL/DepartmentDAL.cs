using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class DepartmentDAL
    {
        public async Task<List<DepartmentDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<DepartmentDTO>().Get();
            return response.Models;
        }

        public async Task<DepartmentDTO?> GetByIdAsync(int departmentId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<DepartmentDTO>()
                .Filter("department_id", Constants.Operator.Equals, departmentId.ToString())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<DepartmentDTO> CreateAsync(DepartmentDTO department)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<DepartmentDTO>().Insert(department);
            return response.Models[0];
        }

        public async Task UpdateAsync(DepartmentDTO department)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<DepartmentDTO>().Update(department);
        }

        public async Task DeleteAsync(int departmentId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client
                .From<DepartmentDTO>()
                .Filter("department_id", Constants.Operator.Equals, departmentId.ToString())
                .Delete();
        }
    }
}
