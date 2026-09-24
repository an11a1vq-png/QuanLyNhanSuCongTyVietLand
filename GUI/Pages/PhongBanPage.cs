using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages
{
    public partial class PhongBanPage : UserControl
    {
        private readonly DepartmentBLL _service = new();
        private List<DepartmentDTO> _danhSach = new();

        public PhongBanPage() {
            InitializeComponent();
            this.ApplyDarkBackground();
            this._grid.ApplyDarkTheme();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadAsync();
            }
        }


        private readonly EmployeeBLL _empService = new();
        private readonly PositionBLL _posService = new();
        private List<EmployeeDTO> _danhSachNV = new();
        private List<PositionDTO> _danhSachCV = new();

        private async Task LoadAsync()
        {
            try
            {
                _danhSach = await _service.GetAllAsync();
                _danhSachNV = await _empService.GetVisibleEmployeesAsync();
                _danhSachCV = await _posService.GetAllAsync();
                if (this.IsDisposed) return;
                BindGrid(_danhSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private void BindGrid(List<DepartmentDTO> list)
        {
            _grid.DataSource = list.Select(p =>
            {
                string truongPhong = "—";

                // 1. Ưu tiên lấy theo manager_id trong bảng departments
                if (p.ManagerId.HasValue)
                {
                    var emp = _danhSachNV.FirstOrDefault(e => e.EmployeeId == p.ManagerId.Value);
                    if (emp != null) truongPhong = emp.FullName;
                }

                // 2. Nếu manager_id trống, tự tìm nhân viên thuộc phòng đó có chức vụ 'Trưởng phòng'
                if (truongPhong == "—")
                {
                    var empTP = _danhSachNV.FirstOrDefault(e => e.DepartmentId == p.DepartmentId &&
                        (e.PositionId == 2 || (_danhSachCV.FirstOrDefault(cv => cv.PositionId == e.PositionId)?.PositionName.Contains("Trưởng") == true)));
                    if (empTP != null) truongPhong = empTP.FullName;
                }

                return new
                {
                    DepartmentId = p.DepartmentId.ToString(),
                    DepartmentName = p.DepartmentName,
                    ManagerName = truongPhong
                };
            }).ToList();

            if (_grid.Columns["DepartmentId"] != null) _grid.Columns["DepartmentId"].HeaderText = "Mã PB";
            if (_grid.Columns["DepartmentName"] != null) _grid.Columns["DepartmentName"].HeaderText = "Tên Phòng Ban";
            if (_grid.Columns["ManagerName"] != null) _grid.Columns["ManagerName"].HeaderText = "Trưởng Phòng";
        }

        // ─── Toolbar ─────────────────────────────────────────────────────────
        private void BtnThem_Click(object sender, EventArgs e)
        {
            using var dlg = new PhongBanDialog(null);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }

        private async void BtnLam_Click(object sender, EventArgs e) => await LoadAsync();

        private void BtnXemNV_Click(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null || _grid.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn 1 phòng ban trong bảng để xem danh sách nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var maPB = _grid.CurrentRow.Cells["DepartmentId"].Value?.ToString();
            var item = _danhSach.FirstOrDefault(p => p.DepartmentId.ToString() == maPB);
            if (item == null) return;

            using var dlg = new DanhSachNhanVienPhongBanDialog(item);
            dlg.ShowWithDimOverlay(this);
        }

        // ─── Search ──────────────────────────────────────────────────────────
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw)) { BindGrid(_danhSach); return; }
            BindGrid(_danhSach.Where(p =>
                p.DepartmentName.ToLower().Contains(kw) ||
                p.DepartmentId.ToString().Contains(kw)).ToList());
        }

        private bool _isOpeningDialog;

        // ─── Grid double click → mở dialog ────────────────────────────────────
        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _isOpeningDialog) return;
            try
            {
                _isOpeningDialog = true;
                var maPB = _grid.Rows[e.RowIndex].Cells["DepartmentId"].Value?.ToString();
                var item = _danhSach.FirstOrDefault(p => p.DepartmentId.ToString() == maPB);
                if (item == null) return;
                using var dlg = new PhongBanDialog(item);
                if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                    _ = LoadAsync();
            }
            finally
            {
                _isOpeningDialog = false;
            }
        }
    }
}

