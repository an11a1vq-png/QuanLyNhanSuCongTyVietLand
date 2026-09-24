using VietLandHR.BLL;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpLuongPage : UserControl
    {
        private readonly PayrollBLL _service = new();
        private readonly string _maNV;

        public EmpLuongPage() {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkBackground(this);
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkTheme(this._grid);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlHeader);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlBottom);
            _maNV = GUI.LoginForm.CurrentUser?.MaNV ?? "";

            cboNam.Items.Clear();
            for (int y = DateTime.Now.Year; y >= DateTime.Now.Year - 5; y--)
                cboNam.Items.Add(y);
            cboNam.SelectedIndex = 0;

            
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
            if (string.IsNullOrEmpty(_maNV)) return;
            try
            {
                int nam = (int)cboNam.SelectedItem!;
                var allRows = new List<PayrollDTO>();
                for (int m = 1; m <= 12; m++)
                {
                    var rows = await _service.LayBangLuongThangAsync(m, nam);
                    allRows.AddRange(rows.Where(b => b.MaNV == _maNV));
                }

                _grid.DataSource = allRows.Select(b => new
                {
                    ThangNam    = $"Tháng {b.Thang}/{b.Nam}",
                    SoNgayCong  = b.SoNgayCong.ToString("F1"),
                    SoGioOT     = b.SoGioOT.ToString("F1") + "h",
                    LuongCB     = b.LuongCoBan.ToString("N0") + " đ",
                    PhuCap      = b.PhuCap.ToString("N0") + " đ",
                    Thuong      = b.ThuongKPI.ToString("N0") + " đ",
                    KhauTru     = (b.KhauTruBH + b.KhauTruThue).ToString("N0") + " đ",
                    LuongThucTe = b.LuongThucTe.ToString("N0") + " đ",
                    TrangThai   = b.TrangThai == "Paid" ? "Active" : b.TrangThai
                }).ToList();

                if (_grid.Columns["ThangNam"] != null) _grid.Columns["ThangNam"].HeaderText = "Tháng/Năm";
                if (_grid.Columns["SoNgayCong"] != null) _grid.Columns["SoNgayCong"].HeaderText = "Ngày công";
                if (_grid.Columns["SoGioOT"] != null) _grid.Columns["SoGioOT"].HeaderText = "Giờ OT";
                if (_grid.Columns["LuongCB"] != null)
                {
                    _grid.Columns["LuongCB"].HeaderText = "Lương CB";
                    _grid.Columns["LuongCB"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_grid.Columns["PhuCap"] != null)
                {
                    _grid.Columns["PhuCap"].HeaderText = "Phụ cấp";
                    _grid.Columns["PhuCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_grid.Columns["Thuong"] != null)
                {
                    _grid.Columns["Thuong"].HeaderText = "Thưởng";
                    _grid.Columns["Thuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_grid.Columns["KhauTru"] != null)
                {
                    _grid.Columns["KhauTru"].HeaderText = "Khấu trừ";
                    _grid.Columns["KhauTru"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_grid.Columns["LuongThucTe"] != null)
                {
                    _grid.Columns["LuongThucTe"].HeaderText = "Thực nhận";
                    _grid.Columns["LuongThucTe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bảng lương: {ex.Message}");
            }
        }

        private async void BtnXem_Click(object sender, EventArgs e) => await LoadAsync();
    }
}



