namespace VietLandHR.GUI.Pages
{
    partial class NghiPhepPage
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.toolbar = new System.Windows.Forms.Panel();
            this.btnChoXuLy = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Button();
                        this.btnTuChoi = new Guna.UI2.WinForms.Guna2Button();
            this.cboLoaiNghi = new Guna.UI2.WinForms.Guna2ComboBox();
            this._lblCount = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.toolbar.Controls.Add(this.btnChoXuLy);
            this.toolbar.Controls.Add(this.btnAll);
            this.toolbar.Controls.Add(this.btnDuyet);
            this.toolbar.Controls.Add(this.btnTuChoi);
            this.toolbar.Controls.Add(this.cboLoaiNghi);
            this.toolbar.Controls.Add(this._lblCount);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1080, 60);
            this.toolbar.TabIndex = 0;
            // 
            // btnChoXuLy
            // 
            this.btnChoXuLy.Animated = true;
            this.btnChoXuLy.BorderRadius = 10;
            this.btnChoXuLy.FillColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnChoXuLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChoXuLy.ForeColor = System.Drawing.Color.White;
            this.btnChoXuLy.HoverState.FillColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.btnChoXuLy.Location = new System.Drawing.Point(12, 10);
            this.btnChoXuLy.Name = "btnChoXuLy";
            this.btnChoXuLy.Size = new System.Drawing.Size(140, 40);
            this.btnChoXuLy.TabIndex = 0;
            this.btnChoXuLy.Text = "📋  Chờ duyệt";
            this.btnChoXuLy.Click += new System.EventHandler(this.BtnChoXuLy_Click);
            // 
            // btnAll
            // 
            this.btnAll.Animated = true;
            this.btnAll.BorderRadius = 10;
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.HoverState.FillColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnAll.Location = new System.Drawing.Point(164, 10);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(120, 40);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "🗂  Tất cả";
            this.btnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.Animated = true;
            this.btnDuyet.BorderRadius = 10;
            this.btnDuyet.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.HoverState.FillColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnDuyet.Location = new System.Drawing.Point(302, 10);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(140, 40);
            this.btnDuyet.TabIndex = 2;
            this.btnDuyet.Text = "✅  Duyệt đơn";
            this.btnDuyet.Click += new System.EventHandler(this.BtnDuyet_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Animated = true;
            this.btnTuChoi.BorderRadius = 10;
            this.btnTuChoi.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnTuChoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnTuChoi.Location = new System.Drawing.Point(454, 10);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(130, 40);
            this.btnTuChoi.TabIndex = 3;
            this.btnTuChoi.Text = "❌  Từ chối";
            this.btnTuChoi.Click += new System.EventHandler(this.BtnTuChoi_Click);
            // 
            // cboLoaiNghi
            // 
            this.cboLoaiNghi.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiNghi.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.cboLoaiNghi.BorderRadius = 10;
            this.cboLoaiNghi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLoaiNghi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiNghi.FillColor = System.Drawing.Color.White;
            this.cboLoaiNghi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboLoaiNghi.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.cboLoaiNghi.ItemHeight = 30;
            this.cboLoaiNghi.Location = new System.Drawing.Point(595, 10);
            this.cboLoaiNghi.Name = "cboLoaiNghi";
            this.cboLoaiNghi.Size = new System.Drawing.Size(160, 36);
            this.cboLoaiNghi.TabIndex = 3;
            this.cboLoaiNghi.SelectedIndexChanged += new System.EventHandler(this.CboLoaiNghi_SelectedIndexChanged);
            // 
            // _lblCount
            // 
            this._lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._lblCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this._lblCount.Location = new System.Drawing.Point(780, 20);
            this._lblCount.Name = "_lblCount";
            this._lblCount.Size = new System.Drawing.Size(280, 25);
            this._lblCount.TabIndex = 4;
            this._lblCount.Text = "Tổng: 0 đơn";
            this._lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this._grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._grid.ColumnHeadersHeight = 44;
            this._grid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this._grid.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this._grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))), ((int)(((byte)(80)))));
            this._grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._grid.Location = new System.Drawing.Point(0, 60);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 42;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1080, 690);
            this._grid.TabIndex = 1;
            // 
            // NghiPhepPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this._grid);
            this.Controls.Add(this.toolbar);
            this.Name = "NghiPhepPage";
            this.Size = new System.Drawing.Size(1050, 750);
            this.toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toolbar;
        private Guna.UI2.WinForms.Guna2Button btnChoXuLy;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnDuyet;
                private Guna.UI2.WinForms.Guna2Button btnTuChoi;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiNghi;
        private System.Windows.Forms.Label _lblCount;
        private System.Windows.Forms.DataGridView _grid;
    }
}

