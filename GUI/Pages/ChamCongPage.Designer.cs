namespace VietLandHR.GUI.Pages
{
    partial class ChamCongPage
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
            this.checkPanel = new System.Windows.Forms.Panel();
            this.lblToday = new System.Windows.Forms.Label();
            this._cboNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this._btnCheckIn = new Guna.UI2.WinForms.Guna2Button();
            this._btnCheckOut = new Guna.UI2.WinForms.Guna2Button();
            this._lblStatus = new System.Windows.Forms.Label();
            this.filterBar = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this._cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            this._cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this._txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this._dtpNgayFilter = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this._chkLocNgay = new System.Windows.Forms.CheckBox();
            this._btnSua = new Guna.UI2.WinForms.Guna2Button();
            this._grid = new System.Windows.Forms.DataGridView();
            this.checkPanel.SuspendLayout();
            this.filterBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // checkPanel
            // 
            this.checkPanel.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.checkPanel.Controls.Add(this.lblToday);
            this.checkPanel.Controls.Add(this._cboNhanVien);
            this.checkPanel.Controls.Add(this._btnCheckIn);
            this.checkPanel.Controls.Add(this._btnCheckOut);
            this.checkPanel.Controls.Add(this._lblStatus);
            this.checkPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkPanel.Location = new System.Drawing.Point(0, 0);
            this.checkPanel.Name = "checkPanel";
            this.checkPanel.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.checkPanel.Size = new System.Drawing.Size(1080, 110);
            this.checkPanel.TabIndex = 0;
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToday.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblToday.Location = new System.Drawing.Point(16, 12);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(105, 25);
            this.lblToday.TabIndex = 0;
            this.lblToday.Text = "📅 Ngày...";
            // 
            // _cboNhanVien
            // 
            this._cboNhanVien.BackColor = System.Drawing.Color.Transparent;
            this._cboNhanVien.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._cboNhanVien.BorderRadius = 8;
            this._cboNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboNhanVien.FillColor = System.Drawing.Color.White;
            this._cboNhanVien.FocusedColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._cboNhanVien.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cboNhanVien.ItemHeight = 34;
            this._cboNhanVien.Location = new System.Drawing.Point(16, 50);
            this._cboNhanVien.Name = "_cboNhanVien";
            this._cboNhanVien.Size = new System.Drawing.Size(340, 40);
            this._cboNhanVien.TabIndex = 1;
            // 
            // _btnCheckIn
            // 
            this._btnCheckIn.Animated = true;
            this._btnCheckIn.BorderRadius = 8;
            this._btnCheckIn.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this._btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnCheckIn.ForeColor = System.Drawing.Color.White;
            this._btnCheckIn.Location = new System.Drawing.Point(365, 50);
            this._btnCheckIn.Name = "_btnCheckIn";
            this._btnCheckIn.Size = new System.Drawing.Size(140, 40);
            this._btnCheckIn.TabIndex = 2;
            this._btnCheckIn.Text = "✅ CHECK IN";
            this._btnCheckIn.Click += new System.EventHandler(this.BtnCheckIn_Click);
            // 
            // _btnCheckOut
            // 
            this._btnCheckOut.Animated = true;
            this._btnCheckOut.BorderRadius = 8;
            this._btnCheckOut.FillColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this._btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this._btnCheckOut.ForeColor = System.Drawing.Color.White;
            this._btnCheckOut.Location = new System.Drawing.Point(512, 50);
            this._btnCheckOut.Name = "_btnCheckOut";
            this._btnCheckOut.Size = new System.Drawing.Size(140, 40);
            this._btnCheckOut.TabIndex = 3;
            this._btnCheckOut.Text = "🔴 CHECK OUT";
            this._btnCheckOut.Click += new System.EventHandler(this.BtnCheckOut_Click);
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this._lblStatus.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this._lblStatus.Location = new System.Drawing.Point(660, 60);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(0, 21);
            this._lblStatus.TabIndex = 4;
            // 
            // filterBar
            // 
            this.filterBar.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.filterBar.Controls.Add(this.lblFilter);
            this.filterBar.Controls.Add(this._cboThang);
            this.filterBar.Controls.Add(this._cboNam);
            this.filterBar.Controls.Add(this.btnXem);
            this.filterBar.Controls.Add(this._txtTimKiem);
            this.filterBar.Controls.Add(this._chkLocNgay);
            this.filterBar.Controls.Add(this._dtpNgayFilter);
            this.filterBar.Controls.Add(this._btnSua);
            this.filterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterBar.Location = new System.Drawing.Point(0, 110);
            this.filterBar.Name = "filterBar";
            this.filterBar.Size = new System.Drawing.Size(1080, 60);
            this.filterBar.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFilter.Location = new System.Drawing.Point(12, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(43, 20);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Lọc:";
            // 
            // _cboThang
            // 
            this._cboThang.BackColor = System.Drawing.Color.Transparent;
            this._cboThang.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._cboThang.BorderRadius = 6;
            this._cboThang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboThang.FillColor = System.Drawing.Color.White;
            this._cboThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboThang.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cboThang.ItemHeight = 30;
            this._cboThang.Location = new System.Drawing.Point(55, 12);
            this._cboThang.Name = "_cboThang";
            this._cboThang.Size = new System.Drawing.Size(100, 36);
            this._cboThang.TabIndex = 1;
            // 
            // _cboNam
            // 
            this._cboNam.BackColor = System.Drawing.Color.Transparent;
            this._cboNam.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._cboNam.BorderRadius = 6;
            this._cboNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboNam.FillColor = System.Drawing.Color.White;
            this._cboNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._cboNam.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cboNam.ItemHeight = 30;
            this._cboNam.Location = new System.Drawing.Point(160, 12);
            this._cboNam.Name = "_cboNam";
            this._cboNam.Size = new System.Drawing.Size(85, 36);
            this._cboNam.TabIndex = 2;
            // 
            // btnXem
            // 
            this.btnXem.Animated = true;
            this.btnXem.BorderRadius = 6;
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(250, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 36);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "🔍 Tra cứu";
            this.btnXem.Click += new System.EventHandler(this.BtnXem_Click);
            // 
            // _txtTimKiem
            // 
            this._txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._txtTimKiem.BorderRadius = 6;
            this._txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTimKiem.DefaultText = "";
            this._txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._txtTimKiem.Location = new System.Drawing.Point(360, 12);
            this._txtTimKiem.Name = "_txtTimKiem";
            this._txtTimKiem.PasswordChar = '\0';
            this._txtTimKiem.PlaceholderText = "🔍 Tìm Tên / Mã NV...";
            this._txtTimKiem.SelectedText = "";
            this._txtTimKiem.Size = new System.Drawing.Size(200, 36);
            this._txtTimKiem.TabIndex = 4;
            this._txtTimKiem.TextChanged += new System.EventHandler(this.TxtTimKiem_TextChanged);
            // 
            // _chkLocNgay
            // 
            this._chkLocNgay.AutoSize = true;
            this._chkLocNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._chkLocNgay.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this._chkLocNgay.Location = new System.Drawing.Point(570, 18);
            this._chkLocNgay.Name = "_chkLocNgay";
            this._chkLocNgay.Size = new System.Drawing.Size(95, 24);
            this._chkLocNgay.TabIndex = 5;
            this._chkLocNgay.Text = "Lọc ngày:";
            this._chkLocNgay.UseVisualStyleBackColor = true;
            this._chkLocNgay.CheckedChanged += new System.EventHandler(this.ChkLocNgay_CheckedChanged);
            // 
            // _dtpNgayFilter
            // 
            this._dtpNgayFilter.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._dtpNgayFilter.BorderRadius = 6;
            this._dtpNgayFilter.Checked = true;
            this._dtpNgayFilter.Enabled = false;
            this._dtpNgayFilter.FillColor = System.Drawing.Color.White;
            this._dtpNgayFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._dtpNgayFilter.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._dtpNgayFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpNgayFilter.Location = new System.Drawing.Point(670, 12);
            this._dtpNgayFilter.Name = "_dtpNgayFilter";
            this._dtpNgayFilter.Size = new System.Drawing.Size(130, 36);
            this._dtpNgayFilter.TabIndex = 6;
            this._dtpNgayFilter.ValueChanged += new System.EventHandler(this.DtpNgayFilter_ValueChanged);
            // 
            // _btnSua
            // 
            this._btnSua.Animated = true;
            this._btnSua.BorderRadius = 6;
            this._btnSua.FillColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this._btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._btnSua.ForeColor = System.Drawing.Color.White;
            this._btnSua.Location = new System.Drawing.Point(810, 12);
            this._btnSua.Name = "_btnSua";
            this._btnSua.Size = new System.Drawing.Size(130, 36);
            this._btnSua.TabIndex = 7;
            this._btnSua.Text = "✏️ Sửa giờ";
            this._btnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this._grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this._grid.ColumnHeadersHeight = 44;
            this._grid.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this._grid.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this._grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))), ((int)(((byte)(80)))));
            this._grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this._grid.Location = new System.Drawing.Point(0, 170);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 40;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1080, 580);
            this._grid.TabIndex = 2;
            this._grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // ChamCongPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this._grid);
            this.Controls.Add(this.filterBar);
            this.Controls.Add(this.checkPanel);
            this.Name = "ChamCongPage";
            this.Size = new System.Drawing.Size(1050, 750);
            this.checkPanel.ResumeLayout(false);
            this.checkPanel.PerformLayout();
            this.filterBar.ResumeLayout(false);
            this.filterBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel checkPanel;
        private System.Windows.Forms.Label lblToday;
        private Guna.UI2.WinForms.Guna2ComboBox _cboNhanVien;
        private Guna.UI2.WinForms.Guna2Button _btnCheckIn;
        private Guna.UI2.WinForms.Guna2Button _btnCheckOut;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Panel filterBar;
        private System.Windows.Forms.Label lblFilter;
        private Guna.UI2.WinForms.Guna2ComboBox _cboThang;
        private Guna.UI2.WinForms.Guna2ComboBox _cboNam;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2TextBox _txtTimKiem;
        private System.Windows.Forms.CheckBox _chkLocNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker _dtpNgayFilter;
        private Guna.UI2.WinForms.Guna2Button _btnSua;
        private System.Windows.Forms.DataGridView _grid;
    }
}

