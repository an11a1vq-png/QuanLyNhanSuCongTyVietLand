using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;


namespace VietLandHR.GUI.Pages
{
    public partial class NhanVienPage : UserControl
    {
        private readonly EmployeeBLL _service = new();
        private readonly DepartmentBLL _deptService = new();
        private readonly PositionBLL _posService = new();
        private List<EmployeeDTO> _danhSach = new();
        private List<DepartmentDTO> _danhSachPB = new();
        private List<PositionDTO> _danhSachCV = new();
        private EmployeeDTO? _selected;

        public NhanVienPage() {
            InitializeComponent();
            this.ApplyLightBackground();
            this._grid.ApplyModernTheme();
            cboFilter.Items.Add("— Tất cả phòng ban —");
            cboFilter.SelectedIndex = 0;
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadAsync();
            }
        }


        private async Task LoadAsync()
        {
            try
            {
                _danhSach   = await _service.GetVisibleEmployeesAsync();
                _danhSachPB = await _deptService.GetAllAsync();
                _danhSachCV = await _posService.GetAllAsync();
                if (this.IsDisposed) return;

                // Nếu là Manager (Trưởng phòng) -> Chỉ xem danh sách nhân sự thuộc phòng ban của mình
                if (SessionManager.IsManager && !SessionManager.IsAdmin)
                {
                    int? mgrDeptId = SessionManager.CurrentEmployee?.DepartmentId;
                    if (mgrDeptId.HasValue)
                    {
                        _danhSach = _danhSach.Where(e => e.DepartmentId == mgrDeptId.Value).ToList();
                    }
                }

                // Ẩn nút Thêm/Xóa nếu không phải Admin
                if (btnThem != null) btnThem.Visible = SessionManager.IsAdmin;
                if (btnXoa != null) btnXoa.Visible = SessionManager.IsAdmin;

                // Cập nhật filter combo
                var currentSel = cboFilter.SelectedIndex;
                cboFilter.Items.Clear();
                cboFilter.Items.Add("— Tất cả phòng ban —");
                foreach (var pb in _danhSachPB)
                    cboFilter.Items.Add($"{pb.DepartmentId} - {pb.DepartmentName}");
                cboFilter.SelectedIndex = (currentSel >= 0 && currentSel < cboFilter.Items.Count)
                    ? currentSel : 0;

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            var kw = _txtSearch.Text.Trim().ToLower();
            var filtered = _danhSach.AsEnumerable();

            // Lọc theo phòng ban
            if (cboFilter.SelectedIndex > 0)
            {
                var maPB = cboFilter.SelectedItem?.ToString()?.Split('-')[0].Trim();
                if (!string.IsNullOrEmpty(maPB) && int.TryParse(maPB, out int deptId))
                    filtered = filtered.Where(n => n.DepartmentId == deptId);
            }

            // Lọc theo từ khóa
            if (!string.IsNullOrEmpty(kw))
                filtered = filtered.Where(n =>
                    n.FullName.ToLower().Contains(kw) ||
                    n.EmployeeCode.ToLower().Contains(kw) ||
                    (n.Email ?? "").ToLower().Contains(kw));

            BindGrid(filtered.ToList());
        }

        private void BindGrid(List<EmployeeDTO> ds)
        {
            _grid.DataSource = ds.Select(n =>
            {
                decimal salary = n.BaseSalary;
                if (salary == 0 && n.PositionId.HasValue)
                {
                    var pos = _danhSachCV.FirstOrDefault(p => p.PositionId == n.PositionId.Value);
                    if (pos != null && pos.BaseSalary > 0) salary = pos.BaseSalary;
                }

                return new
                {
                    MaNV = n.EmployeeCode,
                    HoTen = n.FullName,
                    TenPhongBan = _danhSachPB.FirstOrDefault(p => p.DepartmentId == n.DepartmentId)?.DepartmentName ?? "—",
                    Email = n.Email ?? "—",
                    SDT = n.Phone ?? "—",
                    LuongCB = salary > 0 ? salary.ToString("N0") + " đ" : "0 đ",
                    TrangThai = (n.Status == "Inactive" || n.Status == "Khóa" || n.Status == "🔒 Bị khóa") ? "Inactive" : "Active"
                };
            }).ToList();

            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["HoTen"] != null) _grid.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (_grid.Columns["TenPhongBan"] != null) _grid.Columns["TenPhongBan"].HeaderText = "Phòng ban";
            if (_grid.Columns["Email"] != null) _grid.Columns["Email"].HeaderText = "Email";
            if (_grid.Columns["SDT"] != null) _grid.Columns["SDT"].HeaderText = "SĐT";
            if (_grid.Columns["LuongCB"] != null)
            {
                _grid.Columns["LuongCB"].HeaderText = "Lương CB";
                _grid.Columns["LuongCB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        // ─── Toolbar buttons ─────────────────────────────────────────────────
        private async void BtnThem_Click(object sender, EventArgs e)
        {
            var pbList = _danhSachPB.Select(p => $"{p.DepartmentId} - {p.DepartmentName}").ToList();
            var cvList = _danhSachCV.Select(p => $"{p.PositionId} - {p.PositionName}").ToList();
            using var dlg = new NhanVienDialog(null);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                await LoadAsync();
        }

        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            int selectedCount = _grid.SelectedRows.Count;
            if (selectedCount == 0 && _selected != null)
            {
                selectedCount = 1;
            }

            if (selectedCount == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 nhân viên để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedCount == 1)
            {
                var target = _selected;
                if (target == null && _grid.SelectedRows.Count > 0)
                {
                    var maNV = _grid.SelectedRows[0].Cells["MaNV"].Value?.ToString();
                    target = _danhSach.FirstOrDefault(n => n.EmployeeCode == maNV);
                }
                if (target == null) return;

                if (MessageBox.Show($"CẢNH BÁO: Bạn có chắc chắn muốn XÓA VĨNH VIỄN nhân viên '{target.FullName}' ({target.EmployeeCode}) và toàn bộ dữ liệu liên quan khỏi CSDL?", "Xác nhận xóa vĩnh viễn",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                var (ok, msg) = await _service.DeleteAsync(target.EmployeeId);
                MessageBox.Show(msg, ok ? "Thành công" : "Lỗi", MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (ok) { _selected = null; await LoadAsync(); }
            }
            else
            {
                // XÓA HÀNG LOẠT (Batch Delete)
                if (MessageBox.Show($"CẢNH BÁO: Bạn có chắc chắn muốn XÓA VĨNH VIỄN {selectedCount} nhân viên đã chọn và toàn bộ dữ liệu liên quan khỏi CSDL?", $"Xác nhận XÓA HÀNG LOẠT {selectedCount} nhân viên",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                btnXoa.Enabled = false;
                int successCount = 0;
                var listToDelete = new List<EmployeeDTO>();

                foreach (DataGridViewRow row in _grid.SelectedRows)
                {
                    var maNV = row.Cells["MaNV"].Value?.ToString();
                    var emp = _danhSach.FirstOrDefault(n => n.EmployeeCode == maNV);
                    if (emp != null) listToDelete.Add(emp);
                }

                foreach (var emp in listToDelete)
                {
                    var (ok, msg) = await _service.DeleteAsync(emp.EmployeeId);
                    if (ok) successCount++;
                }

                btnXoa.Enabled = true;
                MessageBox.Show($"Đã xóa vĩnh viễn thành công {successCount}/{selectedCount} nhân viên!", "Hoàn tất xóa hàng loạt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selected = null;
                await LoadAsync();
            }
        }

        private async void BtnLam_Click(object sender, EventArgs e)
        {
            _selected = null;
            _txtSearch.Text = "";
            cboFilter.SelectedIndex = 0;
            await LoadAsync();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (_danhSach.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VietLandHR.Utils.ExcelExportHelper.ExportDataGridView(_grid, "DanhSachNhanVien", "Nhân Viên");
        }

        // ─── Filter events ───────────────────────────────────────────────────
        private void TxtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void CboFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        // ─── Grid click → select; double-click → dialog ──────────────────────
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var maNV = _grid.Rows[e.RowIndex].Cells["MaNV"].Value?.ToString();
            _selected = _danhSach.FirstOrDefault(n => n.EmployeeCode == maNV);
        }

        private async void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _selected == null) return;
            var pbList = _danhSachPB.Select(p => $"{p.DepartmentId} - {p.DepartmentName}").ToList();
            var cvList = _danhSachCV.Select(p => $"{p.PositionId} - {p.PositionName}").ToList();
            using var dlg = new NhanVienDialog(_selected);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                await LoadAsync();
        }
    }
}

