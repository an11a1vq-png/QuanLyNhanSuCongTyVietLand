using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class RegistrationRequestDAL
    {
        public async Task<List<RegistrationRequestDTO>> GetPendingAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<RegistrationRequestDTO>()
                .Filter("status", Constants.Operator.Equals, "Pending")
                .Order("created_at", Constants.Ordering.Ascending)
                .Get();
            return response.Models;
        }

        public async Task<RegistrationRequestDTO> CreateAsync(RegistrationRequestDTO req)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var existing = await client.From<RegistrationRequestDTO>()
                .Filter("email", Constants.Operator.Equals, req.Email)
                .Get();

            if (existing.Models.Count > 0)
            {
                var item = existing.Models[0];
                item.FullName = req.FullName;
                item.Phone = req.Phone;
                item.BirthDate = req.BirthDate;
                item.Gender = req.Gender;
                item.CitizenId = req.CitizenId;
                item.Address = req.Address;
                item.Status = "Pending";
                item.ReviewedBy = null;
                item.ReviewedAt = null;
                item.CreatedAt = req.CreatedAt;
                await client.From<RegistrationRequestDTO>().Update(item);
                return item;
            }

            if (req.RegistrationId <= 0)
            {
                var allReqs = await client.From<RegistrationRequestDTO>().Get();
                int maxId = allReqs.Models.Any() ? allReqs.Models.Max(r => r.RegistrationId) : 0;
                req.RegistrationId = maxId + 1;
            }

            var response = await client.From<RegistrationRequestDTO>().Insert(req);
            return response.Models[0];
        }

        public async Task UpdateAsync(RegistrationRequestDTO req)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<RegistrationRequestDTO>().Update(req);
        }
    }
}

