using VietLandHR.DAL;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpNghiPhepPage : UserControl
    {
        private readonly VietLandHR.BLL.LeaveRequestBLL _repo = new();
        private readonly string _maNV;

        public EmpNghiPhepPage()
        {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkBackground(this);
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkTheme(this._grid);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlForm);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlBottom);
            _maNV = GUI.LoginForm.CurrentUser?.MaNV ?? "";

            cboLoai.Items.AddRange(new object[] { "Nghỉ phép", "Nghỉ ốm", "Công tác" });
            cboLoai.SelectedIndex = 0;
            dtpBatDau.Value  = DateTime.Today;
            dtpKetThuc.Value = DateTime.Today.AddDays(1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadMyDonAsync();
            }
        }

        private async Task LoadMyDonAsync()
        {
            try
            {
                var all  = await _repo.GetAllAsync();
                var mine = all.Where(d => d.MaNV == _maNV)
                              .OrderByDescending(d => d.NgayGui)
                              .ToList();

                _grid.DataSource = mine.Select(d => new
                {
                    LeaveRequestId = d.MaDon,
                    LoaiNghi       = d.LoaiNghi,
                    NgayBD         = d.NgayBatDau.ToString("dd/MM/yyyy"),
                    NgayKT         = d.NgayKetThuc.ToString("dd/MM/yyyy"),
                    LyDo           = d.LyDo,
                    TrangThai      = d.TrangThai,
                    NgayGui        = d.NgayGui.ToString("dd/MM/yyyy"),
                    NguoiDuyet     = d.NguoiDuyet ?? "—"
                }).ToList();

                if (_grid.Columns["LeaveRequestId"] != null) _grid.Columns["LeaveRequestId"].HeaderText = "Mã Đơn";
                if (_grid.Columns["LoaiNghi"] != null) _grid.Columns["LoaiNghi"].HeaderText = "Loại nghỉ";
                if (_grid.Columns["NgayBD"] != null) _grid.Columns["NgayBD"].HeaderText = "Từ ngày";
                if (_grid.Columns["NgayKT"] != null) _grid.Columns["NgayKT"].HeaderText = "Đến ngày";
                if (_grid.Columns["LyDo"] != null) _grid.Columns["LyDo"].HeaderText = "Lý do";
                if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
                if (_grid.Columns["NgayGui"] != null) _grid.Columns["NgayGui"].HeaderText = "Ngày gửi";
                if (_grid.Columns["NguoiDuyet"] != null) _grid.Columns["NguoiDuyet"].HeaderText = "Người duyệt";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi: {ex.Message}"); }
        }

        private async void BtnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maNV))
            {
                MessageBox.Show("Không xác định mã nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpKetThuc.Value < dtpBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var don = new LeaveRequestDTO
            {
                MaNV        = _maNV,
                LoaiNghi    = cboLoai.SelectedItem?.ToString() ?? "Nghỉ phép",
                NgayBatDau  = dtpBatDau.Value.Date,
                NgayKetThuc = dtpKetThuc.Value.Date,
                LyDo        = string.IsNullOrWhiteSpace(txtLyDo.Text) ? "" : txtLyDo.Text.Trim(),
                TrangThai   = "Chờ duyệt",
                NgayGui     = DateTime.Now
            };

            try
            {
                await _repo.InsertAsync(don);
                MessageBox.Show("Đã gửi đơn nghỉ phép thành công!\nVui lòng chờ phê duyệt từ quản lý.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLyDo.Text = "";
                await LoadMyDonAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



