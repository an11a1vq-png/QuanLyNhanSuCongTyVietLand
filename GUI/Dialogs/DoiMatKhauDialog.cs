using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Dialogs
{
    public partial class DoiMatKhauDialog : Form
    {
        public DoiMatKhauDialog()
        {
            InitializeComponent();
            UIHelper.ApplyLightBackground(this);
            this.KeyPreview = true;
            this.KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNew.Text) || txtNew.Text.Trim().Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLuu.Enabled = false;
            btnLuu.Text    = "Đang xử lý...";

            try
            {
                var bll = new AccountBLL();
                var (success, message) = await bll.ChangePasswordAsync(
                    txtOld.Text,
                    txtNew.Text,
                    txtConfirm.Text
                );

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                btnLuu.Enabled = true;
                btnLuu.Text    = "💾  Lưu";
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
    }
}

