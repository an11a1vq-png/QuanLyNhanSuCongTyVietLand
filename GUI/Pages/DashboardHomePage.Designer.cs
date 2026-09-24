namespace VietLandHR.GUI.Pages
{
    partial class DashboardHomePage
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            cardRow = new FlowLayoutPanel();
            cardTongNV = new Guna.UI2.WinForms.Guna2Panel();
            lblTongNVTitle = new Label();
            _lblTongNV = new Label();
            cardChamCong = new Guna.UI2.WinForms.Guna2Panel();
            lblChamCongTitle = new Label();
            _lblChamCongHomNay = new Label();
            cardNghiPhep = new Guna.UI2.WinForms.Guna2Panel();
            lblNghiPhepTitle = new Label();
            _lblNghiPhep = new Label();
            cardBangLuong = new Guna.UI2.WinForms.Guna2Panel();
            lblBangLuongTitle = new Label();
            _lblBangLuong = new Label();
            containerTable = new Panel();
            gridRecentNV = new DataGridView();
            lblRecent = new Label();
            cardRow.SuspendLayout();
            cardTongNV.SuspendLayout();
            cardChamCong.SuspendLayout();
            cardNghiPhep.SuspendLayout();
            cardBangLuong.SuspendLayout();
            containerTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentNV).BeginInit();
            SuspendLayout();
            // 
            // cardRow
            // 
            cardRow.BackColor = Color.Transparent;
            cardRow.Controls.Add(cardTongNV);
            cardRow.Controls.Add(cardChamCong);
            cardRow.Controls.Add(cardNghiPhep);
            cardRow.Controls.Add(cardBangLuong);
            cardRow.Dock = DockStyle.Top;
            cardRow.Location = new Point(0, 0);
            cardRow.Margin = new Padding(3, 4, 3, 4);
            cardRow.Name = "cardRow";
            cardRow.Size = new Size(1151, 186);
            cardRow.TabIndex = 0;
            cardRow.WrapContents = false;
            // 
            // cardTongNV
            // 
            cardTongNV.BackColor = Color.Transparent;
            cardTongNV.BorderRadius = 14;
            cardTongNV.Controls.Add(lblTongNVTitle);
            cardTongNV.Controls.Add(_lblTongNV);
            cardTongNV.CustomizableEdges = customizableEdges1;
            cardTongNV.FillColor = Color.White;
            cardTongNV.Location = new Point(0, 0);
            cardTongNV.Margin = new Padding(0, 0, 18, 0);
            cardTongNV.Name = "cardTongNV";
            cardTongNV.ShadowDecoration.BorderRadius = 14;
            cardTongNV.ShadowDecoration.Color = Color.FromArgb(148, 163, 184);
            cardTongNV.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cardTongNV.ShadowDecoration.Depth = 10;
            cardTongNV.ShadowDecoration.Enabled = true;
            cardTongNV.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            cardTongNV.Size = new Size(240, 146);
            cardTongNV.TabIndex = 0;
            // 
            // lblTongNVTitle
            // 
            lblTongNVTitle.AutoSize = true;
            lblTongNVTitle.BackColor = Color.Transparent;
            lblTongNVTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongNVTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblTongNVTitle.Location = new Point(23, 24);
            lblTongNVTitle.Name = "lblTongNVTitle";
            lblTongNVTitle.Size = new Size(167, 23);
            lblTongNVTitle.TabIndex = 0;
            lblTongNVTitle.Text = "👥  Tổng nhân viên";
            // 
            // _lblTongNV
            // 
            _lblTongNV.AutoSize = true;
            _lblTongNV.BackColor = Color.Transparent;
            _lblTongNV.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            _lblTongNV.ForeColor = Color.FromArgb(37, 99, 235);
            _lblTongNV.Location = new Point(23, 56);
            _lblTongNV.Name = "_lblTongNV";
            _lblTongNV.Size = new Size(66, 62);
            _lblTongNV.TabIndex = 1;
            _lblTongNV.Text = "...";
            // 
            // cardChamCong
            // 
            cardChamCong.BackColor = Color.Transparent;
            cardChamCong.BorderRadius = 14;
            cardChamCong.Controls.Add(lblChamCongTitle);
            cardChamCong.Controls.Add(_lblChamCongHomNay);
            cardChamCong.CustomizableEdges = customizableEdges3;
            cardChamCong.FillColor = Color.White;
            cardChamCong.Location = new Point(258, 0);
            cardChamCong.Margin = new Padding(0, 0, 18, 0);
            cardChamCong.Name = "cardChamCong";
            cardChamCong.ShadowDecoration.BorderRadius = 14;
            cardChamCong.ShadowDecoration.Color = Color.FromArgb(148, 163, 184);
            cardChamCong.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cardChamCong.ShadowDecoration.Depth = 10;
            cardChamCong.ShadowDecoration.Enabled = true;
            cardChamCong.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            cardChamCong.Size = new Size(248, 146);
            cardChamCong.TabIndex = 1;
            // 
            // lblChamCongTitle
            // 
            lblChamCongTitle.AutoSize = true;
            lblChamCongTitle.BackColor = Color.Transparent;
            lblChamCongTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChamCongTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblChamCongTitle.Location = new Point(23, 24);
            lblChamCongTitle.Name = "lblChamCongTitle";
            lblChamCongTitle.Size = new Size(206, 23);
            lblChamCongTitle.TabIndex = 0;
            lblChamCongTitle.Text = "🕐  Đã chấm công h.nay";
            // 
            // _lblChamCongHomNay
            // 
            _lblChamCongHomNay.AutoSize = true;
            _lblChamCongHomNay.BackColor = Color.Transparent;
            _lblChamCongHomNay.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            _lblChamCongHomNay.ForeColor = Color.FromArgb(22, 163, 74);
            _lblChamCongHomNay.Location = new Point(23, 56);
            _lblChamCongHomNay.Name = "_lblChamCongHomNay";
            _lblChamCongHomNay.Size = new Size(66, 62);
            _lblChamCongHomNay.TabIndex = 1;
            _lblChamCongHomNay.Text = "...";
            // 
            // cardNghiPhep
            // 
            cardNghiPhep.BackColor = Color.Transparent;
            cardNghiPhep.BorderRadius = 14;
            cardNghiPhep.Controls.Add(lblNghiPhepTitle);
            cardNghiPhep.Controls.Add(_lblNghiPhep);
            cardNghiPhep.CustomizableEdges = customizableEdges5;
            cardNghiPhep.FillColor = Color.White;
            cardNghiPhep.Location = new Point(524, 0);
            cardNghiPhep.Margin = new Padding(0, 0, 18, 0);
            cardNghiPhep.Name = "cardNghiPhep";
            cardNghiPhep.ShadowDecoration.BorderRadius = 14;
            cardNghiPhep.ShadowDecoration.Color = Color.FromArgb(148, 163, 184);
            cardNghiPhep.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cardNghiPhep.ShadowDecoration.Depth = 10;
            cardNghiPhep.ShadowDecoration.Enabled = true;
            cardNghiPhep.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            cardNghiPhep.Size = new Size(246, 146);
            cardNghiPhep.TabIndex = 2;
            // 
            // lblNghiPhepTitle
            // 
            lblNghiPhepTitle.AutoSize = true;
            lblNghiPhepTitle.BackColor = Color.Transparent;
            lblNghiPhepTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNghiPhepTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblNghiPhepTitle.Location = new Point(23, 24);
            lblNghiPhepTitle.Name = "lblNghiPhepTitle";
            lblNghiPhepTitle.Size = new Size(214, 23);
            lblNghiPhepTitle.TabIndex = 0;
            lblNghiPhepTitle.Text = "📋  Chờ duyệt nghỉ phép";
            // 
            // _lblNghiPhep
            // 
            _lblNghiPhep.AutoSize = true;
            _lblNghiPhep.BackColor = Color.Transparent;
            _lblNghiPhep.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            _lblNghiPhep.ForeColor = Color.FromArgb(217, 119, 6);
            _lblNghiPhep.Location = new Point(23, 56);
            _lblNghiPhep.Name = "_lblNghiPhep";
            _lblNghiPhep.Size = new Size(66, 62);
            _lblNghiPhep.TabIndex = 1;
            _lblNghiPhep.Text = "...";
            // 
            // cardBangLuong
            // 
            cardBangLuong.BackColor = Color.Transparent;
            cardBangLuong.BorderRadius = 14;
            cardBangLuong.Controls.Add(lblBangLuongTitle);
            cardBangLuong.Controls.Add(_lblBangLuong);
            cardBangLuong.CustomizableEdges = customizableEdges7;
            cardBangLuong.FillColor = Color.White;
            cardBangLuong.Location = new Point(788, 0);
            cardBangLuong.Margin = new Padding(0, 0, 18, 0);
            cardBangLuong.Name = "cardBangLuong";
            cardBangLuong.ShadowDecoration.BorderRadius = 14;
            cardBangLuong.ShadowDecoration.Color = Color.FromArgb(148, 163, 184);
            cardBangLuong.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cardBangLuong.ShadowDecoration.Depth = 10;
            cardBangLuong.ShadowDecoration.Enabled = true;
            cardBangLuong.ShadowDecoration.Shadow = new Padding(0, 0, 5, 5);
            cardBangLuong.Size = new Size(352, 146);
            cardBangLuong.TabIndex = 3;
            // 
            // lblBangLuongTitle
            // 
            lblBangLuongTitle.AutoSize = true;
            lblBangLuongTitle.BackColor = Color.Transparent;
            lblBangLuongTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBangLuongTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblBangLuongTitle.Location = new Point(23, 24);
            lblBangLuongTitle.Name = "lblBangLuongTitle";
            lblBangLuongTitle.Size = new Size(190, 23);
            lblBangLuongTitle.TabIndex = 0;
            lblBangLuongTitle.Text = "💰  Bảng lương tháng";
            // 
            // _lblBangLuong
            // 
            _lblBangLuong.AutoSize = true;
            _lblBangLuong.BackColor = Color.Transparent;
            _lblBangLuong.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            _lblBangLuong.ForeColor = Color.FromArgb(225, 29, 72);
            _lblBangLuong.Location = new Point(23, 56);
            _lblBangLuong.Name = "_lblBangLuong";
            _lblBangLuong.Size = new Size(66, 62);
            _lblBangLuong.TabIndex = 1;
            _lblBangLuong.Text = "...";
            // 
            // containerTable
            // 
            containerTable.Controls.Add(gridRecentNV);
            containerTable.Controls.Add(lblRecent);
            containerTable.Dock = DockStyle.Fill;
            containerTable.Location = new Point(0, 186);
            containerTable.Margin = new Padding(3, 4, 3, 4);
            containerTable.Name = "containerTable";
            containerTable.Size = new Size(1151, 614);
            containerTable.TabIndex = 1;
            // 
            // gridRecentNV
            // 
            gridRecentNV.AllowUserToAddRows = false;
            gridRecentNV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            gridRecentNV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridRecentNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridRecentNV.BackgroundColor = Color.White;
            gridRecentNV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(67, 56, 202);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(67, 56, 202);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridRecentNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridRecentNV.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(49, 46, 129);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridRecentNV.DefaultCellStyle = dataGridViewCellStyle3;
            gridRecentNV.Dock = DockStyle.Fill;
            gridRecentNV.GridColor = Color.FromArgb(241, 245, 249);
            gridRecentNV.Location = new Point(0, 0);
            gridRecentNV.Margin = new Padding(3, 4, 3, 4);
            gridRecentNV.Name = "gridRecentNV";
            gridRecentNV.ReadOnly = true;
            gridRecentNV.RowHeadersVisible = false;
            gridRecentNV.RowHeadersWidth = 62;
            gridRecentNV.RowTemplate.Height = 44;
            gridRecentNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRecentNV.Size = new Size(1151, 614);
            gridRecentNV.TabIndex = 0;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(15, 23, 42);
            lblRecent.Location = new Point(0, 10);
            lblRecent.Name = "lblRecent";
            lblRecent.Size = new Size(216, 30);
            lblRecent.TabIndex = 1;
            lblRecent.Text = "Nhân viên mới nhất";
            // 
            // DashboardHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(containerTable);
            Controls.Add(cardRow);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DashboardHomePage";
            Size = new Size(1151, 800);
            cardRow.ResumeLayout(false);
            cardTongNV.ResumeLayout(false);
            cardTongNV.PerformLayout();
            cardChamCong.ResumeLayout(false);
            cardChamCong.PerformLayout();
            cardNghiPhep.ResumeLayout(false);
            cardNghiPhep.PerformLayout();
            cardBangLuong.ResumeLayout(false);
            cardBangLuong.PerformLayout();
            containerTable.ResumeLayout(false);
            containerTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentNV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cardRow;
        private Guna.UI2.WinForms.Guna2Panel cardTongNV;
        private System.Windows.Forms.Label lblTongNVTitle;
        private System.Windows.Forms.Label _lblTongNV;
        private Guna.UI2.WinForms.Guna2Panel cardChamCong;
        private System.Windows.Forms.Label lblChamCongTitle;
        private System.Windows.Forms.Label _lblChamCongHomNay;
        private Guna.UI2.WinForms.Guna2Panel cardNghiPhep;
        private System.Windows.Forms.Label lblNghiPhepTitle;
        private System.Windows.Forms.Label _lblNghiPhep;
        private Guna.UI2.WinForms.Guna2Panel cardBangLuong;
        private System.Windows.Forms.Label lblBangLuongTitle;
        private System.Windows.Forms.Label _lblBangLuong;
        private System.Windows.Forms.Panel containerTable;
        private System.Windows.Forms.DataGridView gridRecentNV;
        private System.Windows.Forms.Label lblRecent;
    }
}

