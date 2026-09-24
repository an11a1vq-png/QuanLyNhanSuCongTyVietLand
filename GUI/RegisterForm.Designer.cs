namespace VietLandHR.GUI
{
    partial class RegisterForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlLeft = new Panel();
            lblLeftLogo = new Label();
            lblLeftSub = new Label();
            lblLeftTitle = new Label();
            pnlRight = new Panel();
            btnClose = new Label();
            lblTitle = new Label();
            lblSubTitle = new Label();
            txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            txtCitizenId = new Guna.UI2.WinForms.Guna2TextBox();
            cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            dtpBirthDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnSubmit = new Guna.UI2.WinForms.Guna2Button();
            lblMsg = new Label();
            lblBack = new Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(45, 76, 200);
            pnlLeft.Controls.Add(lblLeftLogo);
            pnlLeft.Controls.Add(lblLeftSub);
            pnlLeft.Controls.Add(lblLeftTitle);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(380, 750);
            pnlLeft.TabIndex = 0;
            pnlLeft.Paint += PnlLeft_Paint;
            // 
            // lblLeftLogo
            // 
            lblLeftLogo.BackColor = Color.Transparent;
            lblLeftLogo.Font = new Font("Segoe UI Emoji", 56F);
            lblLeftLogo.ForeColor = Color.White;
            lblLeftLogo.Location = new Point(0, 180);
            lblLeftLogo.Name = "lblLeftLogo";
            lblLeftLogo.Size = new Size(380, 110);
            lblLeftLogo.TabIndex = 2;
            lblLeftLogo.Text = "🏢";
            lblLeftLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLeftSub
            // 
            lblLeftSub.AutoSize = true;
            lblLeftSub.Font = new Font("Segoe UI", 11F);
            lblLeftSub.ForeColor = Color.FromArgb(200, 220, 255);
            lblLeftSub.Location = new Point(68, 379);
            lblLeftSub.Name = "lblLeftSub";
            lblLeftSub.Size = new Size(235, 25);
            lblLeftSub.TabIndex = 1;
            lblLeftSub.Text = "Hệ thống Quản lý Nhân sự";
            // 
            // lblLeftTitle
            // 
            lblLeftTitle.AutoSize = true;
            lblLeftTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblLeftTitle.ForeColor = Color.White;
            lblLeftTitle.Location = new Point(40, 300);
            lblLeftTitle.Name = "lblLeftTitle";
            lblLeftTitle.Size = new Size(286, 54);
            lblLeftTitle.TabIndex = 0;
            lblLeftTitle.Text = "VIETLAND HR";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Controls.Add(lblSubTitle);
            pnlRight.Controls.Add(txtFullName);
            pnlRight.Controls.Add(txtEmail);
            pnlRight.Controls.Add(txtPhone);
            pnlRight.Controls.Add(txtCitizenId);
            pnlRight.Controls.Add(cbGender);
            pnlRight.Controls.Add(txtAddress);
            pnlRight.Controls.Add(dtpBirthDate);
            pnlRight.Controls.Add(btnSubmit);
            pnlRight.Controls.Add(lblMsg);
            pnlRight.Controls.Add(lblBack);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(380, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(580, 750);
            pnlRight.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(100, 116, 139);
            btnClose.Location = new Point(540, 14);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 32);
            btnClose.TabIndex = 0;
            btnClose.Text = "✕";
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(50, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tạo yêu cầu đăng ký ✍";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(55, 95);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(529, 23);
            lblSubTitle.TabIndex = 2;
            lblSubTitle.Text = "Điền đầy đủ thông tin, Admin sẽ xét duyệt và tạo tài khoản cho bạn";
            // 
            // txtFullName
            // 
            txtFullName.BorderColor = Color.FromArgb(203, 213, 225);
            txtFullName.BorderRadius = 10;
            txtFullName.CustomizableEdges = customizableEdges1;
            txtFullName.DefaultText = "";
            txtFullName.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            txtFullName.Font = new Font("Segoe UI", 10.5F);
            txtFullName.ForeColor = Color.FromArgb(30, 41, 59);
            txtFullName.HoverState.BorderColor = Color.FromArgb(99, 102, 241);
            txtFullName.Location = new Point(60, 150);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtFullName.PlaceholderText = "👤 Họ và tên";
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtFullName.Size = new Size(444, 44);
            txtFullName.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.BorderColor = Color.FromArgb(203, 213, 225);
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges3;
            txtEmail.DefaultText = "";
            txtEmail.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.ForeColor = Color.FromArgb(30, 41, 59);
            txtEmail.HoverState.BorderColor = Color.FromArgb(99, 102, 241);
            txtEmail.Location = new Point(60, 210);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtEmail.PlaceholderText = "✉️ Email";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEmail.Size = new Size(444, 44);
            txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.BorderColor = Color.FromArgb(203, 213, 225);
            txtPhone.BorderRadius = 10;
            txtPhone.CustomizableEdges = customizableEdges5;
            txtPhone.DefaultText = "";
            txtPhone.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.ForeColor = Color.FromArgb(30, 41, 59);
            txtPhone.HoverState.BorderColor = Color.FromArgb(99, 102, 241);
            txtPhone.Location = new Point(60, 270);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPhone.PlaceholderText = "📞 Số điện thoại";
            txtPhone.SelectedText = "";
            txtPhone.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPhone.Size = new Size(215, 44);
            txtPhone.TabIndex = 5;
            // 
            // txtCitizenId
            // 
            txtCitizenId.BorderColor = Color.FromArgb(203, 213, 225);
            txtCitizenId.BorderRadius = 10;
            txtCitizenId.CustomizableEdges = customizableEdges7;
            txtCitizenId.DefaultText = "";
            txtCitizenId.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            txtCitizenId.Font = new Font("Segoe UI", 10.5F);
            txtCitizenId.ForeColor = Color.FromArgb(30, 41, 59);
            txtCitizenId.HoverState.BorderColor = Color.FromArgb(99, 102, 241);
            txtCitizenId.Location = new Point(289, 270);
            txtCitizenId.Margin = new Padding(3, 4, 3, 4);
            txtCitizenId.Name = "txtCitizenId";
            txtCitizenId.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtCitizenId.PlaceholderText = "💳 Căn cước công dân";
            txtCitizenId.SelectedText = "";
            txtCitizenId.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtCitizenId.Size = new Size(215, 44);
            txtCitizenId.TabIndex = 6;
            // 
            // cbGender
            // 
            cbGender.BackColor = Color.Transparent;
            cbGender.BorderColor = Color.FromArgb(203, 213, 225);
            cbGender.BorderRadius = 10;
            cbGender.CustomizableEdges = customizableEdges9;
            cbGender.DrawMode = DrawMode.OwnerDrawFixed;
            cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGender.FocusedColor = Color.FromArgb(67, 56, 202);
            cbGender.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            cbGender.Font = new Font("Segoe UI", 10.5F);
            cbGender.ForeColor = Color.FromArgb(30, 41, 59);
            cbGender.ItemHeight = 38;
            cbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbGender.Location = new Point(60, 330);
            cbGender.Name = "cbGender";
            cbGender.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cbGender.Size = new Size(215, 44);
            cbGender.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.BorderColor = Color.FromArgb(203, 213, 225);
            txtAddress.BorderRadius = 10;
            txtAddress.CustomizableEdges = customizableEdges11;
            txtAddress.DefaultText = "";
            txtAddress.FocusedState.BorderColor = Color.FromArgb(67, 56, 202);
            txtAddress.Font = new Font("Segoe UI", 10.5F);
            txtAddress.ForeColor = Color.FromArgb(30, 41, 59);
            txtAddress.HoverState.BorderColor = Color.FromArgb(99, 102, 241);
            txtAddress.Location = new Point(60, 390);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtAddress.PlaceholderText = "🏠 Địa chỉ thường trú";
            txtAddress.SelectedText = "";
            txtAddress.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtAddress.Size = new Size(444, 44);
            txtAddress.TabIndex = 9;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.BorderRadius = 10;
            dtpBirthDate.Checked = true;
            dtpBirthDate.CustomizableEdges = customizableEdges13;
            dtpBirthDate.FillColor = Color.FromArgb(245, 248, 255);
            dtpBirthDate.Font = new Font("Segoe UI", 10F);
            dtpBirthDate.ForeColor = Color.FromArgb(30, 41, 59);
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(289, 330);
            dtpBirthDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBirthDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.ShadowDecoration.CustomizableEdges = customizableEdges14;
            dtpBirthDate.Size = new Size(215, 44);
            dtpBirthDate.TabIndex = 8;
            dtpBirthDate.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // btnSubmit
            // 
            btnSubmit.Animated = true;
            btnSubmit.BorderRadius = 10;
            btnSubmit.CustomizableEdges = customizableEdges15;
            btnSubmit.FillColor = Color.FromArgb(67, 56, 202);
            btnSubmit.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.HoverState.FillColor = Color.FromArgb(55, 48, 163);
            btnSubmit.Location = new Point(60, 510);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSubmit.Size = new Size(444, 55);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "GỬI YÊU CẦU ĐĂNG KÝ";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("Segoe UI", 10F);
            lblMsg.ForeColor = Color.FromArgb(220, 38, 38);
            lblMsg.Location = new Point(60, 450);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(444, 45);
            lblMsg.TabIndex = 10;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Visible = false;
            // 
            // lblBack
            // 
            lblBack.AutoSize = true;
            lblBack.Cursor = Cursors.Hand;
            lblBack.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblBack.ForeColor = Color.FromArgb(67, 56, 202);
            lblBack.Location = new Point(190, 580);
            lblBack.Name = "lblBack";
            lblBack.Size = new Size(199, 25);
            lblBack.TabIndex = 12;
            lblBack.Text = "← Quay lại đăng nhập";
            lblBack.Click += lblBack_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 750);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblLeftLogo;
        private System.Windows.Forms.Label lblLeftSub;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtCitizenId;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirthDate;
        private Guna.UI2.WinForms.Guna2Button btnSubmit;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblBack;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}

