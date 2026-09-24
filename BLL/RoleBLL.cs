using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;

namespace VietLandHR.BLL
{
    // Roles gần như không đổi (chỉ 3 dòng cố định) - BLL chỉ forward xuống DAL để giữ nguyên tắc kiến trúc
    public class RoleBLL
    {
        private readonly RoleDAL _roleDAL = new RoleDAL();

        public Task<List<RoleDTO>> GetAllAsync() => _roleDAL.GetAllAsync();
        public Task<RoleDTO?> GetByIdAsync(int roleId) => _roleDAL.GetByIdAsync(roleId);
    }
}
