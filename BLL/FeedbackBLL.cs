using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VietLandHR.DTOs;
using VietLandHR.DAL;

namespace VietLandHR.BLL
{
    public class FeedbackBLL
    {
        private readonly FeedbackDAL _dal = new FeedbackDAL();
        private readonly EmployeeDAL _empDal = new EmployeeDAL();

        private async Task MapEmployeeInfoAsync(List<FeedbackDTO> list)
        {
            var employees = await _empDal.GetAllAsync();
            foreach (var item in list)
            {
                var emp = employees.FirstOrDefault(e => e.EmployeeId == item.EmployeeId);
                if (emp != null)
                {
                    item.MaNV = emp.EmployeeCode;
                    item.TenNhanVien = emp.FullName;
                    item.EmailNhanVien = emp.Email;
                }
            }
        }

        public async Task<List<FeedbackDTO>> GetAllAsync()
        {
            var list = await _dal.GetAllAsync();
            await MapEmployeeInfoAsync(list);
            return list;
        }

        public async Task<List<FeedbackDTO>> GetByEmployeeIdAsync(int employeeId)
        {
            var list = await _dal.GetByEmployeeIdAsync(employeeId);
            await MapEmployeeInfoAsync(list);
            return list;
        }

        public async Task<(bool Success, string Message)> CreateAsync(int employeeId, string title, string content)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
                return (false, "Vui lòng nhập đầy đủ tiêu đề và nội dung.");

            // Generate unique code
            string code = "GY" + DateTime.Now.ToString("yyMMddHHmmss");

            var feedback = new FeedbackDTO
            {
                FeedbackCode = code,
                EmployeeId = employeeId,
                Title = title,
                Content = content,
                SubmitDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), // UTC for Supabase
                Status = "Chờ phản hồi"
            };

            return await _dal.CreateAsync(feedback);
        }

        public async Task<(bool Success, string Message)> ReplyAsync(int feedbackId, string replyContent, int? repliedByEmpId)
        {
            if (string.IsNullOrWhiteSpace(replyContent))
                return (false, "Nội dung phản hồi không được để trống.");

            var all = await _dal.GetAllAsync();
            var fb = all.FirstOrDefault(x => x.FeedbackId == feedbackId);
            if (fb == null) return (false, "Không tìm thấy góp ý này.");

            fb.ReplyContent = replyContent;
            fb.RepliedBy = repliedByEmpId;
            fb.RepliedAt = DateTime.UtcNow;
            fb.Status = "Đã phản hồi";
            
            // Supabase postgrest-csharp mapping hack - preserve UTC
            if (fb.SubmitDate.Kind == DateTimeKind.Local)
                fb.SubmitDate = DateTime.SpecifyKind(fb.SubmitDate, DateTimeKind.Utc);

            return await _dal.UpdateAsync(fb);
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int feedbackId)
        {
            return await _dal.DeleteAsync(feedbackId);
        }
    }
}

