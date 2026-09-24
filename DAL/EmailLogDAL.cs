using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class EmailLogDAL
    {
        public async Task<List<EmailLogDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<EmailLogDTO>().Get();
            return response.Models;
        }

        public async Task<EmailLogDTO> CreateAsync(EmailLogDTO log)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<EmailLogDTO>().Insert(log);
            return response.Models[0];
        }
    }
}
