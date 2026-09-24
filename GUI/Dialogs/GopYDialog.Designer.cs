namespace VietLandHR.GUI.Dialogs
{
    partial class GopYDialog
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblNguoiGui = new System.Windows.Forms.Label();
            this.lblNgayGui = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblPhanHoi = new System.Windows.Forms.Label();
            this.txtPhanHoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            
            this.titleBar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            
            // titleBar
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.titleBar.Controls.Add(this.lblTitle);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Height = 40;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Text = "CHI TIẾT GÓP Ý";
            
            // pnlBody
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBody.Controls.Add(this.lblNguoiGui);
            this.pnlBody.Controls.Add(this.lblNgayGui);
            this.pnlBody.Controls.Add(this.lblTieuDe);
            this.pnlBody.Controls.Add(this.lblNoiDung);
            this.pnlBody.Controls.Add(this.lblPhanHoi);
            this.pnlBody.Controls.Add(this.txtPhanHoi);
            this.pnlBody.Controls.Add(this.btnLuu);
            this.pnlBody.Controls.Add(this.btnHuy);
            
            // lblNguoiGui
            this.lblNguoiGui.AutoSize = true;
            this.lblNguoiGui.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiGui.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNguoiGui.Location = new System.Drawing.Point(20, 20);
            this.lblNguoiGui.Text = "Người gửi:";
            
            // lblNgayGui
            this.lblNgayGui.AutoSize = true;
            this.lblNgayGui.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgayGui.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNgayGui.Location = new System.Drawing.Point(20, 50);
            this.lblNgayGui.Text = "Ngày gửi:";
            
            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 80);
            this.lblTieuDe.Text = "Tiêu đề:";
            
            // lblNoiDung
            this.lblNoiDung.AutoSize = false;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNoiDung.Location = new System.Drawing.Point(20, 110);
            this.lblNoiDung.Size = new System.Drawing.Size(560, 100);
            
            // lblPhanHoi
            this.lblPhanHoi.AutoSize = true;
            this.lblPhanHoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhanHoi.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPhanHoi.Location = new System.Drawing.Point(20, 220);
            this.lblPhanHoi.Text = "Nội dung phản hồi:";
            
            // txtPhanHoi
            this.txtPhanHoi.Multiline = true;
            this.txtPhanHoi.Location = new System.Drawing.Point(20, 250);
            this.txtPhanHoi.Size = new System.Drawing.Size(560, 120);
            this.txtPhanHoi.FillColor = System.Drawing.Color.White;
            this.txtPhanHoi.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtPhanHoi.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            
            // btnLuu
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(340, 390);
            this.btnLuu.Size = new System.Drawing.Size(130, 40);
            this.btnLuu.Text = "Gửi Phản Hồi";
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            
            // btnHuy
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(480, 390);
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.Text = "Đóng";
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            
            // GopYDialog
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Góp ý";
            
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblNguoiGui;
        private System.Windows.Forms.Label lblNgayGui;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblPhanHoi;
        private Guna.UI2.WinForms.Guna2TextBox txtPhanHoi;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}

