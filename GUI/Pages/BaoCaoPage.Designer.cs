namespace VietLandHR.GUI.Pages
{
    partial class BaoCaoPage
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
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend3 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaoCaoPage));
            LiveChartsCore.Drawing.Padding padding5 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip3 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding6 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend4 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding7 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip4 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding8 = new LiveChartsCore.Drawing.Padding();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            header = new Label();
            cardFlow = new FlowLayoutPanel();
            pnlCardTotalEmp = new Panel();
            lblCardTotalEmpTitle = new Label();
            lblCardTotalEmpVal = new Label();
            pnlCardActiveEmp = new Panel();
            lblCardActiveEmpTitle = new Label();
            lblCardActiveEmpVal = new Label();
            pnlCardPendingLeave = new Panel();
            lblCardPendingLeaveTitle = new Label();
            lblCardPendingLeaveVal = new Label();
            pnlCardTotalSalary = new Panel();
            lblCardTotalSalaryTitle = new Label();
            lblCardTotalSalaryVal = new Label();
            _chartArea = new Panel();
            splitPanelChart = new TableLayoutPanel();
            barChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            pieChart = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            pnlFilterBar = new Panel();
            lblLoc = new Label();
            cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            cardFlow.SuspendLayout();
            pnlCardTotalEmp.SuspendLayout();
            pnlCardActiveEmp.SuspendLayout();
            pnlCardPendingLeave.SuspendLayout();
            pnlCardTotalSalary.SuspendLayout();
            _chartArea.SuspendLayout();
            splitPanelChart.SuspendLayout();
            pnlFilterBar.SuspendLayout();
            SuspendLayout();
            // 
            // header
            // 
            header.Dock = DockStyle.Top;
            header.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            header.ForeColor = Color.FromArgb(15, 23, 42);
            header.Location = new Point(0, 0);
            header.Name = "header";
            header.Size = new Size(1200, 61);
            header.TabIndex = 0;
            header.Text = "📊  Báo cáo & Thống kê nhân sự";
            header.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cardFlow
            // 
            cardFlow.BackColor = Color.Transparent;
            cardFlow.Controls.Add(pnlCardTotalEmp);
            cardFlow.Controls.Add(pnlCardActiveEmp);
            cardFlow.Controls.Add(pnlCardPendingLeave);
            cardFlow.Controls.Add(pnlCardTotalSalary);
            cardFlow.Dock = DockStyle.Top;
            cardFlow.Location = new Point(0, 122);
            cardFlow.Margin = new Padding(3, 4, 3, 4);
            cardFlow.Name = "cardFlow";
            cardFlow.Size = new Size(1200, 200);
            cardFlow.TabIndex = 1;
            cardFlow.WrapContents = false;
            // 
            // pnlCardTotalEmp
            // 
            pnlCardTotalEmp.BackColor = Color.White;
            pnlCardTotalEmp.Controls.Add(lblCardTotalEmpTitle);
            pnlCardTotalEmp.Controls.Add(lblCardTotalEmpVal);
            pnlCardTotalEmp.Location = new Point(0, 0);
            pnlCardTotalEmp.Margin = new Padding(0, 0, 16, 0);
            pnlCardTotalEmp.Name = "pnlCardTotalEmp";
            pnlCardTotalEmp.Size = new Size(222, 173);
            pnlCardTotalEmp.TabIndex = 0;
            pnlCardTotalEmp.Paint += PnlCardTotalEmp_Paint;
            // 
            // lblCardTotalEmpTitle
            // 
            lblCardTotalEmpTitle.AutoSize = true;
            lblCardTotalEmpTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardTotalEmpTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCardTotalEmpTitle.Location = new Point(18, 19);
            lblCardTotalEmpTitle.Name = "lblCardTotalEmpTitle";
            lblCardTotalEmpTitle.Size = new Size(143, 20);
            lblCardTotalEmpTitle.TabIndex = 0;
            lblCardTotalEmpTitle.Text = "👥 Tổng nhân viên";
            // 
            // lblCardTotalEmpVal
            // 
            lblCardTotalEmpVal.AutoSize = true;
            lblCardTotalEmpVal.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCardTotalEmpVal.ForeColor = Color.FromArgb(67, 56, 202);
            lblCardTotalEmpVal.Location = new Point(18, 53);
            lblCardTotalEmpVal.Name = "lblCardTotalEmpVal";
            lblCardTotalEmpVal.Size = new Size(75, 72);
            lblCardTotalEmpVal.TabIndex = 1;
            lblCardTotalEmpVal.Text = "...";
            // 
            // pnlCardActiveEmp
            // 
            pnlCardActiveEmp.BackColor = Color.White;
            pnlCardActiveEmp.Controls.Add(lblCardActiveEmpTitle);
            pnlCardActiveEmp.Controls.Add(lblCardActiveEmpVal);
            pnlCardActiveEmp.Location = new Point(238, 0);
            pnlCardActiveEmp.Margin = new Padding(0, 0, 16, 0);
            pnlCardActiveEmp.Name = "pnlCardActiveEmp";
            pnlCardActiveEmp.Size = new Size(225, 173);
            pnlCardActiveEmp.TabIndex = 1;
            pnlCardActiveEmp.Paint += PnlCardActiveEmp_Paint;
            // 
            // lblCardActiveEmpTitle
            // 
            lblCardActiveEmpTitle.AutoSize = true;
            lblCardActiveEmpTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardActiveEmpTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCardActiveEmpTitle.Location = new Point(18, 19);
            lblCardActiveEmpTitle.Name = "lblCardActiveEmpTitle";
            lblCardActiveEmpTitle.Size = new Size(133, 20);
            lblCardActiveEmpTitle.TabIndex = 0;
            lblCardActiveEmpTitle.Text = "✅ Đang làm việc";
            // 
            // lblCardActiveEmpVal
            // 
            lblCardActiveEmpVal.AutoSize = true;
            lblCardActiveEmpVal.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCardActiveEmpVal.ForeColor = Color.FromArgb(16, 185, 129);
            lblCardActiveEmpVal.Location = new Point(18, 53);
            lblCardActiveEmpVal.Name = "lblCardActiveEmpVal";
            lblCardActiveEmpVal.Size = new Size(75, 72);
            lblCardActiveEmpVal.TabIndex = 1;
            lblCardActiveEmpVal.Text = "...";
            // 
            // pnlCardPendingLeave
            // 
            pnlCardPendingLeave.BackColor = Color.White;
            pnlCardPendingLeave.Controls.Add(lblCardPendingLeaveTitle);
            pnlCardPendingLeave.Controls.Add(lblCardPendingLeaveVal);
            pnlCardPendingLeave.Location = new Point(479, 0);
            pnlCardPendingLeave.Margin = new Padding(0, 0, 16, 0);
            pnlCardPendingLeave.Name = "pnlCardPendingLeave";
            pnlCardPendingLeave.Size = new Size(222, 173);
            pnlCardPendingLeave.TabIndex = 2;
            pnlCardPendingLeave.Paint += PnlCardPendingLeave_Paint;
            // 
            // lblCardPendingLeaveTitle
            // 
            lblCardPendingLeaveTitle.AutoSize = true;
            lblCardPendingLeaveTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardPendingLeaveTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCardPendingLeaveTitle.Location = new Point(18, 19);
            lblCardPendingLeaveTitle.Name = "lblCardPendingLeaveTitle";
            lblCardPendingLeaveTitle.Size = new Size(137, 20);
            lblCardPendingLeaveTitle.TabIndex = 0;
            lblCardPendingLeaveTitle.Text = "📋 Đơn chờ duyệt";
            // 
            // lblCardPendingLeaveVal
            // 
            lblCardPendingLeaveVal.AutoSize = true;
            lblCardPendingLeaveVal.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCardPendingLeaveVal.ForeColor = Color.FromArgb(217, 119, 6);
            lblCardPendingLeaveVal.Location = new Point(18, 53);
            lblCardPendingLeaveVal.Name = "lblCardPendingLeaveVal";
            lblCardPendingLeaveVal.Size = new Size(75, 72);
            lblCardPendingLeaveVal.TabIndex = 1;
            lblCardPendingLeaveVal.Text = "...";
            // 
            // pnlCardTotalSalary
            // 
            pnlCardTotalSalary.BackColor = Color.White;
            pnlCardTotalSalary.Controls.Add(lblCardTotalSalaryTitle);
            pnlCardTotalSalary.Controls.Add(lblCardTotalSalaryVal);
            pnlCardTotalSalary.Location = new Point(717, 0);
            pnlCardTotalSalary.Margin = new Padding(0, 0, 16, 0);
            pnlCardTotalSalary.Name = "pnlCardTotalSalary";
            pnlCardTotalSalary.Size = new Size(395, 173);
            pnlCardTotalSalary.TabIndex = 3;
            pnlCardTotalSalary.Paint += PnlCardTotalSalary_Paint;
            // 
            // lblCardTotalSalaryTitle
            // 
            lblCardTotalSalaryTitle.AutoSize = true;
            lblCardTotalSalaryTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCardTotalSalaryTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCardTotalSalaryTitle.Location = new Point(18, 19);
            lblCardTotalSalaryTitle.Name = "lblCardTotalSalaryTitle";
            lblCardTotalSalaryTitle.Size = new Size(194, 20);
            lblCardTotalSalaryTitle.TabIndex = 0;
            lblCardTotalSalaryTitle.Text = "💰 Tổng quỹ lương th.này";
            // 
            // lblCardTotalSalaryVal
            // 
            lblCardTotalSalaryVal.AutoSize = true;
            lblCardTotalSalaryVal.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCardTotalSalaryVal.ForeColor = Color.FromArgb(220, 38, 38);
            lblCardTotalSalaryVal.Location = new Point(18, 53);
            lblCardTotalSalaryVal.Name = "lblCardTotalSalaryVal";
            lblCardTotalSalaryVal.Size = new Size(75, 72);
            lblCardTotalSalaryVal.TabIndex = 1;
            lblCardTotalSalaryVal.Text = "...";
            // 
            // _chartArea
            // 
            _chartArea.BackColor = Color.White;
            _chartArea.Controls.Add(splitPanelChart);
            _chartArea.Dock = DockStyle.Fill;
            _chartArea.Location = new Point(0, 322);
            _chartArea.Margin = new Padding(3, 4, 3, 4);
            _chartArea.Name = "_chartArea";
            _chartArea.Padding = new Padding(23, 27, 23, 27);
            _chartArea.Size = new Size(1200, 678);
            _chartArea.TabIndex = 2;
            // 
            // splitPanelChart
            // 
            splitPanelChart.BackColor = Color.White;
            splitPanelChart.ColumnCount = 2;
            splitPanelChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            splitPanelChart.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            splitPanelChart.Controls.Add(barChart, 0, 0);
            splitPanelChart.Controls.Add(pieChart, 1, 0);
            splitPanelChart.Dock = DockStyle.Fill;
            splitPanelChart.Location = new Point(23, 27);
            splitPanelChart.Margin = new Padding(3, 4, 3, 4);
            splitPanelChart.Name = "splitPanelChart";
            splitPanelChart.RowCount = 1;
            splitPanelChart.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            splitPanelChart.Size = new Size(1154, 624);
            splitPanelChart.TabIndex = 0;
            // 
            // barChart
            // 
            barChart.AutoUpdateEnabled = true;
            barChart.BackColor = Color.White;
            barChart.ChartTheme = null;
            barChart.Dock = DockStyle.Fill;
            skDefaultLegend3.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend3.Content = null;
            skDefaultLegend3.IsValid = false;
            skDefaultLegend3.Opacity = 1F;
            padding5.Bottom = 0F;
            padding5.Left = 0F;
            padding5.Right = 0F;
            padding5.Top = 0F;
            skDefaultLegend3.Padding = padding5;
            skDefaultLegend3.RemoveOnCompleted = false;
            skDefaultLegend3.RotateTransform = 0F;
            skDefaultLegend3.X = 0F;
            skDefaultLegend3.Y = 0F;
            barChart.Legend = skDefaultLegend3;
            barChart.Location = new Point(3, 4);
            barChart.Margin = new Padding(3, 4, 3, 4);
            barChart.MatchAxesScreenDataRatio = false;
            barChart.Name = "barChart";
            barChart.Size = new Size(686, 616);
            barChart.TabIndex = 0;
            skDefaultTooltip3.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip3.Content = null;
            skDefaultTooltip3.IsValid = false;
            skDefaultTooltip3.Opacity = 1F;
            padding6.Bottom = 0F;
            padding6.Left = 0F;
            padding6.Right = 0F;
            padding6.Top = 0F;
            skDefaultTooltip3.Padding = padding6;
            skDefaultTooltip3.RemoveOnCompleted = false;
            skDefaultTooltip3.RotateTransform = 0F;
            skDefaultTooltip3.Wedge = 10;
            skDefaultTooltip3.X = 0F;
            skDefaultTooltip3.Y = 0F;
            barChart.Tooltip = skDefaultTooltip3;
            barChart.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            barChart.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // pieChart
            // 
            pieChart.AutoUpdateEnabled = true;
            pieChart.BackColor = Color.White;
            pieChart.ChartTheme = null;
            pieChart.Dock = DockStyle.Fill;
            skDefaultLegend4.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend4.Content = null;
            skDefaultLegend4.IsValid = false;
            skDefaultLegend4.Opacity = 1F;
            padding7.Bottom = 0F;
            padding7.Left = 0F;
            padding7.Right = 0F;
            padding7.Top = 0F;
            skDefaultLegend4.Padding = padding7;
            skDefaultLegend4.RemoveOnCompleted = false;
            skDefaultLegend4.RotateTransform = 0F;
            skDefaultLegend4.X = 0F;
            skDefaultLegend4.Y = 0F;
            pieChart.Legend = skDefaultLegend4;
            pieChart.Location = new Point(695, 4);
            pieChart.Margin = new Padding(3, 4, 3, 4);
            pieChart.Name = "pieChart";
            pieChart.Size = new Size(456, 616);
            pieChart.TabIndex = 1;
            skDefaultTooltip4.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip4.Content = null;
            skDefaultTooltip4.IsValid = false;
            skDefaultTooltip4.Opacity = 1F;
            padding8.Bottom = 0F;
            padding8.Left = 0F;
            padding8.Right = 0F;
            padding8.Top = 0F;
            skDefaultTooltip4.Padding = padding8;
            skDefaultTooltip4.RemoveOnCompleted = false;
            skDefaultTooltip4.RotateTransform = 0F;
            skDefaultTooltip4.Wedge = 10;
            skDefaultTooltip4.X = 0F;
            skDefaultTooltip4.Y = 0F;
            pieChart.Tooltip = skDefaultTooltip4;
            pieChart.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // pnlFilterBar
            // 
            pnlFilterBar.BackColor = Color.Transparent;
            pnlFilterBar.Controls.Add(lblLoc);
            pnlFilterBar.Controls.Add(cboThang);
            pnlFilterBar.Controls.Add(cboNam);
            pnlFilterBar.Dock = DockStyle.Top;
            pnlFilterBar.Location = new Point(0, 61);
            pnlFilterBar.Margin = new Padding(3, 4, 3, 4);
            pnlFilterBar.Name = "pnlFilterBar";
            pnlFilterBar.Size = new Size(1200, 61);
            pnlFilterBar.TabIndex = 3;
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLoc.ForeColor = Color.FromArgb(15, 23, 42);
            lblLoc.Location = new Point(0, 16);
            lblLoc.Name = "lblLoc";
            lblLoc.Size = new Size(130, 23);
            lblLoc.TabIndex = 0;
            lblLoc.Text = "📅 Kỳ báo cáo:";
            // 
            // cboThang
            // 
            cboThang.BackColor = Color.Transparent;
            cboThang.BorderRadius = 6;
            cboThang.CustomizableEdges = customizableEdges5;
            cboThang.DrawMode = DrawMode.OwnerDrawFixed;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FocusedColor = Color.FromArgb(94, 148, 255);
            cboThang.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboThang.Font = new Font("Segoe UI", 9.5F);
            cboThang.ForeColor = Color.FromArgb(68, 88, 112);
            cboThang.ItemHeight = 30;
            cboThang.Location = new Point(126, 5);
            cboThang.Margin = new Padding(3, 4, 3, 4);
            cboThang.Name = "cboThang";
            cboThang.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cboThang.Size = new Size(148, 36);
            cboThang.TabIndex = 1;
            // 
            // cboNam
            // 
            cboNam.BackColor = Color.Transparent;
            cboNam.BorderRadius = 6;
            cboNam.CustomizableEdges = customizableEdges7;
            cboNam.DrawMode = DrawMode.OwnerDrawFixed;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNam.FocusedColor = Color.FromArgb(94, 148, 255);
            cboNam.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboNam.Font = new Font("Segoe UI", 9.5F);
            cboNam.ForeColor = Color.FromArgb(68, 88, 112);
            cboNam.ItemHeight = 30;
            cboNam.Location = new Point(286, 5);
            cboNam.Margin = new Padding(3, 4, 3, 4);
            cboNam.Name = "cboNam";
            cboNam.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cboNam.Size = new Size(125, 36);
            cboNam.TabIndex = 2;
            // 
            // BaoCaoPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(197, 210, 246);
            Controls.Add(_chartArea);
            Controls.Add(cardFlow);
            Controls.Add(pnlFilterBar);
            Controls.Add(header);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BaoCaoPage";
            Size = new Size(1200, 1000);
            cardFlow.ResumeLayout(false);
            pnlCardTotalEmp.ResumeLayout(false);
            pnlCardTotalEmp.PerformLayout();
            pnlCardActiveEmp.ResumeLayout(false);
            pnlCardActiveEmp.PerformLayout();
            pnlCardPendingLeave.ResumeLayout(false);
            pnlCardPendingLeave.PerformLayout();
            pnlCardTotalSalary.ResumeLayout(false);
            pnlCardTotalSalary.PerformLayout();
            _chartArea.ResumeLayout(false);
            splitPanelChart.ResumeLayout(false);
            pnlFilterBar.ResumeLayout(false);
            pnlFilterBar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.FlowLayoutPanel cardFlow;
        private System.Windows.Forms.Panel pnlCardTotalEmp;
        private System.Windows.Forms.Label lblCardTotalEmpTitle;
        private System.Windows.Forms.Label lblCardTotalEmpVal;
        private System.Windows.Forms.Panel pnlCardActiveEmp;
        private System.Windows.Forms.Label lblCardActiveEmpTitle;
        private System.Windows.Forms.Label lblCardActiveEmpVal;
        private System.Windows.Forms.Panel pnlCardPendingLeave;
        private System.Windows.Forms.Label lblCardPendingLeaveTitle;
        private System.Windows.Forms.Label lblCardPendingLeaveVal;
        private System.Windows.Forms.Panel pnlCardTotalSalary;
        private System.Windows.Forms.Label lblCardTotalSalaryTitle;
        private System.Windows.Forms.Label lblCardTotalSalaryVal;
        private System.Windows.Forms.Panel _chartArea;
        private System.Windows.Forms.TableLayoutPanel splitPanelChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart barChart;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart;
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.Label lblLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cboThang;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
    }
}

