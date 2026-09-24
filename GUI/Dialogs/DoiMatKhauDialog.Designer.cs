namespace VietLandHR.GUI.Dialogs
{
    partial class DoiMatKhauDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleBar   = new System.Windows.Forms.Panel();
            this.lblTitle   = new System.Windows.Forms.Label();
            this.pnlBody    = new System.Windows.Forms.Panel();
            this.lblOld     = new System.Windows.Forms.Label();
            this.txtOld     = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNew     = new System.Windows.Forms.Label();
            this.txtNew     = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLuu     = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy     = new Guna.UI2.WinForms.Guna2Button();

            this.titleBar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();

            // titleBar
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.titleBar.Controls.Add(this.lblTitle);
            this.titleBar.Dock   = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Height = 48;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);

            // lblTitle
            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(16, 12);
            this.lblTitle.Text      = "🔒  Đổi Mật Khẩu";

            // pnlBody
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlBody.Controls.Add(this.lblOld);
            this.pnlBody.Controls.Add(this.txtOld);
            this.pnlBody.Controls.Add(this.lblNew);
            this.pnlBody.Controls.Add(this.txtNew);
            this.pnlBody.Controls.Add(this.lblConfirm);
            this.pnlBody.Controls.Add(this.txtConfirm);
            this.pnlBody.Controls.Add(this.btnLuu);
            this.pnlBody.Controls.Add(this.btnHuy);

            // lblOld
            this.lblOld.AutoSize  = true;
            this.lblOld.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblOld.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblOld.Location  = new System.Drawing.Point(24, 20);
            this.lblOld.Text      = "Mật khẩu cũ";

            // txtOld
            this.txtOld.UseSystemPasswordChar = true;
            this.txtOld.PlaceholderText = "Nhập mật khẩu hiện tại...";
            this.txtOld.FillColor    = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtOld.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtOld.BorderColor  = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtOld.BorderRadius = 8;
            this.txtOld.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOld.Size         = new System.Drawing.Size(392, 38);
            this.txtOld.Location     = new System.Drawing.Point(24, 44);

            // lblNew
            this.lblNew.AutoSize  = true;
            this.lblNew.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNew.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNew.Location  = new System.Drawing.Point(24, 100);
            this.lblNew.Text      = "Mật khẩu mới";

            // txtNew
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.PlaceholderText = "Tối thiểu 6 ký tự...";
            this.txtNew.FillColor    = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtNew.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtNew.BorderColor  = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtNew.BorderRadius = 8;
            this.txtNew.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNew.Size         = new System.Drawing.Size(392, 38);
            this.txtNew.Location     = new System.Drawing.Point(24, 124);

            // lblConfirm
            this.lblConfirm.AutoSize  = true;
            this.lblConfirm.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConfirm.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblConfirm.Location  = new System.Drawing.Point(24, 180);
            this.lblConfirm.Text      = "Xác nhận mật khẩu mới";

            // txtConfirm
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.PlaceholderText = "Nhập lại mật khẩu mới...";
            this.txtConfirm.FillColor    = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtConfirm.ForeColor    = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtConfirm.BorderColor  = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtConfirm.BorderRadius = 8;
            this.txtConfirm.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirm.Size         = new System.Drawing.Size(392, 38);
            this.txtConfirm.Location     = new System.Drawing.Point(24, 204);

            // btnHuy
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.FillColor    = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnHuy.ForeColor    = System.Drawing.Color.White;
            this.btnHuy.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Location     = new System.Drawing.Point(24, 268);
            this.btnHuy.Size         = new System.Drawing.Size(110, 40);
            this.btnHuy.Text         = "Hủy";
            this.btnHuy.Click       += new System.EventHandler(this.BtnHuy_Click);

            // btnLuu
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.FillColor    = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLuu.ForeColor    = System.Drawing.Color.White;
            this.btnLuu.Font         = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location     = new System.Drawing.Point(260, 268);
            this.btnLuu.Size         = new System.Drawing.Size(156, 40);
            this.btnLuu.Text         = "💾  Lưu";
            this.btnLuu.Click       += new System.EventHandler(this.BtnLuu_Click);

            // DoiMatKhauDialog
            this.ClientSize       = new System.Drawing.Size(440, 360);
            this.BackColor        = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text             = "Đổi Mật Khẩu";

            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblOld;
        private Guna.UI2.WinForms.Guna2TextBox txtOld;
        private System.Windows.Forms.Label lblNew;
        private Guna.UI2.WinForms.Guna2TextBox txtNew;
        private System.Windows.Forms.Label lblConfirm;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirm;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}

