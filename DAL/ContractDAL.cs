using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DTOs;
using VietLandHR.Utils;
using Supabase.Postgrest.Exceptions;

namespace VietLandHR.DAL
{
    public class ContractDAL
    {
        public async Task<List<ContractDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<ContractDTO>().Get();
            return response.Models;
        }

        public async Task<List<ContractDTO>> GetByEmployeeIdAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<ContractDTO>()
                .Where(x => x.EmployeeId == employeeId)
                .Get();
            return response.Models;
        }

        public async Task<(bool Success, string Message)> CreateAsync(ContractDTO contract)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();

                // Tự tính ContractId = Max + 1 để tránh lỗi sequence CSDL
                if (contract.ContractId <= 0)
                {
                    var all = await client.From<ContractDTO>().Get();
                    int maxId = all.Models.Any() ? all.Models.Max(c => c.ContractId) : 0;
                    contract.ContractId = maxId + 1;
                }

                await client.From<ContractDTO>().Insert(contract);
                return (true, "Tạo hợp đồng thành công.");
            }
            catch (PostgrestException ex)
            {
                if (ex.Message.Contains("contracts_contract_code_key") || ex.Message.Contains("duplicate key"))
                    return (false, "Mã hợp đồng đã tồn tại.");
                if (ex.Message.Contains("row-level security") || ex.Message.Contains("42501"))
                    return (false, "Lỗi phân quyền CSDL (RLS): Bảng 'contracts' trên Supabase chưa mở quyền INSERT. Vui lòng chạy lệnh 'ALTER TABLE contracts DISABLE ROW LEVEL SECURITY;' trên Supabase SQL Editor.");
                return (false, "Lỗi tạo hợp đồng: " + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("row-level security") || ex.Message.Contains("42501"))
                    return (false, "Lỗi phân quyền CSDL (RLS): Bảng 'contracts' trên Supabase chưa mở quyền INSERT. Vui lòng chạy lệnh 'ALTER TABLE contracts DISABLE ROW LEVEL SECURITY;' trên Supabase SQL Editor.");
                return (false, "Lỗi tạo hợp đồng: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> UpdateAsync(ContractDTO contract)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                await client.From<ContractDTO>().Update(contract);
                return (true, "Cập nhật hợp đồng thành công.");
            }
            catch (PostgrestException ex)
            {
                if (ex.Message.Contains("contracts_contract_code_key") || ex.Message.Contains("duplicate key"))
                    return (false, "Mã hợp đồng đã tồn tại.");
                return (false, "Lỗi cập nhật: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi cập nhật: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int contractId)
        {
            try
            {
                var client = SupabaseClientManager.Instance.GetClient();
                await client.From<ContractDTO>().Where(x => x.ContractId == contractId).Delete();
                return (true, "Xóa hợp đồng thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi xóa hợp đồng: " + ex.Message);
            }
        }
    }
}

