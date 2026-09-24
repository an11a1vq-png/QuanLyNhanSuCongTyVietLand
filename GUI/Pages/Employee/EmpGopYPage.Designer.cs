namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpGopYPage
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTieuDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnGui = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grid = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.FillColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlTop.BorderRadius = 12;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.txtTieuDe);
            this.pnlTop.Controls.Add(this.txtNoiDung);
            this.pnlTop.Controls.Add(this.btnGui);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTop.Size = new System.Drawing.Size(1000, 260);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "GỬI GÓP Ý / YÊU CẦU";

            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieuDe.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtTieuDe.BorderRadius = 6;
            this.txtTieuDe.CustomizableEdges = customizableEdges1;
            this.txtTieuDe.DefaultText = "";
            this.txtTieuDe.FillColor = System.Drawing.Color.White;
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTieuDe.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtTieuDe.Location = new System.Drawing.Point(20, 60);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtTieuDe.PlaceholderText = "Tiêu đề";
            this.txtTieuDe.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.txtTieuDe.Size = new System.Drawing.Size(960, 40);
            this.txtTieuDe.TabIndex = 1;

            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDung.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtNoiDung.BorderRadius = 6;
            this.txtNoiDung.CustomizableEdges = customizableEdges3;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.FillColor = System.Drawing.Color.White;
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDung.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtNoiDung.Location = new System.Drawing.Point(20, 110);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtNoiDung.PlaceholderText = "Nội dung";
            this.txtNoiDung.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.txtNoiDung.Size = new System.Drawing.Size(960, 90);
            this.txtNoiDung.TabIndex = 2;

            // 
            // btnGui
            // 
            this.btnGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGui.Animated = true;
            this.btnGui.BorderRadius = 6;
            this.btnGui.CustomizableEdges = customizableEdges5;
            this.btnGui.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnGui.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGui.ForeColor = System.Drawing.Color.White;
            this.btnGui.Location = new System.Drawing.Point(880, 210);
            this.btnGui.Name = "btnGui";
            this.btnGui.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.btnGui.Size = new System.Drawing.Size(100, 40);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "Gửi";
            this.btnGui.Click += new System.EventHandler(this.BtnGui_Click);

            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 260);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.pnlGrid.Size = new System.Drawing.Size(1000, 440);
            this.pnlGrid.TabIndex = 1;

            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.grid.Location = new System.Drawing.Point(20, 0);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 40;
            this.grid.Size = new System.Drawing.Size(960, 420);
            this.grid.TabIndex = 0;

            // 
            // EmpGopYPage
            // 
            this.BackColor = System.Drawing.Color.FromArgb(197, 210, 246);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Name = "EmpGopYPage";
            this.Size = new System.Drawing.Size(1000, 700);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtTieuDe;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private Guna.UI2.WinForms.Guna2Button btnGui;
        private System.Windows.Forms.Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2DataGridView grid;
    }
}

