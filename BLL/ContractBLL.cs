using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VietLandHR.DTOs;
using VietLandHR.DAL;

namespace VietLandHR.BLL
{
    public class ContractBLL
    {
        private readonly ContractDAL _dal = new ContractDAL();
        private readonly EmployeeDAL _empDal = new EmployeeDAL();

        public async Task<List<ContractDTO>> GetAllAsync()
        {
            var contracts = await _dal.GetAllAsync();
            var employees = await _empDal.GetAllAsync();

            // Map MaNV for UI compatibility
            foreach (var c in contracts)
            {
                var emp = employees.FirstOrDefault(e => e.EmployeeId == c.EmployeeId);
                if (emp != null)
                {
                    c.MaNV = emp.EmployeeCode;
                    c.HoTen = emp.FullName;
                }
            }
            return contracts;
        }

        public async Task<List<ContractDTO>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _dal.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<(bool Success, string Message)> CreateAsync(ContractDTO contract)
        {
            if (string.IsNullOrWhiteSpace(contract.ContractCode))
                return (false, "Mã hợp đồng không được để trống.");

            if (contract.EmployeeId <= 0)
                return (false, "Vui lòng chọn nhân viên.");

            // 0. Chặn trùng Mã hợp đồng (ContractCode)
            var allContracts = await _dal.GetAllAsync();
            if (allContracts.Any(c => c.ContractCode.Equals(contract.ContractCode.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                return (false, $"Mã hợp đồng '{contract.ContractCode}' đã tồn tại trong hệ thống. Vui lòng nhập Mã HĐ khác!");
            }

            // 1. Tự động chuyển Hợp đồng cũ sang Expired
            var existingContracts = await _dal.GetByEmployeeIdAsync(contract.EmployeeId);
            var activeContracts = existingContracts.Where(x => x.Status == "Active").ToList();
            
            foreach (var oldContract in activeContracts)
            {
                oldContract.Status = "Expired";
                await _dal.UpdateAsync(oldContract);
            }

            // 2. Tạo Hợp đồng mới
            contract.Status = "Active";
            var result = await _dal.CreateAsync(contract);
            if (!result.Success) return result;

            // 3. Tự động chốt lương: Update BaseSalary cho Employee
            if (contract.Salary.HasValue)
            {
                var employeeList = await _empDal.GetAllAsync();
                var employee = employeeList.FirstOrDefault(e => e.EmployeeId == contract.EmployeeId);
                if (employee != null)
                {
                    employee.BaseSalary = contract.Salary.Value;
                    await _empDal.UpdateAsync(employee);
                }
            }

            return (true, "Thêm hợp đồng và cập nhật lương thành công.");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(ContractDTO contract)
        {
            if (string.IsNullOrWhiteSpace(contract.ContractCode))
                return (false, "Mã hợp đồng không được để trống.");

            var result = await _dal.UpdateAsync(contract);
            if (!result.Success) return result;

            // Tự động đồng bộ Mức lương mới vào Hồ sơ Nhân viên
            if (contract.Salary.HasValue)
            {
                var employeeList = await _empDal.GetAllAsync();
                var employee = employeeList.FirstOrDefault(e => e.EmployeeId == contract.EmployeeId);
                if (employee != null)
                {
                    employee.BaseSalary = contract.Salary.Value;
                    await _empDal.UpdateAsync(employee);
                }
            }

            return (true, "Cập nhật hợp đồng và đồng bộ lương thành công.");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int contractId)
        {
            return await _dal.DeleteAsync(contractId);
        }
    }
}

