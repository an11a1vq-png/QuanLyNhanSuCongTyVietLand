using System.Threading.Tasks;
using System.Collections.Generic;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.BLL
{
    public class PositionBLL
    {
        private readonly PositionDAL _positionDAL = new PositionDAL();

        public Task<List<PositionDTO>> GetAllAsync() => _positionDAL.GetAllAsync();
        public Task<PositionDTO?> GetByIdAsync(int id) => _positionDAL.GetByIdAsync(id);

        public async Task<(bool Success, string Message)> CreateAsync(PositionDTO position)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được tạo chức vụ.");

            if (string.IsNullOrWhiteSpace(position.PositionName))
                return (false, "Tên chức vụ không được để trống.");

            if (position.BaseSalary < 0)
                return (false, "Lương cơ bản không hợp lệ.");

            await _positionDAL.CreateAsync(position);
            return (true, "Tạo chức vụ thành công.");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(PositionDTO position)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới được sửa chức vụ.");

            await _positionDAL.UpdateAsync(position);
            return (true, "Cập nhật thành công.");
        }
    }
}
