namespace VietLandHR.GUI.Pages.Employee
{
    partial class EmpHopDongPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this._grid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hợp đồng của tôi";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this._grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._grid.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._grid.DefaultCellStyle = dataGridViewCellStyle3;
            this._grid.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this._grid.Location = new System.Drawing.Point(30, 80);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.RowHeadersVisible = false;
            this._grid.RowTemplate.Height = 40;
            this._grid.Size = new System.Drawing.Size(940, 560);
            this._grid.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlHeader.Controls.Add(this.lblTitle);
            // 
            // pnlBottom
            // 
            this.pnlBottom.FillColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.pnlBottom.BorderRadius = 12;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(15);
            this.pnlBottom.Controls.Add(this._grid);
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpacer.Height = 15;
            this.pnlSpacer.BackColor = System.Drawing.Color.Transparent;
            // 
            // EmpHopDongPage
            // 
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(197, 210, 246);
            this.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlSpacer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "EmpHopDongPage";
            this.Size = new System.Drawing.Size(1000, 680);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView _grid;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlBottom;
        private System.Windows.Forms.Panel pnlSpacer;
    }
}


