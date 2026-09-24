using VietLandHR.BLL;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages
{
    public partial class HopDongPage : UserControl
    {
        private readonly ContractBLL _repo = new();
        private List<ContractDTO> _allData = new();

        public HopDongPage() {
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


        private async Task LoadAsync()
        {
            try
            {
                _allData = await _repo.GetAllAsync();
                if (this.IsDisposed) return;
                BindGrid(_allData);
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}"); }
        }

        private void BindGrid(List<ContractDTO> list)
        {
            _grid.DataSource = list.Select(h => new
            {
                MaHD = h.MaHD,
                MaNV = h.MaNV,
                LoaiHD = h.LoaiHD ?? "—",
                NgayBD = h.NgayBatDau.ToString("dd/MM/yyyy"),
                NgayKT = h.NgayKetThuc.HasValue ? h.NgayKetThuc.Value.ToString("dd/MM/yyyy") : "Vô hạn",
                LuongThoa = h.LuongThoa.HasValue ? h.LuongThoa.Value.ToString("N0") + " đ" : "—",
                TrangThai = h.TrangThai == "Expired" ? "Inactive" : h.TrangThai,
                GhiChu = h.GhiChu ?? "—"
            }).ToList();

            if (_grid.Columns["MaHD"] != null) _grid.Columns["MaHD"].HeaderText = "Mã HĐ";
            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["LoaiHD"] != null) _grid.Columns["LoaiHD"].HeaderText = "Loại HĐ";
            if (_grid.Columns["NgayBD"] != null) _grid.Columns["NgayBD"].HeaderText = "Ngày ký";
            if (_grid.Columns["NgayKT"] != null) _grid.Columns["NgayKT"].HeaderText = "Ngày hết hạn";
            if (_grid.Columns["LuongThoa"] != null)
            {
                _grid.Columns["LuongThoa"].HeaderText = "Lương HĐ";
                _grid.Columns["LuongThoa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
            if (_grid.Columns["GhiChu"] != null) _grid.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        // ─── Toolbar ─────────────────────────────────────────────────────────
        private void BtnThem_Click(object sender, EventArgs e)
        {
            using var dlg = new HopDongDialog(null);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null) return;
            var maHD = _grid.CurrentRow.Cells["MaHD"].Value?.ToString();
            var item = _allData.FirstOrDefault(h => h.MaHD == maHD);
            if (item == null) return;
            using var dlg = new HopDongDialog(item);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }

        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null) return;
            var maHD = _grid.CurrentRow.Cells["MaHD"].Value?.ToString();
            var item = _allData.FirstOrDefault(h => h.MaHD == maHD);
            if (item == null) return;
            var confirm = MessageBox.Show($"Xóa hợp đồng {maHD}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                await _repo.DeleteAsync(item.ContractId);
                await LoadAsync();
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi xóa: {ex.Message}"); }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_grid.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            VietLandHR.Utils.ExcelExportHelper.ExportDataGridView(_grid, "DanhSachHopDong", "Hợp Đồng");
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var kw = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw)) { BindGrid(_allData); return; }
            var filtered = _allData.Where(h =>
                h.MaNV.ToLower().Contains(kw) || h.MaHD.ToLower().Contains(kw)).ToList();
            BindGrid(filtered);
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var maHD = _grid.Rows[e.RowIndex].Cells["MaHD"].Value?.ToString();
            var item = _allData.FirstOrDefault(h => h.MaHD == maHD);
            if (item == null) return;
            using var dlg = new HopDongDialog(item);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }
    }
}

