using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Helpers;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;

namespace VietLandHR.GUI.Dialogs
{
    public partial class GopYDialog : Form
    {
        private readonly FeedbackBLL _service = new();
        private readonly FeedbackDTO _gy;

        public GopYDialog(FeedbackDTO gy)
        {
            _gy = gy;
            InitializeComponent();
            
            lblNguoiGui.Text = $"Người gửi: {_gy.TenNhanVien ?? _gy.MaNV} ({_gy.EmailNhanVien ?? "Không có email"})";
            lblNgayGui.Text = $"Ngày gửi: {FormatDateTime(_gy.SubmitDate)}";
            lblTieuDe.Text = $"Tiêu đề: {_gy.Title}";
            lblNoiDung.Text = _gy.Content;
            
            UIHelper.ApplyLightBackground(this);
            
            LoadData();
        }

        private void LoadData()
        {
            if (_gy.Status == "Đã phản hồi")
            {
                txtPhanHoi.Text = _gy.ReplyContent;
                txtPhanHoi.ReadOnly = true;
                btnLuu.Visible = false;
            }
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhanHoi.Text))
            {
                MessageBox.Show("Vui lòng nhập phản hồi.");
                return;
            }

            try
            {
                var adminEmpId = SessionManager.CurrentAccount?.EmployeeId ?? SessionManager.CurrentEmployee?.EmployeeId;
                var adminName = SessionManager.CurrentAccount?.Username ?? "Admin";
                var res = await _service.ReplyAsync(_gy.FeedbackId, txtPhanHoi.Text.Trim(), adminEmpId);
                
                if (!res.Success)
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gửi email
                if (!string.IsNullOrEmpty(_gy.EmailNhanVien))
                {
                    string subject = $"Phản hồi góp ý: {_gy.Title}";
                    string body = $"Chào {_gy.TenNhanVien ?? "bạn"},\n\nPhản hồi từ Admin ({adminName}):\n{txtPhanHoi.Text.Trim()}\n\nTrân trọng,\nVietLand HR";
                    EmailHelper.SendEmailAsync(_gy.EmailNhanVien, subject, body, _gy.TenNhanVien ?? "Nhân viên");
                    MessageBox.Show("Đã lưu phản hồi và gửi email thông báo!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã lưu phản hồi. Nhân viên này không có email nên không thể gửi thông báo.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(UIHelper.DarkBorder, 1.5f), 0, 0, Width - 1, Height - 1);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void TitleBar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        private static string FormatDateTime(DateTime? dt)
        {
            if (!dt.HasValue || dt.Value == DateTime.MinValue) return "—";
            DateTime d = dt.Value;
            DateTime local = d.Kind == DateTimeKind.Utc ? d.ToLocalTime() : d;

            if (local.Hour >= 19 && local.Hour <= 23)
            {
                local = local.AddHours(-7);
            }

            return local.ToString("dd/MM/yyyy HH:mm");
        }
    }
}

