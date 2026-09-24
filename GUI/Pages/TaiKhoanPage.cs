using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace VietLandHR.GUI.Pages
{
    public partial class TaiKhoanPage : UserControl
    {
        private readonly AccountBLL _repo = new();
        private List<AccountDTO> _allData = new();

        public TaiKhoanPage() {
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
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid()
        {
            _grid.DataSource = _allData.Select(t => new
            {
                AccountId   = t.AccountId.ToString(),
                MaNV        = t.EmployeeId?.ToString() ?? "—",
                Username    = t.Username,
                RoleName    = t.RoleId == 1 ? "Admin" : t.RoleId == 2 ? "Manager" : "Employee",
                TrangThai   = t.IsActive ? "Active" : "Inactive"
            }).ToList();

            if (_grid.Columns["AccountId"] != null) _grid.Columns["AccountId"].HeaderText = "Mã TK";
            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["Username"] != null) _grid.Columns["Username"].HeaderText = "Tên đăng nhập";
            if (_grid.Columns["RoleName"] != null) _grid.Columns["RoleName"].HeaderText = "Vai trò";
            if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        // ─── Toolbar buttons ─────────────────────────────────────────────
        private void BtnThem_Click(object sender, EventArgs e)
        {
            using var dlg = new TaiKhoanDialog(null);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }

        private async void BtnKhoa_Click(object sender, EventArgs e)
        {
            if (_grid.CurrentRow == null) return;
            var maTK = _grid.CurrentRow.Cells["AccountId"].Value?.ToString();
            var item = _allData.FirstOrDefault(t => t.AccountId.ToString() == maTK);
            if (item == null) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn {(item.IsActive ? "khóa" : "mở khóa")} tài khoản '{item.Username}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await _repo.ToggleActiveAsync(item.AccountId, !item.IsActive);
                if (this.IsDisposed) return;
                await LoadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật: {ex.Message}");
            }
        }

        // ─── Grid double click → mở dialog sửa/reset ───────────────────────
        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var maTK = _grid.Rows[e.RowIndex].Cells["AccountId"].Value?.ToString();
            var item = _allData.FirstOrDefault(t => t.AccountId.ToString() == maTK);
            if (item == null) return;

            using var dlg = new TaiKhoanDialog(item);
            if (dlg.ShowWithDimOverlay(this) == DialogResult.OK)
                _ = LoadAsync();
        }

        // ─── Search ──────────────────────────────────────────────────────
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var kw = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw))
            {
                BindGrid();
                return;
            }
            _grid.DataSource = _allData
                .Where(t => t.Username.ToLower().Contains(kw)
                         || t.AccountId.ToString().Contains(kw)
                         || (t.EmployeeId?.ToString() ?? "").Contains(kw))
                .Select(t => new
                {
                    MãTK = t.AccountId.ToString(), MãNV = t.EmployeeId?.ToString() ?? "—",
                    TênĐăngNhập = t.Username, VaiTrò = t.RoleId.ToString(),
                    TrạngThái = t.IsActive ? "✅ Hoạt động" : "🔒 Bị khóa"
                }).ToList();
        }
    }
}

