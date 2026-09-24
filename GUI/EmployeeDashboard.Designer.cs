namespace VietLandHR.GUI
{
    partial class EmployeeDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleBar       = new System.Windows.Forms.Panel();
            this.lblAppName     = new System.Windows.Forms.Label();
            this.lblUserInfo    = new System.Windows.Forms.Label();
            this.btnMin         = new Guna.UI2.WinForms.Guna2Button();
            this.btnMax         = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose       = new Guna.UI2.WinForms.Guna2Button();
            this.sidebar        = new Guna.UI2.WinForms.Guna2Panel();
            this.sidebarFlow    = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSidebarUser = new System.Windows.Forms.Label();
            this.btnChamCong    = new Guna.UI2.WinForms.Guna2Button();
            this.btnNghiPhep    = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuong       = new Guna.UI2.WinForms.Guna2Button();
            this.btnHopDong     = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongTin    = new Guna.UI2.WinForms.Guna2Button();
            this.btnGopY        = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout      = new Guna.UI2.WinForms.Guna2Button();
            this.contentArea    = new System.Windows.Forms.Panel();

            this.titleBar.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.sidebarFlow.SuspendLayout();
            this.SuspendLayout();

            // titleBar
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(197, 210, 246);
            this.titleBar.Controls.Add(this.lblAppName);
            this.titleBar.Controls.Add(this.lblUserInfo);
            this.titleBar.Controls.Add(this.btnMin);
            this.titleBar.Controls.Add(this.btnMax);
            this.titleBar.Controls.Add(this.btnClose);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1100, 50);
            this.titleBar.TabIndex = 0;

            // lblAppName
            this.lblAppName.Text = "🏢  Vietland HR — Nhân viên";
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(15, 13);

            // lblUserInfo
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUserInfo.Location = new System.Drawing.Point(750, 16);

            // btnMin
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BorderRadius = 8;
            this.btnMin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMin.FillColor = System.Drawing.Color.Transparent;
            this.btnMin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMin.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnMin.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnMin.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnMin.Location = new System.Drawing.Point(972, 7);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(36, 36);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "—";
            this.btnMin.Click += new System.EventHandler(this.BtnMin_Click);

            // btnMax
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BorderRadius = 8;
            this.btnMax.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMax.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMax.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMax.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMax.FillColor = System.Drawing.Color.Transparent;
            this.btnMax.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMax.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnMax.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnMax.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnMax.Location = new System.Drawing.Point(1012, 7);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(36, 36);
            this.btnMax.TabIndex = 3;
            this.btnMax.Text = "◻";
            this.btnMax.Click += new System.EventHandler(this.BtnMax_Click);

            // btnClose
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 8;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1052, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // sidebar
            this.sidebar.FillColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Width = 240;
            this.sidebar.Controls.Add(this.sidebarFlow);

            // sidebarFlow
            this.sidebarFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebarFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebarFlow.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.sidebarFlow.WrapContents = false;
            this.sidebarFlow.AutoScroll = false;
            this.sidebarFlow.BackColor = System.Drawing.Color.Transparent;
            this.sidebarFlow.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSidebarUser, this.btnChamCong, this.btnNghiPhep, this.btnLuong, this.btnHopDong, this.btnThongTin, this.btnGopY, this.btnLogout });

            // lblSidebarUser
            this.lblSidebarUser.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSidebarUser.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSidebarUser.Text = "NHÂN VIÊN";
            this.lblSidebarUser.Size = new System.Drawing.Size(220, 30);
            this.lblSidebarUser.Padding = new System.Windows.Forms.Padding(5, 8, 0, 4);

            // btnChamCong
            this.btnChamCong.Animated = true;
            this.btnChamCong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChamCong.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnChamCong.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnChamCong.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnChamCong.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnChamCong.Text = "🕐  Chấm công";
            this.btnChamCong.FillColor = System.Drawing.Color.Transparent;
            this.btnChamCong.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnChamCong.BorderRadius = 8;
            this.btnChamCong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChamCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChamCong.Size = new System.Drawing.Size(220, 44);
            this.btnChamCong.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnChamCong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnChamCong.Click += new System.EventHandler(this.BtnNav_Click);

            // btnNghiPhep
            this.btnNghiPhep.Animated = true;
            this.btnNghiPhep.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNghiPhep.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnNghiPhep.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnNghiPhep.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnNghiPhep.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnNghiPhep.Text = "📋  Đơn nghỉ phép";
            this.btnNghiPhep.FillColor = System.Drawing.Color.Transparent;
            this.btnNghiPhep.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNghiPhep.BorderRadius = 8;
            this.btnNghiPhep.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNghiPhep.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNghiPhep.Size = new System.Drawing.Size(220, 44);
            this.btnNghiPhep.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnNghiPhep.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNghiPhep.Click += new System.EventHandler(this.BtnNav_Click);

            // btnLuong
            this.btnLuong.Animated = true;
            this.btnLuong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLuong.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnLuong.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnLuong.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnLuong.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnLuong.Text = "💰  Lương của tôi";
            this.btnLuong.FillColor = System.Drawing.Color.Transparent;
            this.btnLuong.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLuong.BorderRadius = 8;
            this.btnLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLuong.Size = new System.Drawing.Size(220, 44);
            this.btnLuong.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnLuong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLuong.Click += new System.EventHandler(this.BtnNav_Click);

            // btnHopDong
            this.btnHopDong.Animated = true;
            this.btnHopDong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHopDong.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnHopDong.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnHopDong.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnHopDong.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnHopDong.Text = "📄  Hợp đồng của tôi";
            this.btnHopDong.FillColor = System.Drawing.Color.Transparent;
            this.btnHopDong.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnHopDong.BorderRadius = 8;
            this.btnHopDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHopDong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHopDong.Size = new System.Drawing.Size(220, 44);
            this.btnHopDong.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnHopDong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHopDong.Click += new System.EventHandler(this.BtnNav_Click);

            // btnThongTin
            this.btnThongTin.Animated = true;
            this.btnThongTin.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThongTin.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnThongTin.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnThongTin.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnThongTin.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnThongTin.Text = "👤  Thông tin cá nhân";
            this.btnThongTin.FillColor = System.Drawing.Color.Transparent;
            this.btnThongTin.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnThongTin.BorderRadius = 8;
            this.btnThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongTin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongTin.Size = new System.Drawing.Size(220, 44);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnThongTin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThongTin.Click += new System.EventHandler(this.BtnNav_Click);

            // btnGopY
            this.btnGopY.Animated = true;
            this.btnGopY.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGopY.CheckedState.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnGopY.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnGopY.HoverState.FillColor = System.Drawing.Color.FromArgb(224, 231, 255);
            this.btnGopY.HoverState.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnGopY.Text = "💬  Góp ý / Yêu cầu";
            this.btnGopY.FillColor = System.Drawing.Color.Transparent;
            this.btnGopY.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnGopY.BorderRadius = 8;
            this.btnGopY.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGopY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGopY.Size = new System.Drawing.Size(220, 44);
            this.btnGopY.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnGopY.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGopY.Click += new System.EventHandler(this.BtnNav_Click);

            // btnLogout
            this.btnLogout.Text = "🚪  Đăng xuất";
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnLogout.BorderRadius = 8;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Size = new System.Drawing.Size(220, 44);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0, 30, 0, 3);
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // contentArea
            this.contentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentArea.BackColor = System.Drawing.Color.Transparent;
            this.contentArea.Location = new System.Drawing.Point(240, 40);
            this.contentArea.Name = "contentArea";

            // Form
            this.Controls.Add(this.contentArea);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.titleBar);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(197, 210, 246);
            this.Text = "Vietland HR — Nhân viên";

            this.sidebarFlow.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblUserInfo;
        private Guna.UI2.WinForms.Guna2Button btnMin;
        private Guna.UI2.WinForms.Guna2Button btnMax;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel sidebar;
        private System.Windows.Forms.FlowLayoutPanel sidebarFlow;
        private System.Windows.Forms.Label lblSidebarUser;
        private Guna.UI2.WinForms.Guna2Button btnChamCong;
        private Guna.UI2.WinForms.Guna2Button btnNghiPhep;
        private Guna.UI2.WinForms.Guna2Button btnLuong;
        private Guna.UI2.WinForms.Guna2Button btnHopDong;
        private Guna.UI2.WinForms.Guna2Button btnThongTin;
        private Guna.UI2.WinForms.Guna2Button btnGopY;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private System.Windows.Forms.Panel contentArea;
    }
}

