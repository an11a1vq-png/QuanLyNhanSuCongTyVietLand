namespace VietLandHR.GUI.Dialogs
{
    partial class PhongBanDialog
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
            lblTitle = new Label();
            tbl = new TableLayoutPanel();
            lblTenPB = new Label();
            txtTenPB = new Guna.UI2.WinForms.Guna2TextBox();
            lblTruongPhong = new Label();
            cboTruongPhong = new Guna.UI2.WinForms.Guna2ComboBox();
            pnlBtns = new Panel();
            btnLuu = new Guna.UI2.WinForms.Guna2Button();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();
            tbl.SuspendLayout();
            pnlBtns.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(15, 23, 42);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(20, 12, 0, 0);
            lblTitle.Size = new Size(435, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Phòng ban";
            // 
            // tbl
            // 
            tbl.BackColor = Color.White;
            tbl.ColumnCount = 2;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl.Controls.Add(lblTenPB, 0, 0);
            tbl.Controls.Add(txtTenPB, 1, 0);
            tbl.Controls.Add(lblTruongPhong, 0, 1);
            tbl.Controls.Add(cboTruongPhong, 1, 1);
            tbl.Dock = DockStyle.Fill;
            tbl.Location = new Point(0, 50);
            tbl.Name = "tbl";
            tbl.Padding = new Padding(20, 10, 20, 10);
            tbl.RowCount = 2;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tbl.Size = new Size(435, 120);
            tbl.TabIndex = 0;
            // 
            // lblTenPB
            // 
            lblTenPB.AutoSize = true;
            lblTenPB.Font = new Font("Segoe UI", 9.5F);
            lblTenPB.ForeColor = Color.FromArgb(15, 23, 42);
            lblTenPB.Location = new Point(20, 18);
            lblTenPB.Margin = new Padding(0, 8, 8, 0);
            lblTenPB.Name = "lblTenPB";
            lblTenPB.Size = new Size(112, 21);
            lblTenPB.TabIndex = 0;
            lblTenPB.Text = "Tên phòng ban *";
            // 
            // txtTenPB
            // 
            txtTenPB.BorderColor = Color.FromArgb(203, 213, 225);
            txtTenPB.BorderRadius = 6;
            txtTenPB.CustomizableEdges = customizableEdges1;
            txtTenPB.DefaultText = "";
            txtTenPB.Dock = DockStyle.Fill;
            txtTenPB.FillColor = Color.White;
            txtTenPB.Font = new Font("Segoe UI", 9F);
            txtTenPB.ForeColor = Color.FromArgb(15, 23, 42);
            txtTenPB.Location = new Point(150, 14);
            txtTenPB.Margin = new Padding(0, 4, 0, 4);
            txtTenPB.Name = "txtTenPB";
            txtTenPB.PlaceholderText = "";
            txtTenPB.SelectedText = "";
            txtTenPB.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTenPB.Size = new Size(265, 38);
            txtTenPB.TabIndex = 1;
            // 
            // lblTruongPhong
            // 
            lblTruongPhong.AutoSize = true;
            lblTruongPhong.Font = new Font("Segoe UI", 9.5F);
            lblTruongPhong.ForeColor = Color.FromArgb(15, 23, 42);
            lblTruongPhong.Location = new Point(20, 64);
            lblTruongPhong.Margin = new Padding(0, 8, 8, 0);
            lblTruongPhong.Name = "lblTruongPhong";
            lblTruongPhong.Size = new Size(100, 21);
            lblTruongPhong.TabIndex = 2;
            lblTruongPhong.Text = "Trưởng phòng";
            // 
            // cboTruongPhong
            // 
            cboTruongPhong.BackColor = Color.Transparent;
            cboTruongPhong.BorderColor = Color.FromArgb(203, 213, 225);
            cboTruongPhong.BorderRadius = 6;
            cboTruongPhong.DrawMode = DrawMode.OwnerDrawFixed;
            cboTruongPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTruongPhong.FillColor = Color.White;
            cboTruongPhong.Font = new Font("Segoe UI", 9F);
            cboTruongPhong.ForeColor = Color.FromArgb(15, 23, 42);
            cboTruongPhong.ItemHeight = 30;
            cboTruongPhong.Location = new Point(150, 60);
            cboTruongPhong.Margin = new Padding(0, 4, 0, 4);
            cboTruongPhong.Name = "cboTruongPhong";
            cboTruongPhong.Size = new Size(265, 36);
            cboTruongPhong.TabIndex = 3;
            // 
            // pnlBtns
            // 
            pnlBtns.BackColor = Color.FromArgb(248, 250, 252);
            pnlBtns.Controls.Add(btnLuu);
            pnlBtns.Controls.Add(btnHuy);
            pnlBtns.Dock = DockStyle.Bottom;
            pnlBtns.Location = new Point(0, 184);
            pnlBtns.Name = "pnlBtns";
            pnlBtns.Padding = new Padding(15, 10, 15, 10);
            pnlBtns.Size = new Size(435, 56);
            pnlBtns.TabIndex = 2;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BorderRadius = 7;
            btnLuu.CustomizableEdges = customizableEdges3;
            btnLuu.FillColor = Color.FromArgb(37, 99, 235);
            btnLuu.Font = new Font("Segoe UI", 9F);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(205, 10);
            btnLuu.Name = "btnLuu";
            btnLuu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLuu.Size = new Size(100, 36);
            btnLuu.TabIndex = 0;
            btnLuu.Text = "Lưu";
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHuy.BorderRadius = 7;
            btnHuy.CustomizableEdges = customizableEdges5;
            btnHuy.FillColor = Color.FromArgb(71, 85, 105);
            btnHuy.Font = new Font("Segoe UI", 9F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(315, 10);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnHuy.Size = new Size(100, 36);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "Hủy";
            btnHuy.Click += BtnHuy_Click;
            // 
            // PhongBanDialog
            // 
            BackColor = Color.White;
            ClientSize = new Size(435, 240);
            Controls.Add(tbl);
            Controls.Add(lblTitle);
            Controls.Add(pnlBtns);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PhongBanDialog";
            StartPosition = FormStartPosition.CenterParent;
            tbl.ResumeLayout(false);
            tbl.PerformLayout();
            pnlBtns.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Panel pnlBtns;
        private Guna.UI2.WinForms.Guna2TextBox txtTenPB;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private System.Windows.Forms.Label lblTenPB;
        private System.Windows.Forms.Label lblTruongPhong;
        private Guna.UI2.WinForms.Guna2ComboBox cboTruongPhong;
    }
}

