using System.Threading.Tasks;
using System.Collections.Generic;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL _departmentDAL = new DepartmentDAL();

        public Task<List<DepartmentDTO>> GetAllAsync() => _departmentDAL.GetAllAsync();
        public Task<DepartmentDTO?> GetByIdAsync(int id) => _departmentDAL.GetByIdAsync(id);

        public async Task<(bool Success, string Message)> CreateAsync(DepartmentDTO department)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được tạo phòng ban.");

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
                return (false, "Tên phòng ban không được để trống.");

            await _departmentDAL.CreateAsync(department);
            return (true, "Tạo phòng ban thành công.");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(DepartmentDTO department)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được sửa phòng ban.");

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
                return (false, "Tên phòng ban không được để trống.");

            await _departmentDAL.UpdateAsync(department);
            return (true, "Cập nhật thành công.");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int departmentId)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được xóa phòng ban.");

            await _departmentDAL.DeleteAsync(departmentId);
            return (true, "Xóa phòng ban thành công.");
        }
    
        public async Task<List<DepartmentDTO>> LayDanhSachPhongBanAsync() => await GetAllAsync();
        public async Task<(bool, string)> InsertAsync(DepartmentDTO dto) => await CreateAsync(dto);

    }
}
