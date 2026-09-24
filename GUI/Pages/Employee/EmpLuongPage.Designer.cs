namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpLuongPage
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            pnlFilter = new FlowLayoutPanel();
            lblNam = new Label();
            cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            btnXem = new Guna.UI2.WinForms.Guna2Button();
            _grid = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            pnlSpacer = new Panel();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderRadius = 12;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.FillColor = Color.FromArgb(245, 248, 255);
            pnlHeader.Location = new Point(15, 15);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 10);
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(1042, 80);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💰  Lương của tôi";
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(lblNam);
            pnlFilter.Controls.Add(cboNam);
            pnlFilter.Controls.Add(btnXem);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(15, 15);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(5, 8, 5, 5);
            pnlFilter.Size = new Size(1012, 55);
            pnlFilter.TabIndex = 1;
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNam.ForeColor = Color.FromArgb(71, 85, 105);
            lblNam.Location = new Point(10, 16);
            lblNam.Margin = new Padding(5, 8, 5, 0);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(47, 21);
            lblNam.TabIndex = 0;
            lblNam.Text = "Năm:";
            // 
            // cboNam
            // 
            cboNam.BackColor = Color.Transparent;
            cboNam.BorderColor = Color.FromArgb(203, 213, 225);
            cboNam.BorderRadius = 6;
            cboNam.CustomizableEdges = customizableEdges3;
            cboNam.DrawMode = DrawMode.OwnerDrawFixed;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNam.FillColor = Color.White;
            cboNam.Font = new Font("Segoe UI", 10F);
            cboNam.ForeColor = Color.FromArgb(30, 41, 59);
            cboNam.ItemHeight = 30;
            cboNam.Location = new Point(62, 8);
            cboNam.Margin = new Padding(0, 0, 8, 0);
            cboNam.Name = "cboNam";
            cboNam.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboNam.Size = new Size(100, 36);
            cboNam.TabIndex = 1;
            // 
            // btnXem
            // 
            btnXem.BorderRadius = 6;
            btnXem.CustomizableEdges = customizableEdges5;
            btnXem.FillColor = Color.FromArgb(67, 56, 202);
            btnXem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXem.ForeColor = Color.White;
            btnXem.Location = new Point(173, 11);
            btnXem.Name = "btnXem";
            btnXem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnXem.Size = new Size(140, 36);
            btnXem.TabIndex = 2;
            btnXem.Text = "📄 Xem lịch sử";
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
            _grid.Size = new Size(1012, 372);
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
            pnlBottom.CustomizableEdges = customizableEdges7;
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.FillColor = Color.FromArgb(245, 248, 255);
            pnlBottom.Location = new Point(15, 110);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlBottom.Size = new Size(1042, 457);
            pnlBottom.TabIndex = 0;
            // 
            // pnlSpacer
            // 
            pnlSpacer.BackColor = Color.Transparent;
            pnlSpacer.Dock = DockStyle.Top;
            pnlSpacer.Location = new Point(15, 95);
            pnlSpacer.Name = "pnlSpacer";
            pnlSpacer.Size = new Size(1042, 15);
            pnlSpacer.TabIndex = 1;
            // 
            // EmpLuongPage
            // 
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(pnlBottom);
            Controls.Add(pnlSpacer);
            Controls.Add(pnlHeader);
            Name = "EmpLuongPage";
            Padding = new Padding(15, 15, 15, 0);
            Size = new Size(1072, 567);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel    pnlHeader;
        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlFilter;
        private System.Windows.Forms.Label       lblNam;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
        private Guna.UI2.WinForms.Guna2Button   btnXem;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
        private Guna.UI2.WinForms.Guna2Panel    pnlBottom;
        private System.Windows.Forms.Panel       pnlSpacer;
    }
}


