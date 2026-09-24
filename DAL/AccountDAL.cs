using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class AccountDAL
    {
        // Khôi phục Supabase Auth
        public async Task<Supabase.Gotrue.Session> SignInAsync(string email, string password)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var session = await client.Auth.SignInWithPassword(email, password);
            if (session == null || session.User == null)
                throw new Exception("Email hoặc mật khẩu không đúng.");
            return session;
        }

        public async Task SignOutAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.Auth.SignOut();
        }

        public async Task<AccountDTO?> GetByUsernameAsync(string username)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AccountDTO>()
                .Filter("username", Constants.Operator.Equals, username)
                .Get();

            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<AccountDTO?> GetByIdAsync(int accountId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<AccountDTO>()
                .Filter("account_id", Constants.Operator.Equals, accountId.ToString())
                .Get();

            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<List<AccountDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<AccountDTO>().Get();
            return response.Models;
        }

        public async Task<AccountDTO> CreateAsync(AccountDTO account)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<AccountDTO>().Insert(account);
            return response.Models[0];
        }

        public async Task UpdateAsync(AccountDTO account)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<AccountDTO>().Update(account);
        }

        public async Task SetActiveStatusAsync(int accountId, bool isActive)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var account = await GetByIdAsync(accountId);
            if (account == null) return;
            account.IsActive = isActive;
            await client.From<AccountDTO>().Update(account);

            if (account.EmployeeId.HasValue)
            {
                var empRes = await client.From<EmployeeDTO>().Filter("employee_id", Constants.Operator.Equals, account.EmployeeId.Value.ToString()).Get();
                if (empRes.Models.Count > 0)
                {
                    var emp = empRes.Models[0];
                    emp.Status = isActive ? "Active" : "Inactive";
                    await client.From<EmployeeDTO>().Update(emp);
                }
            }
        }
    }
}
