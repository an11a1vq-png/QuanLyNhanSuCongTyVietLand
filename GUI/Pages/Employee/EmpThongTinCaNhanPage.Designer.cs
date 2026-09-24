namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpThongTinCaNhanPage
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.lblMaNVTitle = new System.Windows.Forms.Label();
            this.lblMaNVVal = new System.Windows.Forms.Label();
            this.lblHoTenTitle = new System.Windows.Forms.Label();
            this.lblHoTenVal = new System.Windows.Forms.Label();
            this.lblGioiTinhTitle = new System.Windows.Forms.Label();
            this.lblGioiTinhVal = new System.Windows.Forms.Label();
            this.lblNgaySinhTitle = new System.Windows.Forms.Label();
            this.lblNgaySinhVal = new System.Windows.Forms.Label();
            this.lblCCCDTitle = new System.Windows.Forms.Label();
            this.lblCCCDVal = new System.Windows.Forms.Label();
            this.lblSDTTitle = new System.Windows.Forms.Label();
            this.lblSDTVal = new System.Windows.Forms.Label();
            this.lblEmailTitle = new System.Windows.Forms.Label();
            this.lblEmailVal = new System.Windows.Forms.Label();
            this.lblDiaChiTitle = new System.Windows.Forms.Label();
            this.lblDiaChiVal = new System.Windows.Forms.Label();
            this.lblPhongBanTitle = new System.Windows.Forms.Label();
            this.lblPhongBanVal = new System.Windows.Forms.Label();
            this.lblChucVuTitle = new System.Windows.Forms.Label();
            this.lblChucVuVal = new System.Windows.Forms.Label();
            this.lblNgayVaoLamTitle = new System.Windows.Forms.Label();
            this.lblNgayVaoLamVal = new System.Windows.Forms.Label();
            this.lblLuongCoBanTitle = new System.Windows.Forms.Label();
            this.lblLuongCoBanVal = new System.Windows.Forms.Label();
            this.lblTrangThaiTitle = new System.Windows.Forms.Label();
            this.lblTrangThaiVal = new System.Windows.Forms.Label();

            this.btnDoiPass = new Guna.UI2.WinForms.Guna2Button();

            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.FillColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlMain.BorderRadius = 12;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblMaNVTitle);
            this.pnlMain.Controls.Add(this.lblMaNVVal);
            this.pnlMain.Controls.Add(this.lblHoTenTitle);
            this.pnlMain.Controls.Add(this.lblHoTenVal);
            this.pnlMain.Controls.Add(this.lblGioiTinhTitle);
            this.pnlMain.Controls.Add(this.lblGioiTinhVal);
            this.pnlMain.Controls.Add(this.lblNgaySinhTitle);
            this.pnlMain.Controls.Add(this.lblNgaySinhVal);
            this.pnlMain.Controls.Add(this.lblCCCDTitle);
            this.pnlMain.Controls.Add(this.lblCCCDVal);
            this.pnlMain.Controls.Add(this.lblSDTTitle);
            this.pnlMain.Controls.Add(this.lblSDTVal);
            this.pnlMain.Controls.Add(this.lblEmailTitle);
            this.pnlMain.Controls.Add(this.lblEmailVal);
            this.pnlMain.Controls.Add(this.lblDiaChiTitle);
            this.pnlMain.Controls.Add(this.lblDiaChiVal);
            this.pnlMain.Controls.Add(this.lblPhongBanTitle);
            this.pnlMain.Controls.Add(this.lblPhongBanVal);
            this.pnlMain.Controls.Add(this.lblChucVuTitle);
            this.pnlMain.Controls.Add(this.lblChucVuVal);
            this.pnlMain.Controls.Add(this.lblNgayVaoLamTitle);
            this.pnlMain.Controls.Add(this.lblNgayVaoLamVal);
            this.pnlMain.Controls.Add(this.lblLuongCoBanTitle);
            this.pnlMain.Controls.Add(this.lblLuongCoBanVal);
            this.pnlMain.Controls.Add(this.lblTrangThaiTitle);
            this.pnlMain.Controls.Add(this.lblTrangThaiVal);
            this.pnlMain.Controls.Add(this.btnDoiPass);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(1000, 700);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỒ SƠ CÁ NHÂN";

            // 1. Mã NV
            this.lblMaNVTitle.AutoSize = true;
            this.lblMaNVTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaNVTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMaNVTitle.Location = new System.Drawing.Point(30, 80);
            this.lblMaNVTitle.Text = "Mã NV:";
            this.lblMaNVVal.AutoSize = true;
            this.lblMaNVVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaNVVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblMaNVVal.Location = new System.Drawing.Point(230, 78);
            this.lblMaNVVal.Text = "—";

            // 2. Họ Tên
            this.lblHoTenTitle.AutoSize = true;
            this.lblHoTenTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHoTenTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblHoTenTitle.Location = new System.Drawing.Point(30, 120);
            this.lblHoTenTitle.Text = "Họ Tên:";
            this.lblHoTenVal.AutoSize = true;
            this.lblHoTenVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHoTenVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblHoTenVal.Location = new System.Drawing.Point(230, 118);
            this.lblHoTenVal.Text = "—";

            // 3. Giới Tính
            this.lblGioiTinhTitle.AutoSize = true;
            this.lblGioiTinhTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinhTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblGioiTinhTitle.Location = new System.Drawing.Point(30, 160);
            this.lblGioiTinhTitle.Text = "Giới Tính:";
            this.lblGioiTinhVal.AutoSize = true;
            this.lblGioiTinhVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinhVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGioiTinhVal.Location = new System.Drawing.Point(230, 158);
            this.lblGioiTinhVal.Text = "—";

            // 4. Ngày Sinh
            this.lblNgaySinhTitle.AutoSize = true;
            this.lblNgaySinhTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinhTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNgaySinhTitle.Location = new System.Drawing.Point(30, 200);
            this.lblNgaySinhTitle.Text = "Ngày Sinh:";
            this.lblNgaySinhVal.AutoSize = true;
            this.lblNgaySinhVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinhVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNgaySinhVal.Location = new System.Drawing.Point(230, 198);
            this.lblNgaySinhVal.Text = "—";

            // 5. CCCD
            this.lblCCCDTitle.AutoSize = true;
            this.lblCCCDTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCCCDTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCCCDTitle.Location = new System.Drawing.Point(30, 240);
            this.lblCCCDTitle.Text = "CCCD:";
            this.lblCCCDVal.AutoSize = true;
            this.lblCCCDVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCCCDVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblCCCDVal.Location = new System.Drawing.Point(230, 238);
            this.lblCCCDVal.Text = "—";

            // 6. SĐT
            this.lblSDTTitle.AutoSize = true;
            this.lblSDTTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSDTTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSDTTitle.Location = new System.Drawing.Point(30, 280);
            this.lblSDTTitle.Text = "SĐT:";
            this.lblSDTVal.AutoSize = true;
            this.lblSDTVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSDTVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSDTVal.Location = new System.Drawing.Point(230, 278);
            this.lblSDTVal.Text = "—";

            // 7. Email
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmailTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblEmailTitle.Location = new System.Drawing.Point(30, 320);
            this.lblEmailTitle.Text = "Email:";
            this.lblEmailVal.AutoSize = true;
            this.lblEmailVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmailVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblEmailVal.Location = new System.Drawing.Point(230, 318);
            this.lblEmailVal.Text = "—";

            // 8. Địa Chỉ
            this.lblDiaChiTitle.AutoSize = true;
            this.lblDiaChiTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiaChiTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDiaChiTitle.Location = new System.Drawing.Point(30, 360);
            this.lblDiaChiTitle.Text = "Địa Chỉ:";
            this.lblDiaChiVal.AutoSize = true;
            this.lblDiaChiVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiaChiVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDiaChiVal.Location = new System.Drawing.Point(230, 358);
            this.lblDiaChiVal.Text = "—";

            // 9. Phòng Ban
            this.lblPhongBanTitle.AutoSize = true;
            this.lblPhongBanTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPhongBanTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPhongBanTitle.Location = new System.Drawing.Point(30, 400);
            this.lblPhongBanTitle.Text = "Phòng Ban:";
            this.lblPhongBanVal.AutoSize = true;
            this.lblPhongBanVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhongBanVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPhongBanVal.Location = new System.Drawing.Point(230, 398);
            this.lblPhongBanVal.Text = "—";

            // 10. Chức Vụ
            this.lblChucVuTitle.AutoSize = true;
            this.lblChucVuTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblChucVuTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblChucVuTitle.Location = new System.Drawing.Point(30, 440);
            this.lblChucVuTitle.Text = "Chức Vụ:";
            this.lblChucVuVal.AutoSize = true;
            this.lblChucVuVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChucVuVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblChucVuVal.Location = new System.Drawing.Point(230, 438);
            this.lblChucVuVal.Text = "—";

            // 11. Ngày Vào Làm
            this.lblNgayVaoLamTitle.AutoSize = true;
            this.lblNgayVaoLamTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNgayVaoLamTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNgayVaoLamTitle.Location = new System.Drawing.Point(30, 480);
            this.lblNgayVaoLamTitle.Text = "Ngày Vào Làm:";
            this.lblNgayVaoLamVal.AutoSize = true;
            this.lblNgayVaoLamVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNgayVaoLamVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblNgayVaoLamVal.Location = new System.Drawing.Point(230, 478);
            this.lblNgayVaoLamVal.Text = "—";

            // 12. Mức Lương Căn Bản
            this.lblLuongCoBanTitle.AutoSize = true;
            this.lblLuongCoBanTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLuongCoBanTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblLuongCoBanTitle.Location = new System.Drawing.Point(30, 520);
            this.lblLuongCoBanTitle.Text = "Mức Lương Căn Bản:";
            this.lblLuongCoBanVal.AutoSize = true;
            this.lblLuongCoBanVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLuongCoBanVal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblLuongCoBanVal.Location = new System.Drawing.Point(230, 518);
            this.lblLuongCoBanVal.Text = "0 ₫";

            // 13. Trạng Thái
            this.lblTrangThaiTitle.AutoSize = true;
            this.lblTrangThaiTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTrangThaiTitle.Location = new System.Drawing.Point(30, 560);
            this.lblTrangThaiTitle.Text = "Trạng Thái:";
            this.lblTrangThaiVal.AutoSize = true;
            this.lblTrangThaiVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiVal.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblTrangThaiVal.Location = new System.Drawing.Point(230, 558);
            this.lblTrangThaiVal.Text = "Active";

            // 
            // btnDoiPass
            // 
            this.btnDoiPass.Animated = true;
            this.btnDoiPass.BorderRadius = 8;
            this.btnDoiPass.CustomizableEdges = customizableEdges1;
            this.btnDoiPass.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnDoiPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDoiPass.ForeColor = System.Drawing.Color.White;
            this.btnDoiPass.Location = new System.Drawing.Point(30, 610);
            this.btnDoiPass.Name = "btnDoiPass";
            this.btnDoiPass.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.btnDoiPass.Size = new System.Drawing.Size(180, 40);
            this.btnDoiPass.TabIndex = 27;
            this.btnDoiPass.Text = "🔒  Đổi Mật Khẩu";
            this.btnDoiPass.Click += new System.EventHandler(this.BtnDoiPass_Click);

            // 
            // EmpThongTinCaNhanPage
            // 
            this.BackColor = System.Drawing.Color.FromArgb(197, 210, 246);
            this.Controls.Add(this.pnlMain);
            this.Name = "EmpThongTinCaNhanPage";
            this.Size = new System.Drawing.Size(1000, 750);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblMaNVTitle;
        private System.Windows.Forms.Label lblMaNVVal;
        private System.Windows.Forms.Label lblHoTenTitle;
        private System.Windows.Forms.Label lblHoTenVal;
        private System.Windows.Forms.Label lblGioiTinhTitle;
        private System.Windows.Forms.Label lblGioiTinhVal;
        private System.Windows.Forms.Label lblNgaySinhTitle;
        private System.Windows.Forms.Label lblNgaySinhVal;
        private System.Windows.Forms.Label lblCCCDTitle;
        private System.Windows.Forms.Label lblCCCDVal;
        private System.Windows.Forms.Label lblSDTTitle;
        private System.Windows.Forms.Label lblSDTVal;
        private System.Windows.Forms.Label lblEmailTitle;
        private System.Windows.Forms.Label lblEmailVal;
        private System.Windows.Forms.Label lblDiaChiTitle;
        private System.Windows.Forms.Label lblDiaChiVal;
        private System.Windows.Forms.Label lblPhongBanTitle;
        private System.Windows.Forms.Label lblPhongBanVal;
        private System.Windows.Forms.Label lblChucVuTitle;
        private System.Windows.Forms.Label lblChucVuVal;
        private System.Windows.Forms.Label lblNgayVaoLamTitle;
        private System.Windows.Forms.Label lblNgayVaoLamVal;
        private System.Windows.Forms.Label lblLuongCoBanTitle;
        private System.Windows.Forms.Label lblLuongCoBanVal;
        private System.Windows.Forms.Label lblTrangThaiTitle;
        private System.Windows.Forms.Label lblTrangThaiVal;

        private Guna.UI2.WinForms.Guna2Button btnDoiPass;
    }
}

