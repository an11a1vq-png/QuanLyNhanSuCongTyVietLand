using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    partial class HopDongPage
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            pnlToolbar = new FlowLayoutPanel();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            btnSua = new Guna.UI2.WinForms.Guna2Button();
            btnXoa = new Guna.UI2.WinForms.Guna2Button();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnSearch = new Guna.UI2.WinForms.Guna2Button();
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
            pnlHeader.Size = new Size(548, 65);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(381, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📝  Quản lý Hợp đồng lao động";
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(245, 248, 255);
            pnlToolbar.Controls.Add(btnThem);
            pnlToolbar.Controls.Add(btnSua);
            pnlToolbar.Controls.Add(btnXoa);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(btnSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 65);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(5, 7, 5, 5);
            pnlToolbar.Size = new Size(548, 52);
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
            btnThem.Size = new Size(120, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm mới";
            btnThem.Click += BtnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BorderRadius = 7;
            btnSua.CustomizableEdges = customizableEdges5;
            btnSua.FillColor = Color.FromArgb(71, 85, 105);
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(131, 7);
            btnSua.Margin = new Padding(0, 0, 6, 0);
            btnSua.Name = "btnSua";
            btnSua.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSua.Size = new Size(120, 36);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BorderRadius = 7;
            btnXoa.CustomizableEdges = customizableEdges7;
            btnXoa.FillColor = Color.FromArgb(220, 38, 38);
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(257, 7);
            btnXoa.Margin = new Padding(0, 0, 6, 0);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnXoa.Size = new Size(120, 36);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.Click += BtnXoa_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(203, 213, 225);
            txtSearch.BorderRadius = 7;
            txtSearch.CustomizableEdges = customizableEdges9;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.White;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
            txtSearch.Location = new Point(25, 43);
            txtSearch.Margin = new Padding(20, 0, 6, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.PlaceholderText = "🔍  Tìm theo mã NV / mã HĐ...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtSearch.Size = new Size(240, 36);
            txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BorderRadius = 7;
            btnSearch.CustomizableEdges = customizableEdges11;
            btnSearch.FillColor = Color.FromArgb(30, 64, 175);
            btnSearch.Font = new Font("Segoe UI", 9F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(274, 46);
            btnSearch.Name = "btnSearch";
            btnSearch.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSearch.Size = new Size(40, 36);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍";
            btnSearch.Click += BtnSearch_Click;
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
            _grid.Size = new Size(548, 323);
            _grid.TabIndex = 0;
            _grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            _grid.ThemeStyle.HeaderStyle.Height = 44;
            _grid.ThemeStyle.ReadOnly = true;
            _grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9.5F);
            _grid.ThemeStyle.RowsStyle.Height = 40;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
            // 
            // HopDongPage
            // 
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(_grid);
            Controls.Add(pnlToolbar);
            Controls.Add(pnlHeader);
            Name = "HopDongPage";
            Size = new Size(1050, 750);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }

        // Controls
        private Guna.UI2.WinForms.Guna2Panel       pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlToolbar;
        private Guna.UI2.WinForms.Guna2Button      btnThem;
        private Guna.UI2.WinForms.Guna2Button      btnSua;
        private Guna.UI2.WinForms.Guna2Button      btnXoa;
        private Guna.UI2.WinForms.Guna2TextBox     txtSearch;
        private Guna.UI2.WinForms.Guna2Button      btnSearch;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
    }
}

