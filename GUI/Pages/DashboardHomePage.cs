using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages
{
    public partial class DashboardHomePage : UserControl
    {
        private readonly EmployeeBLL _nvService = new();
        private readonly AttendanceBLL _ccService = new();

        public DashboardHomePage()
        {
            InitializeComponent();
            this.ApplyLightBackground();
            if (this.gridRecentNV != null)
            {
                this.gridRecentNV.ApplyModernTheme();
            }
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var nvList = await _nvService.LayDanhSachAsync();
                var posList = await new PositionBLL().GetAllAsync();
                var deptList = await new DepartmentBLL().GetAllAsync();
                var accList = await new AccountBLL().GetAllAsync();
                var accDict = accList.Where(a => a.EmployeeId.HasValue).ToDictionary(a => a.EmployeeId!.Value);

                _lblTongNV.Text = nvList.Count.ToString();

                gridRecentNV.DataSource = nvList.Take(10).Select(n =>
                {
                    var pos = posList.FirstOrDefault(p => p.PositionId == n.PositionId);
                    var dept = deptList.FirstOrDefault(d => d.DepartmentId == n.DepartmentId);
                    decimal salary = n.BaseSalary;
                    if (salary == 0 && pos != null && pos.BaseSalary > 0)
                    {
                        salary = pos.BaseSalary;
                    }

                    bool isAccountActive = true;
                    if (accDict.TryGetValue(n.EmployeeId, out var acc))
                    {
                        isAccountActive = acc.IsActive;
                    }

                    string statusDisplay = (!isAccountActive || n.Status == "Inactive" || n.Status == "Khóa" || n.Status == "🔒 Bị khóa") ? "Inactive" : "Active";

                    return new
                    {
                        MaNV = n.EmployeeCode,
                        HoTen = n.FullName,
                        ChucVu = pos?.PositionName ?? (n.PositionId.HasValue ? n.PositionId.ToString() : "—"),
                        TenPhongBan = dept?.DepartmentName ?? "—",
                        TrangThai = statusDisplay,
                        Luong = salary > 0 ? salary.ToString("N0") + " đ" : "0 đ"
                    };
                }).ToList();

                if (gridRecentNV.Columns["MaNV"] != null) gridRecentNV.Columns["MaNV"].HeaderText = "Mã NV";
                if (gridRecentNV.Columns["HoTen"] != null) gridRecentNV.Columns["HoTen"].HeaderText = "Họ và Tên";
                if (gridRecentNV.Columns["ChucVu"] != null) gridRecentNV.Columns["ChucVu"].HeaderText = "Chức vụ";
                if (gridRecentNV.Columns["TenPhongBan"] != null) gridRecentNV.Columns["TenPhongBan"].HeaderText = "Phòng ban";
                if (gridRecentNV.Columns["TrangThai"] != null) gridRecentNV.Columns["TrangThai"].HeaderText = "Trạng thái";
                if (gridRecentNV.Columns["Luong"] != null)
                {
                    gridRecentNV.Columns["Luong"].HeaderText = "Mức lương";
                    gridRecentNV.Columns["Luong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                var ccList = await _ccService.GetAttendanceListAsync(DateTime.Today, DateTime.Today);
                _lblChamCongHomNay.Text = ccList.Count(x => x.CheckIn.HasValue).ToString();

                var npList = await new LeaveRequestBLL().GetPendingForApprovalAsync();
                _lblNghiPhep.Text = npList.Count.ToString();

                var prList = await new PayrollBLL().LayBangLuongThangAsync(DateTime.Now.Month, DateTime.Now.Year);
                _lblBangLuong.Text = prList.Count.ToString();
            }
            catch
            {
                _lblTongNV.Text = "?";
                _lblChamCongHomNay.Text = "?";
                _lblNghiPhep.Text = "?";
                _lblBangLuong.Text = "?";
            }
        }

        private void DrawCardBorder(Control card, Graphics g, Color accent)
        {
            using var brush = new SolidBrush(accent);
            g.FillRectangle(brush, 0, 0, 5, card.Height);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void CardTongNV_Paint(object sender, PaintEventArgs e)
        {
            DrawCardBorder(cardTongNV, e.Graphics, Color.FromArgb(99, 102, 241));
        }

        private void CardChamCong_Paint(object sender, PaintEventArgs e)
        {
            DrawCardBorder(cardChamCong, e.Graphics, Color.FromArgb(16, 185, 129));
        }

        private void CardNghiPhep_Paint(object sender, PaintEventArgs e)
        {
            DrawCardBorder(cardNghiPhep, e.Graphics, Color.FromArgb(245, 158, 11));
        }

        private void CardBangLuong_Paint(object sender, PaintEventArgs e)
        {
            DrawCardBorder(cardBangLuong, e.Graphics, Color.FromArgb(239, 68, 68));
        }
    }
}


