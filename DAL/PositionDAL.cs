using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class PositionDAL
    {
        public async Task<List<PositionDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<PositionDTO>().Get();
            return response.Models;
        }

        public async Task<PositionDTO?> GetByIdAsync(int positionId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<PositionDTO>()
                .Filter("position_id", Constants.Operator.Equals, positionId.ToString())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<PositionDTO> CreateAsync(PositionDTO position)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<PositionDTO>().Insert(position);
            return response.Models[0];
        }

        public async Task UpdateAsync(PositionDTO position)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<PositionDTO>().Update(position);
        }

        public async Task DeleteAsync(int positionId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client
                .From<PositionDTO>()
                .Filter("position_id", Constants.Operator.Equals, positionId.ToString())
                .Delete();
        }
    }
}
