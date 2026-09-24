namespace VietLandHR.GUI.Pages
{
    partial class GopYPage
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

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnExport = new Guna.UI2.WinForms.Guna2Button();
            cboTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            lblLoc = new Label();
            lblTitle = new Label();
            pnlGrid = new Panel();
            grid = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Transparent;
            pnlTop.Controls.Add(btnExport);
            pnlTop.Controls.Add(cboTrangThai);
            pnlTop.Controls.Add(lblLoc);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(20);
            pnlTop.Size = new Size(1050, 100);
            pnlTop.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.BorderRadius = 7;
            btnExport.CustomizableEdges = customizableEdges1;
            btnExport.FillColor = Color.FromArgb(16, 185, 129);
            btnExport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(330, 58);
            btnExport.Name = "btnExport";
            btnExport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnExport.Size = new Size(130, 36);
            btnExport.TabIndex = 3;
            btnExport.Text = "📊 Xuất Excel";
            // 
            // cboTrangThai
            // 
            cboTrangThai.BackColor = Color.Transparent;
            cboTrangThai.BorderColor = Color.FromArgb(203, 213, 225);
            cboTrangThai.BorderRadius = 6;
            cboTrangThai.CustomizableEdges = customizableEdges3;
            cboTrangThai.DrawMode = DrawMode.OwnerDrawFixed;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FocusedColor = Color.Empty;
            cboTrangThai.Font = new Font("Segoe UI", 9.5F);
            cboTrangThai.ForeColor = Color.FromArgb(15, 23, 42);
            cboTrangThai.ItemHeight = 30;
            cboTrangThai.Items.AddRange(new object[] { "Tất cả", "Chờ phản hồi", "Đã phản hồi" });
            cboTrangThai.Location = new Point(125, 58);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboTrangThai.Size = new Size(190, 36);
            cboTrangThai.TabIndex = 2;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLoc.ForeColor = Color.FromArgb(71, 85, 105);
            lblLoc.Location = new Point(11, 59);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(108, 21);
            lblLoc.TabIndex = 1;
            lblLoc.Text = "Lọc trạng thái:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(369, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ GÓP Ý && YÊU CẦU";
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.Transparent;
            pnlGrid.Controls.Add(grid);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 100);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20, 0, 20, 20);
            pnlGrid.Size = new Size(1050, 650);
            pnlGrid.TabIndex = 1;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            grid.DefaultCellStyle = dataGridViewCellStyle2;
            grid.Dock = DockStyle.Fill;
            grid.GridColor = Color.FromArgb(231, 229, 255);
            grid.Location = new Point(20, 0);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.RowHeadersWidth = 51;
            grid.RowTemplate.Height = 40;
            grid.Size = new Size(1010, 630);
            grid.TabIndex = 0;
            grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            grid.ThemeStyle.HeaderStyle.Height = 40;
            grid.ThemeStyle.ReadOnly = true;
            grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            grid.ThemeStyle.RowsStyle.Height = 40;
            // 
            // GopYPage
            // 
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);
            Name = "GopYPage";
            Size = new Size(1050, 750);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private System.Windows.Forms.Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2DataGridView grid;
    }
}

