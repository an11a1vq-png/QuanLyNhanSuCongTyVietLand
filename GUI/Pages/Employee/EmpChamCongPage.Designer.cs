namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpChamCongPage
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            lblDate = new Label();
            lblStatus = new Label();
            pnlButtons = new FlowLayoutPanel();
            btnCheckIn = new Guna.UI2.WinForms.Guna2Button();
            btnCheckOut = new Guna.UI2.WinForms.Guna2Button();
            pnlFilter = new FlowLayoutPanel();
            cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            btnXem = new Guna.UI2.WinForms.Guna2Button();
            _grid = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            pnlSpacer = new Panel();
            pnlTop.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BorderRadius = 12;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblDate);
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Controls.Add(pnlButtons);
            pnlTop.CustomizableEdges = customizableEdges5;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.FillColor = Color.FromArgb(245, 248, 255);
            pnlTop.Location = new Point(15, 15);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(20, 15, 20, 15);
            pnlTop.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlTop.Size = new Size(904, 180);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(296, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🕐  Chấm công hôm nay";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblDate.Location = new Point(20, 50);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(0, 23);
            lblDate.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(22, 163, 74);
            lblStatus.Location = new Point(20, 78);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 23);
            lblStatus.TabIndex = 2;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCheckIn);
            pnlButtons.Controls.Add(btnCheckOut);
            pnlButtons.Location = new Point(20, 104);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(364, 69);
            pnlButtons.TabIndex = 3;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BorderRadius = 8;
            btnCheckIn.CustomizableEdges = customizableEdges1;
            btnCheckIn.FillColor = Color.FromArgb(67, 56, 202);
            btnCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(0, 0);
            btnCheckIn.Margin = new Padding(0, 0, 10, 0);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCheckIn.Size = new Size(166, 46);
            btnCheckIn.TabIndex = 0;
            btnCheckIn.Text = "✅  CHECK IN";
            btnCheckIn.Click += BtnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BorderRadius = 8;
            btnCheckOut.CustomizableEdges = customizableEdges3;
            btnCheckOut.FillColor = Color.FromArgb(220, 38, 38);
            btnCheckOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(179, 3);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCheckOut.Size = new Size(171, 46);
            btnCheckOut.TabIndex = 1;
            btnCheckOut.Text = "🚪  CHECK OUT";
            btnCheckOut.Click += BtnCheckOut_Click;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(cboThang);
            pnlFilter.Controls.Add(cboNam);
            pnlFilter.Controls.Add(btnXem);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(15, 15);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(5, 8, 5, 5);
            pnlFilter.Size = new Size(874, 55);
            pnlFilter.TabIndex = 1;
            // 
            // cboThang
            // 
            cboThang.BackColor = Color.Transparent;
            cboThang.BorderColor = Color.FromArgb(203, 213, 225);
            cboThang.BorderRadius = 6;
            cboThang.CustomizableEdges = customizableEdges7;
            cboThang.DrawMode = DrawMode.OwnerDrawFixed;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FillColor = Color.White;
            cboThang.FocusedColor = Color.Empty;
            cboThang.Font = new Font("Segoe UI", 10F);
            cboThang.ForeColor = Color.FromArgb(30, 41, 59);
            cboThang.ItemHeight = 30;
            cboThang.Location = new Point(5, 8);
            cboThang.Margin = new Padding(0, 0, 8, 0);
            cboThang.Name = "cboThang";
            cboThang.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboThang.Size = new Size(130, 36);
            cboThang.TabIndex = 0;
            // 
            // cboNam
            // 
            cboNam.BackColor = Color.Transparent;
            cboNam.BorderColor = Color.FromArgb(203, 213, 225);
            cboNam.BorderRadius = 6;
            cboNam.CustomizableEdges = customizableEdges9;
            cboNam.DrawMode = DrawMode.OwnerDrawFixed;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNam.FillColor = Color.White;
            cboNam.FocusedColor = Color.Empty;
            cboNam.Font = new Font("Segoe UI", 10F);
            cboNam.ForeColor = Color.FromArgb(30, 41, 59);
            cboNam.ItemHeight = 30;
            cboNam.Location = new Point(143, 8);
            cboNam.Margin = new Padding(0, 0, 8, 0);
            cboNam.Name = "cboNam";
            cboNam.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cboNam.Size = new Size(100, 36);
            cboNam.TabIndex = 1;
            // 
            // btnXem
            // 
            btnXem.BorderRadius = 6;
            btnXem.CustomizableEdges = customizableEdges11;
            btnXem.FillColor = Color.FromArgb(67, 56, 202);
            btnXem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(254, 11);
            btnXem.Name = "btnXem";
            btnXem.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnXem.Size = new Size(90, 36);
            btnXem.TabIndex = 2;
            btnXem.Text = "🔍 Xem";
            btnXem.Click += BtnXem_Click;
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
            _grid.Location = new Point(15, 70);
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.RowHeadersWidth = 51;
            _grid.RowTemplate.Height = 36;
            _grid.Size = new Size(874, 250);
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
            pnlBottom.Controls.Add(pnlFilter);
            pnlBottom.CustomizableEdges = customizableEdges13;
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.FillColor = Color.FromArgb(245, 248, 255);
            pnlBottom.Location = new Point(15, 210);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlBottom.Size = new Size(904, 335);
            pnlBottom.TabIndex = 0;
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.Transparent;
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Location = new Point(15, 195);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(904, 15);
            pnlSpacer.TabIndex = 1;
            // 
            // EmpChamCongPage
            // 
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(pnlBottom);
            Controls.Add(pnlSpacer);
            Controls.Add(pnlTop);
            Name = "EmpChamCongPage";
            Padding = new Padding(15, 15, 15, 0);
            Size = new Size(934, 545);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel    pnlTop;
        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.Label       lblDate;
        private System.Windows.Forms.Label       lblStatus;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private Guna.UI2.WinForms.Guna2Button   btnCheckIn;
        private Guna.UI2.WinForms.Guna2Button   btnCheckOut;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboThang;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
        private Guna.UI2.WinForms.Guna2Button   btnXem;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
        private Guna.UI2.WinForms.Guna2Panel    pnlBottom;
        private System.Windows.Forms.Panel       pnlSpacer;
    }
}


