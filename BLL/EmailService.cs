using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace VietLandHR.BLL
{
    public class EmailService
    {
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "vietlandcompany8@gmail.com";
        private const string SENDER_NAME = "VietLand_Company";
        private const string APP_PASSWORD = "twgv bnzx atzb pfik\n"; // Thường nên lưu trong config/env, tạm thời hardcode theo yêu cầu

        public async Task SendEmailAsync(string toEmail, string toName, string subject, string bodyText)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                return; // Không gửi nếu không có email

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(SENDER_NAME, SENDER_EMAIL));
            message.To.Add(new MailboxAddress(toName ?? "Nhân viên", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = bodyText
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(SMTP_SERVER, SMTP_PORT, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(SENDER_EMAIL, APP_PASSWORD.Replace(" ", "")); // Bỏ khoảng trắng nếu có
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}

