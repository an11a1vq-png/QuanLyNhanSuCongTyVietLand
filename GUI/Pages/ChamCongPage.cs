using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    public partial class ChamCongPage : UserControl
    {
        private readonly AttendanceBLL _ccService = new();
        private readonly EmployeeBLL _nvService = new();
        private List<EmployeeDTO> _dsnv = new();
        private List<AttendanceDTO> _rawAttendanceList = new();

        public ChamCongPage()
        {
            InitializeComponent();
            this.ApplyDarkBackground();
            this._grid.ApplyDarkTheme();

            SetupForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadAsync();
            }
        }

        private void SetupForm()
        {
            lblToday.Text = $"📅  {DateTime.Now:dddd, dd/MM/yyyy}";

            // Lọc tháng/năm
            _cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                _cboThang.Items.Add($"Tháng {i}");
            }
            _cboThang.SelectedIndex = DateTime.Now.Month - 1;

            _cboNam.Items.Clear();
            for (int y = DateTime.Now.Year; y >= DateTime.Now.Year - 3; y--)
            {
                _cboNam.Items.Add(y);
            }
            _cboNam.SelectedIndex = 0;

            _dtpNgayFilter.Value = DateTime.Today;
        }

        private async Task LoadAsync()
        {
            try
            {
                var allEmps = await _nvService.LayDanhSachAsync();
                if (this.IsDisposed) return;

                // Nếu là Manager -> chỉ lấy danh sách nhân viên thuộc phòng ban của Manager
                if (SessionManager.IsManager && !SessionManager.IsAdmin && SessionManager.CurrentEmployee != null)
                {
                    int myDeptId = SessionManager.CurrentEmployee.DepartmentId ?? 0;
                    _dsnv = allEmps.Where(e => e.DepartmentId == myDeptId).ToList();
                }
                else
                {
                    _dsnv = allEmps;
                }

                _cboNhanVien.Items.Clear();

                // 1. Tùy chọn gửi hàng loạt ban đầu
                if (SessionManager.IsAdmin)
                {
                    _cboNhanVien.Items.Add($"--- Tất cả nhân viên ({_dsnv.Count} NV) ---");
                }
                else if (SessionManager.IsManager)
                {
                    _cboNhanVien.Items.Add($"--- Tất cả nhân viên phòng ban ({_dsnv.Count} NV) ---");
                }
                else
                {
                    _cboNhanVien.Items.Add($"--- Chọn nhân viên ---");
                }

                // 2. Thêm từng nhân viên xếp theo Mã NV từ nhỏ đến lớn
                foreach (var nv in _dsnv.OrderBy(e => e.EmployeeCode))
                {
                    _cboNhanVien.Items.Add($"{nv.EmployeeCode} - {nv.FullName}");
                }

                if (_cboNhanVien.Items.Count > 0)
                {
                    _cboNhanVien.SelectedIndex = 0;
                }

                await LoadGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private async Task LoadGridAsync()
        {
            int thang = _cboThang.SelectedIndex + 1;
            int nam = (int)_cboNam.SelectedItem!;

            var fromDate = new DateTime(nam, thang, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);

            _rawAttendanceList = await _ccService.GetAttendanceListAsync(fromDate, toDate);
            if (this.IsDisposed) return;

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_rawAttendanceList == null) return;

            var filtered = _rawAttendanceList.AsEnumerable();

            // Nếu là Manager -> chỉ lọc danh sách chấm công của nhân viên thuộc phòng ban mình
            if (SessionManager.IsManager && !SessionManager.IsAdmin && SessionManager.CurrentEmployee != null)
            {
                int myDeptId = SessionManager.CurrentEmployee.DepartmentId ?? 0;
                var myDeptEmpIds = _dsnv.Select(e => e.EmployeeId).ToHashSet();
                filtered = filtered.Where(c => myDeptEmpIds.Contains(c.EmployeeId));
            }

            // 1. Lọc theo từ khóa (Tên NV hoặc Mã NV)
            string keyword = _txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(c =>
                {
                    var emp = _dsnv.FirstOrDefault(e => e.EmployeeId == c.EmployeeId);
                    string code = (emp?.EmployeeCode ?? c.EmployeeId.ToString()).ToLower();
                    string name = (emp?.FullName ?? "").ToLower();
                    return code.Contains(keyword) || name.Contains(keyword);
                });
            }

            // 2. Lọc theo ngày cụ thể (nếu được chọn)
            if (_chkLocNgay.Checked)
            {
                DateTime selectedDate = _dtpNgayFilter.Value.Date;
                filtered = filtered.Where(c => c.WorkDate.Date == selectedDate);
            }

            // 3. Hiển thị lên DataGridView
            _grid.DataSource = filtered.Select(c =>
            {
                var emp = _dsnv.FirstOrDefault(e => e.EmployeeId == c.EmployeeId);
                var (wHrs, otHrs) = c.CheckIn.HasValue && c.CheckOut.HasValue
                    ? AttendanceBLL.CalculateWorkAndOTHours(c.CheckIn.Value, c.CheckOut.Value)
                    : (c.TotalHours ?? 0m, 0m);

                return new
                {
                    AttendanceId = c.AttendanceId,
                    MaNV = emp?.EmployeeCode ?? c.EmployeeId.ToString(),
                    HoTen = emp?.FullName ?? "—",
                    WorkDate = c.WorkDate.ToString("dd/MM/yyyy"),
                    CheckIn = FormatTime(c.CheckIn),
                    CheckOut = FormatTime(c.CheckOut),
                    WorkHours = wHrs.ToString("F1") + "h",
                    OTHours = otHrs.ToString("F1") + "h",
                    TrangThai = (c.Status == "Active" || string.IsNullOrEmpty(c.Status)) ? "Present" : c.Status
                };
            }).ToList();

            if (_grid.Columns["AttendanceId"] != null) _grid.Columns["AttendanceId"].Visible = false;
            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["HoTen"] != null) _grid.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (_grid.Columns["WorkDate"] != null) _grid.Columns["WorkDate"].HeaderText = "Ngày chấm";
            if (_grid.Columns["CheckIn"] != null) _grid.Columns["CheckIn"].HeaderText = "Giờ Vào";
            if (_grid.Columns["CheckOut"] != null) _grid.Columns["CheckOut"].HeaderText = "Giờ Ra";
            if (_grid.Columns["WorkHours"] != null) _grid.Columns["WorkHours"].HeaderText = "Giờ làm";
            if (_grid.Columns["OTHours"] != null) _grid.Columns["OTHours"].HeaderText = "Giờ OT";
            if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ChkLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            _dtpNgayFilter.Enabled = _chkLocNgay.Checked;
            ApplyFilter();
        }

        private void DtpNgayFilter_ValueChanged(object sender, EventArgs e)
        {
            if (_chkLocNgay.Checked)
            {
                ApplyFilter();
            }
        }

        private string GetSelectedMaNV()
        {
            var txt = _cboNhanVien.SelectedItem?.ToString() ?? "";
            return txt.Split('-')[0].Trim();
        }

        private async void BtnCheckIn_Click(object sender, EventArgs e)
        {
            if (_cboNhanVien.SelectedIndex < 0) return;

            // Xử lý gửi Check-In hàng loạt khi chọn tùy chọn đầu tiên
            if (_cboNhanVien.SelectedIndex == 0 && (_cboNhanVien.SelectedItem?.ToString()?.StartsWith("---") ?? false))
            {
                string targetTitle = SessionManager.IsAdmin ? "toàn bộ nhân viên công ty" : "tất cả nhân viên phòng ban";
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn Check-In hàng loạt cho {targetTitle} ({_dsnv.Count} NV)?", "Xác nhận Check-In Hàng Loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                int successCount = 0;
                int skippedCount = 0;

                foreach (var emp in _dsnv)
                {
                    var (ok, _) = await _ccService.CheckInAdminAsync(emp.EmployeeId);
                    if (ok) successCount++;
                    else skippedCount++;
                }

                _lblStatus.Text = $"✅ Đã Check-In cho {successCount} NV (Bỏ qua {skippedCount} NV đã Check-In trước đó).";
                _lblStatus.ForeColor = Color.FromArgb(52, 211, 153);
                await LoadGridAsync();
                return;
            }

            // Xử lý Check-In cho 1 nhân viên cụ thể
            var maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return;
            var empTarget = _dsnv.FirstOrDefault(e => e.EmployeeCode == maNV);
            if (empTarget == null) return;

            var (okSingle, msgSingle) = await _ccService.CheckInAdminAsync(empTarget.EmployeeId);
            _lblStatus.Text = msgSingle;
            _lblStatus.ForeColor = okSingle ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
            if (okSingle) await LoadGridAsync();
        }

        private async void BtnCheckOut_Click(object sender, EventArgs e)
        {
            if (_cboNhanVien.SelectedIndex < 0) return;

            // Xử lý gửi Check-Out hàng loạt khi chọn tùy chọn đầu tiên
            if (_cboNhanVien.SelectedIndex == 0 && (_cboNhanVien.SelectedItem?.ToString()?.StartsWith("---") ?? false))
            {
                string targetTitle = SessionManager.IsAdmin ? "toàn bộ nhân viên công ty" : "tất cả nhân viên phòng ban";
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn Check-Out hàng loạt cho {targetTitle} ({_dsnv.Count} NV)?", "Xác nhận Check-Out Hàng Loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                int successCount = 0;
                int skippedCount = 0;

                foreach (var emp in _dsnv)
                {
                    var (ok, _) = await _ccService.CheckOutAdminAsync(emp.EmployeeId);
                    if (ok) successCount++;
                    else skippedCount++;
                }

                _lblStatus.Text = $"✅ Đã Check-Out cho {successCount} NV (Bỏ qua {skippedCount} NV chưa Check-In hoặc đã Check-Out).";
                _lblStatus.ForeColor = Color.FromArgb(52, 211, 153);
                await LoadGridAsync();
                return;
            }

            // Xử lý Check-Out cho 1 nhân viên cụ thể
            var maNV = GetSelectedMaNV();
            if (string.IsNullOrEmpty(maNV)) return;
            var empTarget = _dsnv.FirstOrDefault(e => e.EmployeeCode == maNV);
            if (empTarget == null) return;

            var (okSingle, msgSingle) = await _ccService.CheckOutAdminAsync(empTarget.EmployeeId);
            _lblStatus.Text = msgSingle;
            _lblStatus.ForeColor = okSingle ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
            if (okSingle) await LoadGridAsync();
        }

        private async void BtnXem_Click(object sender, EventArgs e)
        {
            await LoadGridAsync();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            MoFormSuaGiờ();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MoFormSuaGiờ();
            }
        }

        private async void MoFormSuaGiờ()
        {
            if (_grid.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng chấm công để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cellId = _grid.CurrentRow.Cells["AttendanceId"]?.Value;
            if (cellId == null || !int.TryParse(cellId.ToString(), out int attId)) return;

            var item = _rawAttendanceList.FirstOrDefault(x => x.AttendanceId == attId);
            if (item == null) return;

            string tenNV = _grid.CurrentRow.Cells["HoTen"]?.Value?.ToString() ?? "";

            using (var dlg = new SuaChamCongDialog(item, tenNV))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    await LoadGridAsync();
                }
            }
        }

        private static string FormatTime(DateTime? dt)
        {
            if (!dt.HasValue) return "—";
            DateTime d = dt.Value;
            DateTime local = d.Kind == DateTimeKind.Utc ? d.ToLocalTime() : d;

            // Chống lệch 7h do bản ghi cũ lưu nhầm múi giờ
            if (local.Hour >= 19 && local.Hour <= 23)
            {
                local = local.AddHours(-7);
            }

            return local.ToString(@"HH\:mm");
        }
    }
}

