using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.DAL
{
    public class EmployeeDAL
    {
        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<EmployeeDTO>().Get();
            return response.Models;
        }

        public async Task<EmployeeDTO?> GetByIdAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<EmployeeDTO>()
                .Filter("employee_id", Constants.Operator.Equals, employeeId.ToString())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<EmployeeDTO?> GetByEmployeeCodeAsync(string employeeCode)
        {
            if (string.IsNullOrWhiteSpace(employeeCode)) return null;
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<EmployeeDTO>()
                .Filter("employee_code", Constants.Operator.Equals, employeeCode.Trim())
                .Get();
            return response.Models.Count > 0 ? response.Models[0] : null;
        }

        public async Task<List<EmployeeDTO>> GetByDepartmentAsync(int departmentId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<EmployeeDTO>()
                .Filter("department_id", Constants.Operator.Equals, departmentId.ToString())
                .Get();
            return response.Models;
        }

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO employee)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client.From<EmployeeDTO>().Insert(employee);
            return response.Models[0];
        }

        public async Task UpdateAsync(EmployeeDTO employee)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<EmployeeDTO>().Update(employee);
        }

        // Không xóa cứng nhân viên - chỉ đổi status để giữ lịch sử chấm công/lương
        public async Task SetStatusAsync(int employeeId, string status)
        {
            var employee = await GetByIdAsync(employeeId);
            if (employee == null) return;
            employee.Status = status;
            var client = SupabaseClientManager.Instance.GetClient();
            await client.From<EmployeeDTO>().Update(employee);
        }

        public async Task<string?> GetMaxEmployeeCodeAsync()
        {
            var client = SupabaseClientManager.Instance.GetClient();
            var response = await client
                .From<EmployeeDTO>()
                .Select("employee_code")
                .Order("employee_id", Constants.Ordering.Descending)
                .Limit(1)
                .Get();
            
            return response.Models.Count > 0 ? response.Models[0].EmployeeCode : null;
        }

        // Dùng để rollback khi phê duyệt thất bại - xóa hẳn record
        public async Task DeleteAsync(int employeeId)
        {
            await DeleteCascadeAsync(employeeId);
        }

        // Xóa cứng nhân viên kèm xóa liên hoàn (Cascade Delete) các bản ghi liên quan trong CSDL
        public async Task DeleteCascadeAsync(int employeeId)
        {
            var client = SupabaseClientManager.Instance.GetClient();
            string empIdStr = employeeId.ToString();

            try { await client.From<AccountDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<ContractDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<AttendanceDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<PayrollDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<LeaveRequestDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<FeedbackDTO>().Filter("employee_id", Constants.Operator.Equals, empIdStr).Delete(); } catch { }
            try { await client.From<RegistrationRequestDTO>().Filter("reviewed_by", Constants.Operator.Equals, empIdStr).Delete(); } catch { }

            // Gỡ Trưởng phòng khỏi bảng departments nếu nhân viên bị xóa đang làm Trưởng phòng
            try
            {
                var depts = await client.From<DepartmentDTO>().Filter("manager_id", Constants.Operator.Equals, empIdStr).Get();
                foreach (var d in depts.Models)
                {
                    d.ManagerId = null;
                    await client.From<DepartmentDTO>().Update(d);
                }
            }
            catch { }

            await client
                .From<EmployeeDTO>()
                .Filter("employee_id", Constants.Operator.Equals, empIdStr)
                .Delete();
        }
    }
}
