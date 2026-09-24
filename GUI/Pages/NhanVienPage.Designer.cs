using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    partial class NhanVienPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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
            toolbar = new Panel();
            _txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            btnThem = new Guna.UI2.WinForms.Guna2Button();
            btnXoa = new Guna.UI2.WinForms.Guna2Button();
            btnLam = new Guna.UI2.WinForms.Guna2Button();
            btnExport = new Guna.UI2.WinForms.Guna2Button();
            _grid = new DataGridView();
            toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
            SuspendLayout();
            // 
            // toolbar
            // 
            toolbar.BackColor = Color.FromArgb(245, 248, 255);
            toolbar.Controls.Add(_txtSearch);
            toolbar.Controls.Add(cboFilter);
            toolbar.Controls.Add(btnThem);
            toolbar.Controls.Add(btnXoa);
            toolbar.Controls.Add(btnLam);
            toolbar.Controls.Add(btnExport);
            toolbar.Dock = DockStyle.Top;
            toolbar.Location = new Point(0, 0);
            toolbar.Margin = new Padding(3, 4, 3, 4);
            toolbar.Name = "toolbar";
            toolbar.Padding = new Padding(9, 12, 9, 12);
            toolbar.Size = new Size(1234, 77);
            toolbar.TabIndex = 1;
            // 
            // _txtSearch
            // 
            _txtSearch.BackColor = Color.Transparent;
            _txtSearch.BorderColor = Color.FromArgb(203, 213, 225);
            _txtSearch.BorderRadius = 10;
            _txtSearch.CustomizableEdges = customizableEdges1;
            _txtSearch.DefaultText = "";
            _txtSearch.FillColor = Color.White;
            _txtSearch.Font = new Font("Segoe UI", 10F);
            _txtSearch.ForeColor = Color.FromArgb(30, 41, 59);
            _txtSearch.Location = new Point(0, 15);
            _txtSearch.Margin = new Padding(3, 5, 3, 5);
            _txtSearch.Name = "_txtSearch";
            _txtSearch.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            _txtSearch.PlaceholderText = "🔍 Tìm kiếm theo tên, mã NV...";
            _txtSearch.SelectedText = "";
            _txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            _txtSearch.Size = new Size(297, 53);
            _txtSearch.TabIndex = 0;
            _txtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // cboFilter
            // 
            cboFilter.BackColor = Color.Transparent;
            cboFilter.BorderColor = Color.FromArgb(203, 213, 225);
            cboFilter.BorderRadius = 8;
            cboFilter.CustomizableEdges = customizableEdges3;
            cboFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FillColor = Color.White;
            cboFilter.FocusedColor = Color.FromArgb(67, 56, 202);
            cboFilter.Font = new Font("Segoe UI", 10F);
            cboFilter.ForeColor = Color.FromArgb(30, 41, 59);
            cboFilter.ItemHeight = 30;
            cboFilter.Location = new Point(303, 33);
            cboFilter.Margin = new Padding(3, 4, 3, 4);
            cboFilter.Name = "cboFilter";
            cboFilter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboFilter.Size = new Size(217, 36);
            cboFilter.TabIndex = 1;
            cboFilter.SelectedIndexChanged += CboFilter_SelectedIndexChanged;
            // 
            // btnThem
            // 
            btnThem.BorderRadius = 7;
            btnThem.CustomizableEdges = customizableEdges5;
            btnThem.FillColor = Color.FromArgb(67, 56, 202);
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(535, 25);
            btnThem.Margin = new Padding(0, 0, 7, 0);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThem.Size = new Size(137, 48);
            btnThem.TabIndex = 2;
            btnThem.Text = "➕ Thêm mới";
            btnThem.Click += BtnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.BorderRadius = 7;
            btnXoa.CustomizableEdges = customizableEdges7;
            btnXoa.FillColor = Color.FromArgb(220, 38, 38);
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(679, 25);
            btnXoa.Margin = new Padding(0, 0, 7, 0);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnXoa.Size = new Size(137, 48);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnLam
            // 
            btnLam.BorderRadius = 7;
            btnLam.CustomizableEdges = customizableEdges9;
            btnLam.FillColor = Color.FromArgb(71, 85, 105);
            btnLam.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLam.ForeColor = Color.White;
            btnLam.Location = new Point(823, 25);
            btnLam.Margin = new Padding(0, 0, 7, 0);
            btnLam.Name = "btnLam";
            btnLam.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLam.Size = new Size(137, 48);
            btnLam.TabIndex = 4;
            btnLam.Text = "🔄 Làm mới";
            btnLam.Click += BtnLam_Click;
            // 
            // btnExport
            // 
            btnExport.BorderRadius = 7;
            btnExport.CustomizableEdges = customizableEdges11;
            btnExport.FillColor = Color.FromArgb(22, 163, 74);
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(977, 25);
            btnExport.Margin = new Padding(0, 0, 7, 0);
            btnExport.Name = "btnExport";
            btnExport.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnExport.Size = new Size(137, 48);
            btnExport.TabIndex = 5;
            btnExport.Text = "📊 Excel";
            btnExport.Click += BtnExportExcel_Click;
            // 
            // _grid
            // 
            _grid.AllowUserToAddRows = false;
            _grid.AllowUserToDeleteRows = false;
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _grid.BackgroundColor = Color.White;
            _grid.BorderStyle = BorderStyle.None;
            _grid.ColumnHeadersHeight = 48;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            _grid.DefaultCellStyle = dataGridViewCellStyle1;
            _grid.Dock = DockStyle.Fill;
            _grid.EnableHeadersVisualStyles = false;
            _grid.Location = new Point(0, 77);
            _grid.Margin = new Padding(3, 4, 3, 4);
            _grid.Name = "_grid";
            _grid.ReadOnly = true;
            _grid.RowHeadersVisible = false;
            _grid.RowHeadersWidth = 51;
            _grid.RowTemplate.Height = 45;
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _grid.Size = new Size(1234, 923);
            _grid.TabIndex = 0;
            _grid.CellClick += Grid_CellClick;
            _grid.CellDoubleClick += Grid_CellDoubleClick;
            // 
            // NhanVienPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(_grid);
            Controls.Add(toolbar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "NhanVienPage";
            Size = new Size(1234, 1000);
            toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel       toolbar;
        private Guna.UI2.WinForms.Guna2TextBox  _txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Guna.UI2.WinForms.Guna2Button   btnThem;
        private Guna.UI2.WinForms.Guna2Button   btnXoa;
        private Guna.UI2.WinForms.Guna2Button   btnLam;
        private Guna.UI2.WinForms.Guna2Button   btnExport;
        private System.Windows.Forms.DataGridView _grid;
    }
}

