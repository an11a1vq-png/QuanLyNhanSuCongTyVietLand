namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpNghiPhepPage
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            lblFormTitle = new Label();
            lblLoai = new Label();
            cboLoai = new Guna.UI2.WinForms.Guna2ComboBox();
            lblBatDau = new Label();
            dtpBatDau = new DateTimePicker();
            lblKetThuc = new Label();
            dtpKetThuc = new DateTimePicker();
            lblLyDo = new Label();
            txtLyDo = new Guna.UI2.WinForms.Guna2TextBox();
            btnGui = new Guna.UI2.WinForms.Guna2Button();
            lblMyDon = new Label();
            _grid = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            pnlSpacer = new Panel();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlForm
            // 
            pnlForm.BorderRadius = 12;
            pnlForm.Controls.Add(lblFormTitle);
            pnlForm.Controls.Add(lblLoai);
            pnlForm.Controls.Add(cboLoai);
            pnlForm.Controls.Add(lblBatDau);
            pnlForm.Controls.Add(dtpBatDau);
            pnlForm.Controls.Add(lblKetThuc);
            pnlForm.Controls.Add(dtpKetThuc);
            pnlForm.Controls.Add(lblLyDo);
            pnlForm.Controls.Add(txtLyDo);
            pnlForm.Controls.Add(btnGui);
            pnlForm.CustomizableEdges = customizableEdges7;
            pnlForm.Dock = DockStyle.Top;
            pnlForm.FillColor = Color.FromArgb(245, 248, 255);
            pnlForm.Location = new Point(15, 15);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(20, 15, 20, 15);
            pnlForm.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlForm.Size = new Size(919, 240);
            pnlForm.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblFormTitle.Location = new Point(20, 12);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(251, 30);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "📋  Gửi đơn nghỉ phép";
            // 
            // lblLoai
            // 
            lblLoai.AutoSize = true;
            lblLoai.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLoai.ForeColor = Color.FromArgb(71, 85, 105);
            lblLoai.Location = new Point(20, 55);
            lblLoai.Name = "lblLoai";
            lblLoai.Size = new Size(77, 21);
            lblLoai.TabIndex = 1;
            lblLoai.Text = "Loại nghỉ:";
            // 
            // cboLoai
            // 
            cboLoai.BackColor = Color.Transparent;
            cboLoai.BorderColor = Color.FromArgb(203, 213, 225);
            cboLoai.BorderRadius = 6;
            cboLoai.CustomizableEdges = customizableEdges1;
            cboLoai.DrawMode = DrawMode.OwnerDrawFixed;
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.FillColor = Color.White;
            cboLoai.FocusedColor = Color.Empty;
            cboLoai.Font = new Font("Segoe UI", 10F);
            cboLoai.ForeColor = Color.FromArgb(30, 41, 59);
            cboLoai.ItemHeight = 30;
            cboLoai.Items.AddRange(new object[] { "Nghỉ phép năm", "Nghỉ bệnh", "Nghỉ không lương", "Khác" });
            cboLoai.Location = new Point(20, 80);
            cboLoai.Name = "cboLoai";
            cboLoai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboLoai.Size = new Size(200, 36);
            cboLoai.TabIndex = 2;
            // 
            // lblBatDau
            // 
            lblBatDau.AutoSize = true;
            lblBatDau.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBatDau.ForeColor = Color.FromArgb(71, 85, 105);
            lblBatDau.Location = new Point(240, 55);
            lblBatDau.Name = "lblBatDau";
            lblBatDau.Size = new Size(106, 21);
            lblBatDau.TabIndex = 3;
            lblBatDau.Text = "Từ ngày:";
            // 
            // dtpBatDau
            // 
            dtpBatDau.Format = DateTimePickerFormat.Short;
            dtpBatDau.Location = new Point(240, 80);
            dtpBatDau.Name = "dtpBatDau";
            dtpBatDau.Size = new Size(150, 30);
            dtpBatDau.TabIndex = 4;
            // 
            // lblKetThuc
            // 
            lblKetThuc.AutoSize = true;
            lblKetThuc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKetThuc.ForeColor = Color.FromArgb(71, 85, 105);
            lblKetThuc.Location = new Point(410, 55);
            lblKetThuc.Name = "lblKetThuc";
            lblKetThuc.Size = new Size(79, 21);
            lblKetThuc.TabIndex = 5;
            lblKetThuc.Text = "Đến ngày:";
            // 
            // dtpKetThuc
            // 
            dtpKetThuc.Format = DateTimePickerFormat.Short;
            dtpKetThuc.Location = new Point(410, 80);
            dtpKetThuc.Name = "dtpKetThuc";
            dtpKetThuc.Size = new Size(150, 30);
            dtpKetThuc.TabIndex = 6;
            // 
            // lblLyDo
            // 
            lblLyDo.AutoSize = true;
            lblLyDo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLyDo.ForeColor = Color.FromArgb(71, 85, 105);
            lblLyDo.Location = new Point(20, 125);
            lblLyDo.Name = "lblLyDo";
            lblLyDo.Size = new Size(51, 21);
            lblLyDo.TabIndex = 7;
            lblLyDo.Text = "Lý do:";
            // 
            // txtLyDo
            // 
            txtLyDo.BorderColor = Color.FromArgb(203, 213, 225);
            txtLyDo.BorderRadius = 6;
            txtLyDo.CustomizableEdges = customizableEdges3;
            txtLyDo.DefaultText = "";
            txtLyDo.FillColor = Color.White;
            txtLyDo.Font = new Font("Segoe UI", 9.5F);
            txtLyDo.ForeColor = Color.FromArgb(30, 41, 59);
            txtLyDo.Location = new Point(20, 150);
            txtLyDo.Margin = new Padding(3, 4, 3, 4);
            txtLyDo.Name = "txtLyDo";
            txtLyDo.PlaceholderText = "Nhập lý do xin nghỉ...";
            txtLyDo.SelectedText = "";
            txtLyDo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtLyDo.Size = new Size(540, 70);
            txtLyDo.TabIndex = 8;
            // 
            // btnGui
            // 
            btnGui.BorderRadius = 6;
            btnGui.CustomizableEdges = customizableEdges5;
            btnGui.FillColor = Color.FromArgb(67, 56, 202);
            btnGui.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGui.ForeColor = Color.White;
            btnGui.Location = new Point(580, 150);
            btnGui.Name = "btnGui";
            btnGui.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnGui.Size = new Size(140, 42);
            btnGui.TabIndex = 9;
            btnGui.Text = "📨  GỬI ĐƠN";
            btnGui.Click += BtnGui_Click;
            // 
            // lblMyDon
            // 
            lblMyDon.Dock = DockStyle.Top;
            lblMyDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMyDon.ForeColor = Color.FromArgb(15, 23, 42);
            lblMyDon.Location = new Point(15, 15);
            lblMyDon.Name = "lblMyDon";
            lblMyDon.Padding = new Padding(5, 8, 0, 0);
            lblMyDon.Size = new Size(889, 35);
            lblMyDon.TabIndex = 1;
            lblMyDon.Text = "Đơn nghỉ phép của tôi:";
            // 
            // _grid
            // 
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            _grid.ColumnHeadersHeight = 40;
            _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            _grid.DefaultCellStyle = dataGridViewCellStyle2;
            _grid.Dock = DockStyle.Fill;
            _grid.GridColor = Color.FromArgb(231, 229, 255);
            _grid.Location = new Point(15, 50);
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.RowHeadersWidth = 51;
            _grid.RowTemplate.Height = 36;
            _grid.Size = new Size(889, 198);
            _grid.TabIndex = 0;
            _grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            _grid.ThemeStyle.HeaderStyle.Height = 40;
            _grid.ThemeStyle.ReadOnly = true;
            _grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            _grid.ThemeStyle.RowsStyle.Height = 36;
            // 
            // pnlBottom
            // 
            pnlBottom.BorderRadius = 12;
            pnlBottom.Controls.Add(_grid);
            pnlBottom.Controls.Add(lblMyDon);
            pnlBottom.CustomizableEdges = customizableEdges9;
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.FillColor = Color.FromArgb(245, 248, 255);
            pnlBottom.Location = new Point(15, 270);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlBottom.Size = new Size(919, 263);
            pnlBottom.TabIndex = 0;
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.Transparent;
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Location = new Point(15, 255);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(919, 15);
            pnlSpacer.TabIndex = 1;
            // 
            // EmpNghiPhepPage
            // 
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(pnlBottom);
            Controls.Add(pnlSpacer);
            Controls.Add(pnlForm);
            Name = "EmpNghiPhepPage";
            Padding = new Padding(15, 15, 15, 0);
            Size = new Size(949, 533);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel    pnlForm;
        private System.Windows.Forms.Label       lblFormTitle;
        private System.Windows.Forms.Label       lblLoai;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoai;
        private System.Windows.Forms.Label       lblBatDau;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.Label       lblKetThuc;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Label       lblLyDo;
        private Guna.UI2.WinForms.Guna2TextBox  txtLyDo;
        private Guna.UI2.WinForms.Guna2Button   btnGui;
        private System.Windows.Forms.Label       lblMyDon;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
        private Guna.UI2.WinForms.Guna2Panel    pnlBottom;
        private System.Windows.Forms.Panel       pnlSpacer;
    }
}


