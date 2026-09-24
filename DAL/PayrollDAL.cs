using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class PayrollDAL
    {
        public async Task<List<PayrollDTO>> GetByEmployeeAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<PayrollDTO>()
                .Filter("employee_id", Constants.Operator.Equals, employeeId.ToString())
                .Order("year", Constants.Ordering.Descending)
                .Order("month", Constants.Ordering.Descending)
                .Get();
            return response.Models;
        }

        public async Task<PayrollDTO> CreateAsync(PayrollDTO payroll)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<PayrollDTO>().Insert(payroll);
            return response.Models[0];
        }

        public async Task UpdateAsync(PayrollDTO payroll)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<PayrollDTO>().Update(payroll);
        }

        public async Task<List<PayrollDTO>> GetByMonthYearAsync(int month, int year)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<PayrollDTO>()
                .Filter("month", Constants.Operator.Equals, month.ToString())
                .Filter("year", Constants.Operator.Equals, year.ToString())
                .Get();
            return response.Models;
        }

        public async Task DeleteByMonthYearAsync(int month, int year)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client
                .From<PayrollDTO>()
                .Filter("month", Constants.Operator.Equals, month.ToString())
                .Filter("year", Constants.Operator.Equals, year.ToString())
                .Delete();
        }

        public async Task CreateMultipleAsync(List<PayrollDTO> payrolls)
        {
            if (payrolls == null || payrolls.Count == 0) return;
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<PayrollDTO>().Insert(payrolls);
        }
    }
}
