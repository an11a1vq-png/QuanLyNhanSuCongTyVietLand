namespace VietLandHR.GUI.Dialogs
{
    partial class SuaChamCongDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckInDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpCheckInTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckOutDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpCheckOutTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(460, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ ĐIỀU CHỈNH CHẤM CÔNG";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblInfo.Location = new System.Drawing.Point(25, 65);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(410, 45);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Nhân viên: ...";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCheckIn.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCheckIn.Location = new System.Drawing.Point(25, 120);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(124, 21);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "⏱️ Giờ Check-in:";
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dtpCheckInDate.BorderRadius = 8;
            this.dtpCheckInDate.Checked = true;
            this.dtpCheckInDate.FillColor = System.Drawing.Color.White;
            this.dtpCheckInDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpCheckInDate.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dtpCheckInDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckInDate.Location = new System.Drawing.Point(25, 145);
            this.dtpCheckInDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckInDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(220, 40);
            this.dtpCheckInDate.TabIndex = 3;
            // 
            // dtpCheckInTime
            // 
            this.dtpCheckInTime.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dtpCheckInTime.BorderRadius = 8;
            this.dtpCheckInTime.Checked = true;
            this.dtpCheckInTime.FillColor = System.Drawing.Color.White;
            this.dtpCheckInTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpCheckInTime.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dtpCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCheckInTime.Location = new System.Drawing.Point(255, 145);
            this.dtpCheckInTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckInTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckInTime.Name = "dtpCheckInTime";
            this.dtpCheckInTime.ShowUpDown = true;
            this.dtpCheckInTime.Size = new System.Drawing.Size(180, 40);
            this.dtpCheckInTime.TabIndex = 4;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCheckOut.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCheckOut.Location = new System.Drawing.Point(25, 200);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(136, 21);
            this.lblCheckOut.TabIndex = 5;
            this.lblCheckOut.Text = "⌛ Giờ Check-out:";
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dtpCheckOutDate.BorderRadius = 8;
            this.dtpCheckOutDate.Checked = true;
            this.dtpCheckOutDate.FillColor = System.Drawing.Color.White;
            this.dtpCheckOutDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpCheckOutDate.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dtpCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOutDate.Location = new System.Drawing.Point(25, 225);
            this.dtpCheckOutDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOutDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(220, 40);
            this.dtpCheckOutDate.TabIndex = 6;
            // 
            // dtpCheckOutTime
            // 
            this.dtpCheckOutTime.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dtpCheckOutTime.BorderRadius = 8;
            this.dtpCheckOutTime.Checked = true;
            this.dtpCheckOutTime.FillColor = System.Drawing.Color.White;
            this.dtpCheckOutTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpCheckOutTime.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dtpCheckOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCheckOutTime.Location = new System.Drawing.Point(255, 225);
            this.dtpCheckOutTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOutTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckOutTime.Name = "dtpCheckOutTime";
            this.dtpCheckOutTime.ShowUpDown = true;
            this.dtpCheckOutTime.Size = new System.Drawing.Size(180, 40);
            this.dtpCheckOutTime.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatus.Location = new System.Drawing.Point(25, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 21);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "📌 Trạng thái:";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.cboStatus.BorderRadius = 8;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FillColor = System.Drawing.Color.White;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.cboStatus.ItemHeight = 34;
            this.cboStatus.Items.AddRange(new object[] {
            "Present",
            "Late",
            "Absent",
            "OnLeave"});
            this.cboStatus.Location = new System.Drawing.Point(25, 305);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(410, 40);
            this.cboStatus.TabIndex = 9;
            // 
            // btnLuu
            // 
            this.btnLuu.Animated = true;
            this.btnLuu.BorderRadius = 8;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(67, 56, 202);
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(285, 370);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 42);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "💾 Lưu thay đổi";
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Animated = true;
            this.btnHuy.BorderRadius = 8;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnHuy.Location = new System.Drawing.Point(155, 370);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // SuaChamCongDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.ClientSize = new System.Drawing.Size(460, 430);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpCheckOutTime);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.dtpCheckInTime);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SuaChamCongDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Điều chỉnh chấm công";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblCheckIn;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckInDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckInTime;
        private System.Windows.Forms.Label lblCheckOut;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOutDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOutTime;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}

