using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DAL;
using VietLandHR.GUI.Helpers;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI.Pages
{
    public partial class BaoCaoPage : UserControl
    {
        private readonly EmployeeBLL _nvService = new();
        private readonly PayrollBLL _luongService = new();
        private readonly LeaveRequestBLL _leaveRepo = new();
        private readonly DepartmentDAL _deptRepo = new();

        private CartesianChart _barChart;
        private PieChart _pieChart;

        public BaoCaoPage() {
            InitializeComponent();
            this.ApplyDarkBackground();
            
            InitFilterData();
            // Khởi tạo LiveCharts
            InitializeCharts();
        }

        private void InitFilterData()
        {
            cboThang.Items.Clear();
            for (int m = 1; m <= 12; m++) cboThang.Items.Add($"Tháng {m}");
            cboThang.SelectedIndex = DateTime.Now.Month - 1;

            cboNam.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int yr = currentYear - 2; yr <= currentYear + 1; yr++)
            {
                cboNam.Items.Add(yr);
            }
            cboNam.SelectedItem = currentYear;

            cboThang.SelectedIndexChanged += (_, _) => _ = LoadAsync();
            cboNam.SelectedIndexChanged += (_, _) => _ = LoadAsync();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadAsync();
            }
        }


        private void InitializeCharts()
        {
            _barChart = barChart;
            _pieChart = pieChart;

            _pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
            _pieChart.LegendTextPaint = new SolidColorPaint(new SKColor(15, 23, 42));
        }

        private async Task LoadAsync()
        {
            try
            {
                var nvList = await _nvService.LayDanhSachAsync();
                
                // Nạp tên phòng ban vào nvList
                var depts = await _deptRepo.GetAllAsync();
                foreach (var nv in nvList)
                {
                    if (nv.DepartmentId.HasValue)
                    {
                        var d = depts.FirstOrDefault(x => x.DepartmentId == nv.DepartmentId.Value);
                        if (d != null) nv.TenPhongBan = d.DepartmentName;
                    }
                }

                lblCardTotalEmpVal.Text = nvList.Count.ToString();
                lblCardActiveEmpVal.Text = nvList.Count(n => n.TrangThai == "Active" || n.TrangThai == "Đang làm việc" || n.Status == "Active").ToString();

                var leaves = await _leaveRepo.GetChoXuLyAsync();
                lblCardPendingLeaveVal.Text = leaves.Count.ToString();

                int selMonth = (cboThang?.SelectedIndex >= 0) ? (cboThang.SelectedIndex + 1) : DateTime.Now.Month;
                int selYear = (cboNam?.SelectedItem is int y) ? y : DateTime.Now.Year;

                lblCardTotalSalaryTitle.Text = $"💵 Quỹ lương T{selMonth}/{selYear}";

                var currentSalaryList = await _luongService.LayBangLuongThangAsync(selMonth, selYear);
                lblCardTotalSalaryVal.Text = currentSalaryList.Sum(s => s.LuongThucTe).ToString("N0") + " đ";

                // ============================================
                // 1. Dữ liệu Biểu đồ Cột (Quỹ lương phải trả theo phòng ban)
                // ============================================
                var salaryByDept = currentSalaryList
                    .Join(nvList, s => s.EmployeeId, n => n.EmployeeId, (s, n) => new { s.LuongThucTe, Dept = n.TenPhongBan })
                    .Where(x => !string.IsNullOrEmpty(x.Dept))
                    .GroupBy(x => x.Dept)
                    .Select(g => new { Dept = g.Key, TotalSalary = (double)g.Sum(x => x.LuongThucTe) })
                    .ToList();

                if (salaryByDept.Count == 0) salaryByDept.Add(new { Dept = "Chưa có dữ liệu", TotalSalary = 0.0 });

                _barChart.Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Quỹ lương (VNĐ)",
                        Values = salaryByDept.Select(d => d.TotalSalary).ToArray(),
                        Fill = new SolidColorPaint(new SKColor(67, 56, 202)),
                        DataLabelsPaint = new SolidColorPaint(new SKColor(15, 23, 42)),
                        DataLabelsSize = 13,
                        DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
                        DataLabelsFormatter = point => point.Coordinate.PrimaryValue.ToString("N0")
                    }
                };

                _barChart.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = salaryByDept.Select(d => d.Dept).ToArray(),
                        LabelsPaint = new SolidColorPaint(new SKColor(71, 85, 105)),
                        TextSize = 14
                    }
                };
                
                _barChart.YAxes = new Axis[]
                {
                    new Axis
                    {
                        LabelsPaint = new SolidColorPaint(new SKColor(71, 85, 105)),
                        TextSize = 12,
                        Labeler = value => (value / 1000000).ToString("N0") + " Tr" // Rút gọn thành Triệu VNĐ
                    }
                };

                // ============================================
                // 2. Dữ liệu Biểu đồ Tròn (Số nhân viên theo phòng ban)
                // ============================================
                var deptData = nvList
                    .Where(n => !string.IsNullOrEmpty(n.TenPhongBan))
                    .GroupBy(n => n.TenPhongBan)
                    .Select(g => new { Dept = g.Key, Count = g.Count() })
                    .ToList();
                
                if (deptData.Count == 0) deptData.Add(new { Dept = "Chưa có dữ liệu", Count = 1 });

                var pieSeries = new List<ISeries>();
                var colors = new[] { SKColors.MediumSeaGreen, SKColors.IndianRed, SKColors.Orange, SKColors.MediumPurple, SKColors.DeepSkyBlue, SKColors.HotPink };
                int colorIndex = 0;

                foreach (var d in deptData)
                {
                    pieSeries.Add(new PieSeries<int>
                    {
                        Name = d.Dept,
                        Values = new int[] { d.Count },
                        Fill = new SolidColorPaint(colors[colorIndex % colors.Length]),
                        DataLabelsPaint = new SolidColorPaint(SKColors.White),
                        DataLabelsSize = 16,
                        DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                        DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} NV"
                    });
                    colorIndex++;
                }

                _pieChart.Series = pieSeries;
            }
            catch
            {
                lblCardTotalEmpVal.Text = "?";
                lblCardActiveEmpVal.Text = "?";
                lblCardPendingLeaveVal.Text = "?";
                lblCardTotalSalaryVal.Text = "?";
            }
        }

        private void DrawCardBorder(Panel card, Graphics g, Color accent)
        {
            using var brush = new SolidBrush(accent);
            g.FillRectangle(brush, 0, 0, 5, card.Height);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void PnlCardTotalEmp_Paint(object sender, PaintEventArgs e) => DrawCardBorder(pnlCardTotalEmp, e.Graphics, Color.FromArgb(99, 102, 241));
        private void PnlCardActiveEmp_Paint(object sender, PaintEventArgs e) => DrawCardBorder(pnlCardActiveEmp, e.Graphics, Color.FromArgb(16, 185, 129));
        private void PnlCardPendingLeave_Paint(object sender, PaintEventArgs e) => DrawCardBorder(pnlCardPendingLeave, e.Graphics, Color.FromArgb(245, 158, 11));
        private void PnlCardTotalSalary_Paint(object sender, PaintEventArgs e) => DrawCardBorder(pnlCardTotalSalary, e.Graphics, Color.FromArgb(239, 68, 68));
    }
}

