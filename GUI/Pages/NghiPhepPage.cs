using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages
{
    public partial class NghiPhepPage : UserControl
    {
        private readonly LeaveRequestBLL _repo = new();
        private List<LeaveRequestDTO> _currentList = new();

        public NghiPhepPage() {
            InitializeComponent();
            this.ApplyDarkBackground();
            this._grid.ApplyDarkTheme();

            if (cboLoaiNghi != null)
            {
                cboLoaiNghi.Items.Clear();
                cboLoaiNghi.Items.AddRange(new object[] { "--- Tất cả loại nghỉ ---", "Nghỉ phép năm", "Nghỉ ốm", "Công tác" });
                cboLoaiNghi.SelectedIndex = 0;
            }
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
                var list = await _repo.GetAllAsync();
                _currentList = list;
                if (this.IsDisposed) return;
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private void CboLoaiNghi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboLoaiNghi.SelectedIndex > 0)
            {
                string type = cboLoaiNghi.Text;
                var filtered = _currentList.Where(x => x.LeaveType == type).ToList();
                BindGrid(filtered);
            }
            else
            {
                BindGrid(_currentList);
            }
        }

        private void BindGrid(List<LeaveRequestDTO> list)
        {
            _lblCount.Text = $"Tổng: {list.Count} đơn";
            _grid.DataSource = list.Select(d => new
            {
                LeaveRequestId = d.MaDon,
                MaNV = d.MaNV,
                HoTen = d.HoTen ?? "—",
                LoaiNghi = d.LoaiNghi,
                NgayBD = d.NgayBatDau.ToString("dd/MM/yyyy"),
                NgayKT = d.NgayKetThuc.ToString("dd/MM/yyyy"),
                LyDo = d.LyDo,
                TrangThai = d.TrangThai,
                NguoiDuyet = d.NguoiDuyet ?? "—",
                NgayGui = d.NgayGui.ToString("dd/MM/yyyy HH:mm")
            }).ToList();

            if (_grid.Columns["LeaveRequestId"] != null) _grid.Columns["LeaveRequestId"].HeaderText = "Mã Đơn";
            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["HoTen"] != null) _grid.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (_grid.Columns["LoaiNghi"] != null) _grid.Columns["LoaiNghi"].HeaderText = "Loại nghỉ";
            if (_grid.Columns["NgayBD"] != null) _grid.Columns["NgayBD"].HeaderText = "Từ ngày";
            if (_grid.Columns["NgayKT"] != null) _grid.Columns["NgayKT"].HeaderText = "Đến ngày";
            if (_grid.Columns["LyDo"] != null) _grid.Columns["LyDo"].HeaderText = "Lý do";
            if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
            if (_grid.Columns["NguoiDuyet"] != null) _grid.Columns["NguoiDuyet"].HeaderText = "Người duyệt";
            if (_grid.Columns["NgayGui"] != null) _grid.Columns["NgayGui"].HeaderText = "Ngày gửi";
        }

        private async void BtnChoXuLy_Click(object sender, EventArgs e)
        {
            try
            {
                var list = await _repo.GetChoXuLyAsync();
                if (this.IsDisposed) return;
                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private async void BtnAll_Click(object sender, EventArgs e)
        {
            await LoadAsync();
        }

        private async void BtnDuyet_Click(object sender, EventArgs e)
        {
            await DuyetDon("Đã duyệt");
        }

        private async void BtnTuChoi_Click(object sender, EventArgs e)
        {
            await DuyetDon("Từ chối");
        }

        private async Task DuyetDon(string trangThai)
        {
            if (_grid.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn cần xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object? val = null;
            if (_grid.Columns.Contains("LeaveRequestId")) val = _grid.CurrentRow.Cells["LeaveRequestId"].Value;
            else if (_grid.Columns.Contains("MaDon")) val = _grid.CurrentRow.Cells["MaDon"].Value;

            if (val == null || !long.TryParse(val.ToString(), out long maDon))
            {
                MessageBox.Show("Không thể lấy được Mã Đơn từ dòng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nguoiDuyet = SessionManager.CurrentAccount?.Username ?? "Admin";

            try
            {
                var result = await _repo.DuyetDonAsync(maDon, trangThai, nguoiDuyet);
                if (this.IsDisposed) return;
                
                if (result.Item1)
                {
                    MessageBox.Show($"Đã {trangThai.ToLower()} đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadAsync();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.Item2}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


