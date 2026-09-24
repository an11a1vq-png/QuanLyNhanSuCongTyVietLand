using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    partial class TaiKhoanPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            pnlToolbar = new FlowLayoutPanel();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            btnKhoa = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            _grid = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlHeader.SuspendLayout();
            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(415, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔐  Quản lý Tài khoản & Phân quyền";
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(245, 248, 255);
            pnlToolbar.Controls.Add(btnThem);
            pnlToolbar.Controls.Add(btnKhoa);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 65);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(5, 7, 5, 5);
            pnlToolbar.Size = new Size(1050, 52);
            pnlToolbar.TabIndex = 1;
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
            btnThem.Size = new Size(182, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Tạo tài khoản";
            btnThem.Click += BtnThem_Click;
            // 
            // btnKhoa
            // 
            btnKhoa.BorderRadius = 7;
            btnKhoa.CustomizableEdges = customizableEdges5;
            btnKhoa.FillColor = Color.FromArgb(71, 85, 105);
            btnKhoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnKhoa.ForeColor = Color.White;
            btnKhoa.Location = new Point(193, 7);
            btnKhoa.Margin = new Padding(0, 0, 6, 0);
            btnKhoa.Name = "btnKhoa";
            btnKhoa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnKhoa.Size = new Size(138, 36);
            btnKhoa.TabIndex = 1;
            btnKhoa.Text = "🔒 Khóa / Mở khóa";
            btnKhoa.Click += BtnKhoa_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(203, 213, 225);
            txtSearch.BorderRadius = 7;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
            txtSearch.Location = new Point(367, 7);
            txtSearch.Margin = new Padding(30, 0, 0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "🔍  Tìm tài khoản...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(220, 36);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += TxtSearch_TextChanged;
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
            _grid.ColumnHeadersHeight = 44;
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
            _grid.Location = new Point(0, 117);
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.RowHeadersWidth = 51;
            _grid.RowTemplate.Height = 40;
            _grid.Size = new Size(1050, 633);
            _grid.TabIndex = 0;
            _grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            _grid.ThemeStyle.HeaderStyle.Height = 44;
            _grid.ThemeStyle.ReadOnly = true;
            _grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            _grid.ThemeStyle.RowsStyle.Height = 40;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
            // 
            // TaiKhoanPage
            // 
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(_grid);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Name = "TaiKhoanPage";
            Size = new Size(1050, 750);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel       pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlToolbar;
        private Guna.UI2.WinForms.Guna2Button      btnThem;
        private Guna.UI2.WinForms.Guna2Button      btnKhoa;
        private Guna.UI2.WinForms.Guna2TextBox     txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
    }
}

