using VietLandHR.BLL;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpHopDongPage : UserControl
    {
        private readonly ContractBLL _service = new();
        private readonly int? _employeeId;

        public EmpHopDongPage() {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkBackground(this);
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkTheme(this._grid);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlHeader);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlBottom);
            _employeeId = SessionManager.CurrentAccount?.EmployeeId;
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadDataAsync();
            }
        }


        private async Task LoadDataAsync()
        {
            if (!_employeeId.HasValue) return;
            try
            {
                var list = await _service.GetByEmployeeIdAsync(_employeeId.Value);
                _grid.DataSource = list.Select(h => new
                {
                    MaHD = h.ContractCode,
                    LoaiHD = h.ContractType ?? "—",
                    NgayBD = h.StartDate.ToString("dd/MM/yyyy"),
                    NgayKT = h.EndDate.HasValue ? h.EndDate.Value.ToString("dd/MM/yyyy") : "Vô hạn",
                    LuongThoa = h.Salary.HasValue ? h.Salary.Value.ToString("N0") + " đ" : "—",
                    TrangThai = h.Status == "Expired" ? "Inactive" : h.Status,
                    GhiChu = h.Notes ?? "—"
                }).ToList();

                if (_grid.Columns["MaHD"] != null) _grid.Columns["MaHD"].HeaderText = "Mã HĐ";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải hợp đồng: {ex.Message}");
            }
        }
    }
}



