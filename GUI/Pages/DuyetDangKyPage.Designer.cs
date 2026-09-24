using System.Drawing;
using System.Windows.Forms;

namespace VietLandHR.GUI.Pages
{
    partial class DuyetDangKyPage
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPending = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblDeptLbl = new System.Windows.Forms.Label();
            this.cbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPosiLbl = new System.Windows.Forms.Label();
            this.cbPosition = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(30, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(434, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Duyệt Yêu Cầu Đăng Ký Tài Khoản";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblInfo.Location = new System.Drawing.Point(30, 68);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(378, 20);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Chọn một yêu cầu, gán Phòng ban + Chức vụ rồi bấm Duyệt.";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 7;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(30, 98);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvPending
            // 
            this.dgvPending.AllowUserToAddRows = false;
            this.dgvPending.AllowUserToDeleteRows = false;
            this.dgvPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPending.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPending.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPending.BackgroundColor = System.Drawing.Color.White;
            this.dgvPending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPending.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPending.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPending.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPending.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPending.Location = new System.Drawing.Point(30, 148);
            this.dgvPending.Name = "dgvPending";
            this.dgvPending.ReadOnly = true;
            this.dgvPending.RowHeadersVisible = false;
            this.dgvPending.RowTemplate.Height = 38;
            this.dgvPending.Size = new System.Drawing.Size(990, 330);
            this.dgvPending.TabIndex = 3;
            this.dgvPending.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPending.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.dgvPending.SelectionChanged += new System.EventHandler(this.dgvPending_SelectionChanged);
            this.dgvPending.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Gray;
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", Width = 55 });
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colHoTen", HeaderText = "Họ và Tên", Width = 200 });
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", Width = 230 });
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Số ĐT", Width = 120 });
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colBirth", HeaderText = "Ngày sinh", Width = 110, DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            this.dgvPending.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCreated", HeaderText = "Ngày yêu cầu", AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill, DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Controls.Add(this.lblDeptLbl);
            this.pnlBottom.Controls.Add(this.cbDepartment);
            this.pnlBottom.Controls.Add(this.lblPosiLbl);
            this.pnlBottom.Controls.Add(this.cbPosition);
            this.pnlBottom.Controls.Add(this.btnApprove);
            this.pnlBottom.Controls.Add(this.btnReject);
            this.pnlBottom.Location = new System.Drawing.Point(30, 495);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(990, 110);
            this.pnlBottom.TabIndex = 4;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // lblDeptLbl
            // 
            this.lblDeptLbl.AutoSize = true;
            this.lblDeptLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDeptLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDeptLbl.Location = new System.Drawing.Point(15, 12);
            this.lblDeptLbl.Name = "lblDeptLbl";
            this.lblDeptLbl.Size = new System.Drawing.Size(97, 20);
            this.lblDeptLbl.TabIndex = 0;
            this.lblDeptLbl.Text = "Phòng ban *";
            // 
            // cbDepartment
            // 
            this.cbDepartment.BackColor = System.Drawing.Color.Transparent;
            this.cbDepartment.BorderRadius = 6;
            this.cbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.cbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.cbDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDepartment.ItemHeight = 30;
            this.cbDepartment.Location = new System.Drawing.Point(15, 33);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(240, 38);
            this.cbDepartment.TabIndex = 1;
            // 
            // lblPosiLbl
            // 
            this.lblPosiLbl.AutoSize = true;
            this.lblPosiLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPosiLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPosiLbl.Location = new System.Drawing.Point(285, 12);
            this.lblPosiLbl.Name = "lblPosiLbl";
            this.lblPosiLbl.Size = new System.Drawing.Size(78, 20);
            this.lblPosiLbl.TabIndex = 2;
            this.lblPosiLbl.Text = "Chức vụ *";
            // 
            // cbPosition
            // 
            this.cbPosition.BackColor = System.Drawing.Color.Transparent;
            this.cbPosition.BorderRadius = 6;
            this.cbPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosition.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.cbPosition.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.cbPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPosition.ItemHeight = 30;
            this.cbPosition.Location = new System.Drawing.Point(285, 33);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(240, 38);
            this.cbPosition.TabIndex = 3;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BorderRadius = 8;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.Location = new System.Drawing.Point(670, 28);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(150, 44);
            this.btnApprove.TabIndex = 4;
            this.btnApprove.Text = "Phê Duyệt";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.BorderRadius = 8;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.Location = new System.Drawing.Point(835, 28);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(130, 44);
            this.btnReject.TabIndex = 5;
            this.btnReject.Text = "Từ Chối";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // FrmRegistrationApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Size = new System.Drawing.Size(1050, 750);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvPending);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            
            this.Name = "DuyetDangKyPage";
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvPending)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPending;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblDeptLbl;
        private Guna.UI2.WinForms.Guna2ComboBox cbDepartment;
        private System.Windows.Forms.Label lblPosiLbl;
        private Guna.UI2.WinForms.Guna2ComboBox cbPosition;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private Guna.UI2.WinForms.Guna2Button btnReject;
    }
}

