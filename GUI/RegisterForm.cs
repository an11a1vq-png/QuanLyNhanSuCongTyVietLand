using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;

namespace VietLandHR.GUI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void PnlLeft_Paint(object sender, PaintEventArgs e)
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnlLeft.ClientRectangle,
                Color.FromArgb(76, 46, 171),  // Tím Indigo đậm (#4C2EAB)
                Color.FromArgb(45, 76, 200),  // Xanh Cobalt (#2D4CC8)
                45f);                         // Góc chéo 45 độ mượt mà
            e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;

            string fullName = txtFullName.Text.Trim();
            string email    = txtEmail.Text.Trim();
            string phone    = txtPhone.Text.Trim();
            DateTime birthDate = dtpBirthDate.Value;
            string citizenId = txtCitizenId.Text.Trim();
            string gender    = cbGender.SelectedItem?.ToString() ?? "Nam";
            string address   = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(citizenId) || 
                string.IsNullOrWhiteSpace(address))
            {
                ShowMsg("⚠  Vui lòng điền đầy đủ tất cả thông tin.", Color.FromArgb(255, 170, 50));
                return;
            }

            // Kiểm tra định dạng Email chuẩn (phải có @ và tên miền ví dụ: name@gmail.com)
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowMsg("⚠ Email không hợp lệ. Vui lòng nhập đúng định dạng (VD: name@gmail.com).", Color.FromArgb(255, 170, 50));
                return;
            }

            // Kiểm tra số điện thoại: Phải bắt đầu bằng 0, đủ 10 số, chỉ chứa chữ số
            if (phone.Length != 10 || !phone.StartsWith("0") || !phone.All(char.IsDigit))
            {
                ShowMsg("⚠ Số điện thoại phải gồm đúng 10 chữ số, chỉ chứa số và bắt đầu bằng số 0.", Color.FromArgb(255, 170, 50));
                return;
            }

            // Kiểm tra số CCCD: Phải đủ 12 số, chỉ chứa chữ số
            if (citizenId.Length != 12 || !citizenId.All(char.IsDigit))
            {
                ShowMsg("⚠ Số CCCD phải gồm đúng 12 chữ số và không chứa chữ cái.", Color.FromArgb(255, 170, 50));
                return;
            }

            // Kiểm tra độ tuổi: Phải từ đủ 18 tuổi trở lên
            if (birthDate > DateTime.Today.AddYears(-18))
            {
                ShowMsg("⚠ Người đăng ký phải từ đủ 18 tuổi trở lên.", Color.FromArgb(255, 170, 50));
                return;
            }

            btnSubmit.Enabled = false;
            btnSubmit.Text = "⏳  ĐANG GỬI...";

            try
            {
                // Kiểm tra xem Email hoặc Số CCCD đã thuộc về Nhân viên đang hoạt động chưa
                var client = Utils.SupabaseClientManager.Instance.GetClient();
                var empCheck = await client.From<EmployeeDTO>()
                    .Filter("email", Supabase.Postgrest.Constants.Operator.Equals, email)
                    .Get();

                if (empCheck.Models.Any(e => e.Status == "Active" || e.Status == "Đang làm việc"))
                {
                    ShowMsg("⚠ Email này đã thuộc về Nhân viên đang hoạt động. Vui lòng Đăng nhập!", Color.FromArgb(255, 170, 50));
                    return;
                }

                var cccdCheck = await client.From<EmployeeDTO>()
                    .Filter("cccd", Supabase.Postgrest.Constants.Operator.Equals, citizenId)
                    .Get();

                if (cccdCheck.Models.Any())
                {
                    ShowMsg("⚠ Số CCCD này đã thuộc về Nhân viên khác trong hệ thống!", Color.FromArgb(255, 170, 50));
                    return;
                }

                // Lưu yêu cầu vào Supabase
                var dal = new DAL.RegistrationRequestDAL();
                var req = new RegistrationRequestDTO
                {
                    FullName          = fullName,
                    Email             = email,
                    Phone             = phone,
                    BirthDate         = DateTime.SpecifyKind(birthDate.Date, DateTimeKind.Utc),
                    Gender            = gender,
                    CitizenId         = citizenId,
                    Address           = address,
                    Status            = "Pending",
                    CreatedAt         = DateTime.UtcNow
                };
                await dal.CreateAsync(req);

                ShowMsg("✓  Yêu cầu đã gửi thành công! Admin sẽ duyệt.", Color.FromArgb(22, 163, 74));
                txtFullName.Clear(); txtEmail.Clear(); txtPhone.Clear(); txtCitizenId.Clear(); txtAddress.Clear();
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                if (errMsg.Contains("duplicate") || errMsg.Contains("23505"))
                    errMsg = "Email hoặc Số CCCD này đã được gửi yêu cầu đăng ký trước đó.";
                ShowMsg("✕ Lỗi: " + errMsg, Color.FromArgb(220, 38, 38));
                MessageBox.Show($"Lỗi gửi yêu cầu đăng ký:\n{ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSubmit.Enabled = true;
                btnSubmit.Text = "GỬI YÊU CẦU ĐĂNG KÝ";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void ShowMsg(string text, Color color)
        {
            lblMsg.Text = text;
            lblMsg.ForeColor = color;
            lblMsg.Visible = true;
        }
    }
}

