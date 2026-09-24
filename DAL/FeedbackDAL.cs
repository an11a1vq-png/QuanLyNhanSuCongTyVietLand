using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DTOs;
using VietLandHR.Utils;
using Supabase.Postgrest.Exceptions;

namespace VietLandHR.DAL
{
    public class FeedbackDAL
    {
        public async Task<List<FeedbackDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<FeedbackDTO>()
                .Order("submit_date", Supabase.Postgrest.Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }

        public async Task<List<FeedbackDTO>> GetByEmployeeIdAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<FeedbackDTO>()
                .Where(x => x.EmployeeId == employeeId)
                .Order("submit_date", Supabase.Postgrest.Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }

        public async Task<(bool Success, string Message)> CreateAsync(FeedbackDTO feedback)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                await client.From<FeedbackDTO>().Insert(feedback);
                return (true, "Gửi góp ý thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi gửi góp ý: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> UpdateAsync(FeedbackDTO feedback)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                await client.From<FeedbackDTO>().Update(feedback);
                return (true, "Cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int feedbackId)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                await client.From<FeedbackDTO>().Where(x => x.FeedbackId == feedbackId).Delete();
                return (true, "Xóa góp ý thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xóa: " + ex.Message);
            }
        }
    }
}

