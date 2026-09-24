namespace VietLandHR.GUI
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblSlogan = new System.Windows.Forms.Label();
            this._loginPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this._txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this._txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this._lblError = new System.Windows.Forms.Label();
            this._btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.leftPanel.SuspendLayout();
            this._loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(45, 76, 200);
            this.leftPanel.Controls.Add(this.lblLogo);
            this.leftPanel.Controls.Add(this.lblCompany);
            this.leftPanel.Controls.Add(this.lblSub);
            this.leftPanel.Controls.Add(this.lblSlogan);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(420, 560);
            this.leftPanel.TabIndex = 0;
            this.leftPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LeftPanel_Paint);
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 56F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 60);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(420, 110);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🏢";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompany
            // 
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompany.ForeColor = System.Drawing.Color.White;
            this.lblCompany.Location = new System.Drawing.Point(0, 180);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(420, 60);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "VIETLAND";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblSub.Location = new System.Drawing.Point(0, 250);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(420, 30);
            this.lblSub.TabIndex = 2;
            this.lblSub.Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSlogan
            // 
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(240)))));
            this.lblSlogan.Location = new System.Drawing.Point(0, 300);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(420, 30);
            this.lblSlogan.TabIndex = 3;
            this.lblSlogan.Text = "Quản lý hiệu quả · Phát triển bền vững";
            this.lblSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _loginPanel
            // 
            this._loginPanel.BackColor = System.Drawing.Color.White;
            this._loginPanel.Controls.Add(this.lblTitle);
            this._loginPanel.Controls.Add(this.lblWelcome);
            this._loginPanel.Controls.Add(this.lblUser);
            this._loginPanel.Controls.Add(this._txtUsername);
            this._loginPanel.Controls.Add(this.lblPass);
            this._loginPanel.Controls.Add(this._txtPassword);
            this._loginPanel.Controls.Add(this._lblError);
            this._loginPanel.Controls.Add(this._btnLogin);
            this._loginPanel.Controls.Add(this.lblHint);
            this._loginPanel.Controls.Add(this.lblRegister);
            this._loginPanel.Controls.Add(this.lblVersion);
            this._loginPanel.Controls.Add(this.btnClose);
            this._loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loginPanel.Location = new System.Drawing.Point(420, 0);
            this._loginPanel.Name = "_loginPanel";
            this._loginPanel.Size = new System.Drawing.Size(480, 560);
            this._loginPanel.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(60, 75);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(169, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng nhập";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblWelcome.Location = new System.Drawing.Point(60, 125);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(242, 17);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Chào mừng trở lại! Vui lòng đăng nhập.";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblUser.Location = new System.Drawing.Point(60, 180);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập";
            // 
            // _txtUsername
            // 
            this._txtUsername.BackColor = System.Drawing.Color.White;
            this._txtUsername.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._txtUsername.BorderRadius = 10;
            this._txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtUsername.DefaultText = "";
            this._txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this._txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this._txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtUsername.FillColor = System.Drawing.Color.White;
            this._txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._txtUsername.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._txtUsername.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this._txtUsername.Location = new System.Drawing.Point(60, 205);
            this._txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._txtUsername.Name = "_txtUsername";
            this._txtUsername.PasswordChar = '\0';
            this._txtUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this._txtUsername.PlaceholderText = "Nhập tên đăng nhập của bạn...";
            this._txtUsername.SelectedText = "";
            this._txtUsername.Size = new System.Drawing.Size(360, 46);
            this._txtUsername.TabIndex = 3;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPass.Location = new System.Drawing.Point(60, 270);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 17);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Mật khẩu";
            // 
            // _txtPassword
            // 
            this._txtPassword.BackColor = System.Drawing.Color.White;
            this._txtPassword.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._txtPassword.BorderRadius = 10;
            this._txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtPassword.DefaultText = "";
            this._txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this._txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this._txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this._txtPassword.FillColor = System.Drawing.Color.White;
            this._txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._txtPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this._txtPassword.Location = new System.Drawing.Point(60, 295);
            this._txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.PasswordChar = '●';
            this._txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this._txtPassword.PlaceholderText = "Nhập mật khẩu...";
            this._txtPassword.SelectedText = "";
            this._txtPassword.Size = new System.Drawing.Size(360, 46);
            this._txtPassword.TabIndex = 5;
            this._txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // _lblError
            // 
            this._lblError.AutoSize = true;
            this._lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblError.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this._lblError.Location = new System.Drawing.Point(60, 350);
            this._lblError.Name = "_lblError";
            this._lblError.Size = new System.Drawing.Size(0, 15);
            this._lblError.TabIndex = 6;
            // 
            // _btnLogin
            // 
            this._btnLogin.Animated = true;
            this._btnLogin.BorderRadius = 12;
            this._btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._btnLogin.FillColor = System.Drawing.Color.FromArgb(72, 55, 210);
            this._btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._btnLogin.ForeColor = System.Drawing.Color.White;
            this._btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(88, 70, 230);
            this._btnLogin.ShadowDecoration.Enabled = true;
            this._btnLogin.ShadowDecoration.BorderRadius = 12;
            this._btnLogin.ShadowDecoration.Color = System.Drawing.Color.FromArgb(148, 163, 184);
            this._btnLogin.ShadowDecoration.Depth = 10;
            this._btnLogin.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this._btnLogin.Location = new System.Drawing.Point(60, 380);
            this._btnLogin.Name = "_btnLogin";
            this._btnLogin.Size = new System.Drawing.Size(360, 48);
            this._btnLogin.TabIndex = 7;
            this._btnLogin.Text = "ĐĂNG NHẬP";
            this._btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblHint.Location = new System.Drawing.Point(100, 445);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(120, 17);
            this.lblHint.TabIndex = 10;
            this.lblHint.Text = "Chưa có tài khoản?";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegister.Font = new System.Drawing.Font("Segoe UI", 9.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblRegister.ForeColor = System.Drawing.Color.FromArgb(72, 55, 210);
            this.lblRegister.Location = new System.Drawing.Point(225, 445);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(130, 17);
            this.lblRegister.TabIndex = 11;
            this.lblRegister.Text = "Gửi yêu cầu đăng ký";
            this.lblRegister.Click += new System.EventHandler(this.LblRegister_Click);
            this.lblRegister.MouseEnter += new System.EventHandler(this.LblRegister_MouseEnter);
            this.lblRegister.MouseLeave += new System.EventHandler(this.LblRegister_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblVersion.Location = new System.Drawing.Point(280, 530);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(167, 13);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "Vietland HR System v1.0 © 2026";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 18;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(436, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this._loginPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Vietland HR";
            this.leftPanel.ResumeLayout(false);
            this._loginPanel.ResumeLayout(false);
            this._loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Panel _loginPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUser;
        private Guna.UI2.WinForms.Guna2TextBox _txtUsername;
        private System.Windows.Forms.Label lblPass;
        private Guna.UI2.WinForms.Guna2TextBox _txtPassword;
        private System.Windows.Forms.Label _lblError;
        private Guna.UI2.WinForms.Guna2Button _btnLogin;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblVersion;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}

