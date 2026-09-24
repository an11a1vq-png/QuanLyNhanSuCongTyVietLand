namespace VietLandHR.GUI.Pages
{
    partial class TinhLuongPage
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
            this.lblT = new System.Windows.Forms.Label();
            this._cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            this._cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnTinh = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this._lblTongQuy = new System.Windows.Forms.Label();
            this.summaryBar = new System.Windows.Forms.Panel();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlStatNhanVien = new System.Windows.Forms.Panel();
            this.lblStatNhanVienTitle = new System.Windows.Forms.Label();
            this.lblStatNhanVienVal = new System.Windows.Forms.Label();
            this.pnlStatNgayCong = new System.Windows.Forms.Panel();
            this.lblStatNgayCongTitle = new System.Windows.Forms.Label();
            this.lblStatNgayCongVal = new System.Windows.Forms.Label();
            this.pnlStatQuyLuong = new System.Windows.Forms.Panel();
            this.lblStatQuyLuongTitle = new System.Windows.Forms.Label();
            this.lblStatQuyLuongVal = new System.Windows.Forms.Label();
            this.pnlStatThue = new System.Windows.Forms.Panel();
            this.lblStatThueTitle = new System.Windows.Forms.Label();
            this.lblStatThueVal = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this.toolbar.SuspendLayout();
            this.summaryBar.SuspendLayout();
            this.flow.SuspendLayout();
            this.pnlStatNhanVien.SuspendLayout();
            this.pnlStatNgayCong.SuspendLayout();
            this.pnlStatQuyLuong.SuspendLayout();
            this.pnlStatThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.toolbar.Controls.Add(this.lblT);
            this.toolbar.Controls.Add(this._cboThang);
            this.toolbar.Controls.Add(this._cboNam);
            this.toolbar.Controls.Add(this.btnTinh);
            this.toolbar.Controls.Add(this.btnLuu);
            this.toolbar.Controls.Add(this.btnXem);
            this.toolbar.Controls.Add(this.btnExportExcel);
            this.toolbar.Controls.Add(this._lblTongQuy);
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1080, 66);
            this.toolbar.TabIndex = 0;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblT.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblT.Location = new System.Drawing.Point(12, 22);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(50, 19);
            this.lblT.TabIndex = 0;
            this.lblT.Text = "Tháng:";
            // 
            // _cboThang
            // 
            this._cboThang.BackColor = System.Drawing.Color.Transparent;
            this._cboThang.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._cboThang.BorderRadius = 8;
            this._cboThang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboThang.FillColor = System.Drawing.Color.White;
            this._cboThang.FocusedColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._cboThang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._cboThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cboThang.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cboThang.ItemHeight = 34;
            this._cboThang.Location = new System.Drawing.Point(68, 12);
            this._cboThang.Name = "_cboThang";
            this._cboThang.Size = new System.Drawing.Size(110, 40);
            this._cboThang.TabIndex = 1;
            // 
            // _cboNam
            // 
            this._cboNam.BackColor = System.Drawing.Color.Transparent;
            this._cboNam.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this._cboNam.BorderRadius = 8;
            this._cboNam.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboNam.FillColor = System.Drawing.Color.White;
            this._cboNam.FocusedColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._cboNam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this._cboNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._cboNam.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this._cboNam.ItemHeight = 34;
            this._cboNam.Location = new System.Drawing.Point(184, 12);
            this._cboNam.Name = "_cboNam";
            this._cboNam.Size = new System.Drawing.Size(90, 40);
            this._cboNam.TabIndex = 2;
            // 
            // btnTinh
            // 
            this.btnTinh.Animated = true;
            this.btnTinh.BorderRadius = 10;
            this.btnTinh.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnTinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTinh.ForeColor = System.Drawing.Color.White;
            this.btnTinh.HoverState.FillColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnTinh.Location = new System.Drawing.Point(286, 11);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(190, 42);
            this.btnTinh.TabIndex = 3;
            this.btnTinh.Text = "⚡  Tính lương tự động";
            this.btnTinh.Click += new System.EventHandler(this.BtnTinh_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Animated = true;
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.FillColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnLuu.Location = new System.Drawing.Point(482, 11);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(170, 42);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "💾  Lưu bảng lương";
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // btnXem
            // 
            this.btnXem.Animated = true;
            this.btnXem.BorderRadius = 10;
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.HoverState.FillColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnXem.Location = new System.Drawing.Point(658, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(140, 42);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "📊  Xem đã lưu";
            this.btnXem.Click += new System.EventHandler(this.BtnXem_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Animated = true;
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.HoverState.FillColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.btnExportExcel.Location = new System.Drawing.Point(806, 11);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(140, 42);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "📥  Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // _lblTongQuy
            // 
            this._lblTongQuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblTongQuy.AutoSize = true;
            this._lblTongQuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this._lblTongQuy.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this._lblTongQuy.Location = new System.Drawing.Point(820, 22);
            this._lblTongQuy.Name = "_lblTongQuy";
            this._lblTongQuy.Size = new System.Drawing.Size(0, 19);
            this._lblTongQuy.TabIndex = 6;
            // 
            // summaryBar
            // 
            this.summaryBar.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.summaryBar.Controls.Add(this.flow);
            this.summaryBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.summaryBar.Location = new System.Drawing.Point(0, 66);
            this.summaryBar.Name = "summaryBar";
            this.summaryBar.Size = new System.Drawing.Size(1080, 80);
            this.summaryBar.TabIndex = 1;
            // 
            // flow
            // 
            this.flow.Controls.Add(this.pnlStatNhanVien);
            this.flow.Controls.Add(this.pnlStatNgayCong);
            this.flow.Controls.Add(this.pnlStatQuyLuong);
            this.flow.Controls.Add(this.pnlStatThue);
            this.flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow.Location = new System.Drawing.Point(0, 0);
            this.flow.Name = "flow";
            this.flow.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.flow.Size = new System.Drawing.Size(1080, 80);
            this.flow.TabIndex = 0;
            // 
            // pnlStatNhanVien
            // 
            this.pnlStatNhanVien.BackColor = System.Drawing.Color.White;
            this.pnlStatNhanVien.Controls.Add(this.lblStatNhanVienTitle);
            this.pnlStatNhanVien.Controls.Add(this.lblStatNhanVienVal);
            this.pnlStatNhanVien.Location = new System.Drawing.Point(15, 13);
            this.pnlStatNhanVien.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.pnlStatNhanVien.Name = "pnlStatNhanVien";
            this.pnlStatNhanVien.Size = new System.Drawing.Size(220, 58);
            this.pnlStatNhanVien.TabIndex = 0;
            // 
            // lblStatNhanVienTitle
            // 
            this.lblStatNhanVienTitle.AutoSize = true;
            this.lblStatNhanVienTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatNhanVienTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatNhanVienTitle.Location = new System.Drawing.Point(12, 6);
            this.lblStatNhanVienTitle.Name = "lblStatNhanVienTitle";
            this.lblStatNhanVienTitle.Size = new System.Drawing.Size(84, 13);
            this.lblStatNhanVienTitle.TabIndex = 0;
            this.lblStatNhanVienTitle.Text = "💼 Số nhân viên";
            // 
            // lblStatNhanVienVal
            // 
            this.lblStatNhanVienVal.AutoSize = true;
            this.lblStatNhanVienVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatNhanVienVal.ForeColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.lblStatNhanVienVal.Location = new System.Drawing.Point(12, 26);
            this.lblStatNhanVienVal.Name = "lblStatNhanVienVal";
            this.lblStatNhanVienVal.Size = new System.Drawing.Size(33, 25);
            this.lblStatNhanVienVal.TabIndex = 1;
            this.lblStatNhanVienVal.Text = "—";
            // 
            // pnlStatNgayCong
            // 
            this.pnlStatNgayCong.BackColor = System.Drawing.Color.White;
            this.pnlStatNgayCong.Controls.Add(this.lblStatNgayCongTitle);
            this.pnlStatNgayCong.Controls.Add(this.lblStatNgayCongVal);
            this.pnlStatNgayCong.Location = new System.Drawing.Point(250, 13);
            this.pnlStatNgayCong.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.pnlStatNgayCong.Name = "pnlStatNgayCong";
            this.pnlStatNgayCong.Size = new System.Drawing.Size(220, 58);
            this.pnlStatNgayCong.TabIndex = 1;
            // 
            // lblStatNgayCongTitle
            // 
            this.lblStatNgayCongTitle.AutoSize = true;
            this.lblStatNgayCongTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatNgayCongTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatNgayCongTitle.Location = new System.Drawing.Point(12, 6);
            this.lblStatNgayCongTitle.Name = "lblStatNgayCongTitle";
            this.lblStatNgayCongTitle.Size = new System.Drawing.Size(91, 13);
            this.lblStatNgayCongTitle.TabIndex = 0;
            this.lblStatNgayCongTitle.Text = "📅 Ngày công TB";
            // 
            // lblStatNgayCongVal
            // 
            this.lblStatNgayCongVal.AutoSize = true;
            this.lblStatNgayCongVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatNgayCongVal.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblStatNgayCongVal.Location = new System.Drawing.Point(12, 26);
            this.lblStatNgayCongVal.Name = "lblStatNgayCongVal";
            this.lblStatNgayCongVal.Size = new System.Drawing.Size(33, 25);
            this.lblStatNgayCongVal.TabIndex = 1;
            this.lblStatNgayCongVal.Text = "—";
            // 
            // pnlStatQuyLuong
            // 
            this.pnlStatQuyLuong.BackColor = System.Drawing.Color.White;
            this.pnlStatQuyLuong.Controls.Add(this.lblStatQuyLuongTitle);
            this.pnlStatQuyLuong.Controls.Add(this.lblStatQuyLuongVal);
            this.pnlStatQuyLuong.Location = new System.Drawing.Point(485, 13);
            this.pnlStatQuyLuong.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.pnlStatQuyLuong.Name = "pnlStatQuyLuong";
            this.pnlStatQuyLuong.Size = new System.Drawing.Size(220, 58);
            this.pnlStatQuyLuong.TabIndex = 2;
            // 
            // lblStatQuyLuongTitle
            // 
            this.lblStatQuyLuongTitle.AutoSize = true;
            this.lblStatQuyLuongTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatQuyLuongTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatQuyLuongTitle.Location = new System.Drawing.Point(12, 6);
            this.lblStatQuyLuongTitle.Name = "lblStatQuyLuongTitle";
            this.lblStatQuyLuongTitle.Size = new System.Drawing.Size(95, 13);
            this.lblStatQuyLuongTitle.TabIndex = 0;
            this.lblStatQuyLuongTitle.Text = "💰 Tổng quỹ lương";
            // 
            // lblStatQuyLuongVal
            // 
            this.lblStatQuyLuongVal.AutoSize = true;
            this.lblStatQuyLuongVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatQuyLuongVal.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblStatQuyLuongVal.Location = new System.Drawing.Point(12, 26);
            this.lblStatQuyLuongVal.Name = "lblStatQuyLuongVal";
            this.lblStatQuyLuongVal.Size = new System.Drawing.Size(33, 25);
            this.lblStatQuyLuongVal.TabIndex = 1;
            this.lblStatQuyLuongVal.Text = "—";
            // 
            // pnlStatThue
            // 
            this.pnlStatThue.BackColor = System.Drawing.Color.White;
            this.pnlStatThue.Controls.Add(this.lblStatThueTitle);
            this.pnlStatThue.Controls.Add(this.lblStatThueVal);
            this.pnlStatThue.Location = new System.Drawing.Point(720, 13);
            this.pnlStatThue.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);
            this.pnlStatThue.Name = "pnlStatThue";
            this.pnlStatThue.Size = new System.Drawing.Size(220, 58);
            this.pnlStatThue.TabIndex = 3;
            // 
            // lblStatThueTitle
            // 
            this.lblStatThueTitle.AutoSize = true;
            this.lblStatThueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatThueTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatThueTitle.Location = new System.Drawing.Point(12, 6);
            this.lblStatThueTitle.Name = "lblStatThueTitle";
            this.lblStatThueTitle.Size = new System.Drawing.Size(73, 13);
            this.lblStatThueTitle.TabIndex = 0;
            this.lblStatThueTitle.Text = "📌 Tổng thuế";
            // 
            // lblStatThueVal
            // 
            this.lblStatThueVal.AutoSize = true;
            this.lblStatThueVal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatThueVal.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblStatThueVal.Location = new System.Drawing.Point(12, 26);
            this.lblStatThueVal.Name = "lblStatThueVal";
            this.lblStatThueVal.Size = new System.Drawing.Size(33, 25);
            this.lblStatThueVal.TabIndex = 1;
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.BackgroundColor = System.Drawing.Color.White;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this._grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
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
            this._grid.Location = new System.Drawing.Point(0, 146);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 42;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(1080, 604);
            this._grid.TabIndex = 2;
            // 
            // TinhLuongPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this._grid);
            this.Controls.Add(this.summaryBar);
            this.Controls.Add(this.toolbar);
            this.Name = "TinhLuongPage";
            this.Size = new System.Drawing.Size(1050, 750);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.summaryBar.ResumeLayout(false);
            this.flow.ResumeLayout(false);
            this.pnlStatNhanVien.ResumeLayout(false);
            this.pnlStatNhanVien.PerformLayout();
            this.pnlStatNgayCong.ResumeLayout(false);
            this.pnlStatNgayCong.PerformLayout();
            this.pnlStatQuyLuong.ResumeLayout(false);
            this.pnlStatQuyLuong.PerformLayout();
            this.pnlStatThue.ResumeLayout(false);
            this.pnlStatThue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel toolbar;
        private System.Windows.Forms.Label lblT;
        private Guna.UI2.WinForms.Guna2ComboBox _cboThang;
        private Guna.UI2.WinForms.Guna2ComboBox _cboNam;
        private Guna.UI2.WinForms.Guna2Button btnTinh;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.Label _lblTongQuy;
        private System.Windows.Forms.Panel summaryBar;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Panel pnlStatNhanVien;
        private System.Windows.Forms.Label lblStatNhanVienTitle;
        private System.Windows.Forms.Label lblStatNhanVienVal;
        private System.Windows.Forms.Panel pnlStatNgayCong;
        private System.Windows.Forms.Label lblStatNgayCongTitle;
        private System.Windows.Forms.Label lblStatNgayCongVal;
        private System.Windows.Forms.Panel pnlStatQuyLuong;
        private System.Windows.Forms.Label lblStatQuyLuongTitle;
        private System.Windows.Forms.Label lblStatQuyLuongVal;
        private System.Windows.Forms.Panel pnlStatThue;
        private System.Windows.Forms.Label lblStatThueTitle;
        private System.Windows.Forms.Label lblStatThueVal;
        private System.Windows.Forms.DataGridView _grid;
    }
}

