using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    partial class PhongBanPage
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblPageTitle = new Label();
            toolbar = new Panel();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            btnLam = new Guna.UI2.WinForms.Guna2Button();
            btnXemNV = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            _grid = new DataGridView();
            pnlHeader.SuspendLayout();
            toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.FillColor = Color.FromArgb(59, 55, 173);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 10);
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(1050, 65);
            pnlHeader.TabIndex = 2;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Location = new Point(20, 16);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(281, 32);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "🏢  Quản lý Phòng ban";
            // 
            // toolbar
            // 
            toolbar.BackColor = Color.FromArgb(245, 248, 255);
            toolbar.Controls.Add(btnThem);
            toolbar.Controls.Add(btnLam);
            toolbar.Controls.Add(btnXemNV);
            toolbar.Controls.Add(txtSearch);
            toolbar.Dock = DockStyle.Top;
            toolbar.Location = new Point(0, 65);
            toolbar.Name = "toolbar";
            toolbar.Padding = new Padding(5, 7, 5, 5);
            toolbar.Size = new Size(1050, 52);
            toolbar.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 7;
            btnThem.CustomizableEdges = customizableEdges3;
            btnThem.FillColor = Color.FromArgb(67, 56, 202);
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(5, 7);
            btnThem.Margin = new Padding(0, 0, 6, 0);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThem.Size = new Size(132, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm mới";
            btnThem.Click += BtnThem_Click;
            // 
            // btnLam
            // 
            btnLam.BorderRadius = 7;
            btnLam.CustomizableEdges = customizableEdges5;
            btnLam.FillColor = Color.FromArgb(71, 85, 105);
            btnLam.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLam.ForeColor = Color.White;
            btnLam.Location = new Point(143, 7);
            btnLam.Margin = new Padding(0, 0, 6, 0);
            btnLam.Name = "btnLam";
            btnLam.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnLam.Size = new Size(120, 36);
            btnLam.TabIndex = 1;
            btnLam.Text = "🔄 Làm mới";
            btnLam.Click += BtnLam_Click;
            // 
            // btnXemNV
            // 
            btnXemNV.BorderRadius = 7;
            btnXemNV.CustomizableEdges = customizableEdges7;
            btnXemNV.FillColor = Color.FromArgb(16, 185, 129);
            btnXemNV.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXemNV.ForeColor = Color.White;
            btnXemNV.Location = new Point(270, 7);
            btnXemNV.Margin = new Padding(0, 0, 6, 0);
            btnXemNV.Name = "btnXemNV";
            btnXemNV.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnXemNV.Size = new Size(185, 36);
            btnXemNV.TabIndex = 2;
            btnXemNV.Text = "👥 Xem Nhân viên";
            btnXemNV.Click += BtnXemNV_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(203, 213, 225);
            txtSearch.BorderRadius = 7;
            txtSearch.CustomizableEdges = customizableEdges9;
            txtSearch.DefaultText = "";
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
            txtSearch.Location = new Point(478, 7);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "🔍  Tìm phòng ban...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtSearch.Size = new Size(220, 36);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // _grid
            // 
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.BackgroundColor = Color.White;
            _grid.ColumnHeadersHeight = 44;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            _grid.DefaultCellStyle = dataGridViewCellStyle1;
            _grid.Dock = DockStyle.Fill;
            _grid.Location = new Point(0, 117);
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.RowHeadersWidth = 51;
            _grid.RowTemplate.Height = 42;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.Size = new Size(1050, 633);
            _grid.TabIndex = 0;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
            // 
            // PhongBanPage
            // 
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(_grid);
            Controls.Add(toolbar);
            Controls.Add(pnlHeader);
            Name = "PhongBanPage";
            Size = new Size(1050, 750);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel  pnlHeader;
        private System.Windows.Forms.Label     lblPageTitle;
        private System.Windows.Forms.Panel     toolbar;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnLam;
        private Guna.UI2.WinForms.Guna2Button btnXemNV;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridView _grid;
    }
}

