using System;
using System.Threading.Tasks;
using VietLandHR.BLL;

namespace VietLandHR.GUI.Helpers
{
    public static class EmailHelper
    {
        private static readonly EmailService _emailService = new EmailService();

        public static void SendEmailAsync(string toEmail, string subject, string bodyHtml, string toName = "Nhân viên")
        {
            if (string.IsNullOrWhiteSpace(toEmail) || !toEmail.Contains("@")) return;

            // Chạy ngầm để không đơ giao diện
            _ = Task.Run(async () =>
            {
                try
                {
                    await _emailService.SendEmailAsync(toEmail, toName, subject, bodyHtml);
                }
                catch
                {
                    // Lỗi gửi mail không ảnh hưởng đến luồng chính của ứng dụng
                }
            });
        }
    }
}

