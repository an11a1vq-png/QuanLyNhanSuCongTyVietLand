using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;

using VietLandHR.DTOs;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI.Pages
{
    public partial class TinhLuongPage : UserControl
    {
        private readonly PayrollBLL _service = new();
        private List<PayrollDTO> _ketQua = new();

        public TinhLuongPage()
        {
            InitializeComponent();
            this.ApplyDarkBackground();
            this._grid.ApplyDarkTheme();
            SetupForm();
        }

        private void SetupForm()
        {
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
        }

        private async void BtnTinh_Click(object sender, EventArgs e)
        {
            int thang = _cboThang.SelectedIndex + 1;
            int nam = (int)_cboNam.SelectedItem!;

            Cursor = Cursors.WaitCursor;
            try
            {
                _ketQua = await _service.TinhLuongThangAsync(thang, nam);
                if (this.IsDisposed) return;
                BindGrid(_ketQua);
                UpdateStats(_ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính lương: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!_ketQua.Any())
            {
                MessageBox.Show("Vui lòng tính lương trước khi lưu.");
                return;
            }
            try
            {
                var (ok, msg) = await _service.LuuBangLuongAsync(_ketQua);
                if (!ok)
                {
                    MessageBox.Show(msg);
                    return;
                }

                var employees = await new EmployeeBLL().GetVisibleEmployeesAsync();
                var empDict = employees.ToDictionary(e => e.EmployeeId.ToString());

                foreach (var bl in _ketQua)
                {
                    // Gửi email phiếu lương
                    if (empDict.TryGetValue(bl.MaNV, out var emp) && !string.IsNullOrEmpty(emp.Email))
                    {
                        string subject = $"Phiếu lương tháng {bl.Thang}/{bl.Nam} - VIETLAND HR";
                        string body = $"Chào {emp.FullName},\n\n" +
                                      $"Phòng Nhân sự gửi bạn phiếu lương tháng {bl.Thang}/{bl.Nam}.\n" +
                                      $"------------------------------------------------------\n" +
                                      $"Lương cơ bản: {bl.LuongCoBan:N0} đ\n" +
                                      $"Ngày công thực tế: {bl.SoNgayCong:F1}\n" +
                                      $"Phụ cấp/OT: {bl.PhuCap:N0} đ\n" +
                                      $"Thưởng KPI: {bl.ThuongKPI:N0} đ\n" +
                                      $"Khấu trừ (BH/Phạt): {bl.KhauTruBH:N0} đ\n" +
                                      $"Thuế TNCN: {bl.KhauTruThue:N0} đ\n" +
                                      $"------------------------------------------------------\n" +
                                      $"THỰC LÃNH: {bl.LuongThucTe:N0} đ\n\n" +
                                      $"Trân trọng,\nPhòng Nhân sự VIETLAND HR";
                        EmailHelper.SendEmailAsync(emp.Email, subject, body, emp.FullName);
                    }
                }
                MessageBox.Show($"Đã lưu bảng lương {_ketQua.Count} nhân viên thành công và gửi Email thông báo!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu bảng lương: {ex.Message}");
            }
        }

        private async void BtnXem_Click(object sender, EventArgs e)
        {
            int thang = _cboThang.SelectedIndex + 1;
            int nam = (int)_cboNam.SelectedItem!;

            try
            {
                var list = await _service.LayBangLuongThangAsync(thang, nam);
                if (this.IsDisposed) return;
                BindGrid(list);
                UpdateStats(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bảng lương: {ex.Message}");
            }
        }

        private void BindGrid(List<PayrollDTO> list)
        {
            _grid.DataSource = list.Select(b => new
            {
                MaNV = b.MaNV,
                HoTen = b.HoTen ?? "—",
                ThangNam = $"{b.Thang}/{b.Nam}",
                SoNgayCong = b.SoNgayCong.ToString("F1"),
                SoGioOT = b.SoGioOT.ToString("F1") + "h",
                LuongCB = b.LuongCoBan.ToString("N0") + " đ",
                PhuCap = b.PhuCap.ToString("N0") + " đ",
                Thuong = b.ThuongKPI.ToString("N0") + " đ",
                KhauTru = (b.KhauTruBH + b.KhauTruThue).ToString("N0") + " đ",
                LuongThucTe = b.LuongThucTe.ToString("N0") + " đ",
                TrangThai = b.TrangThai == "Paid" ? "Active" : b.TrangThai
            }).ToList();

            if (_grid.Columns["MaNV"] != null) _grid.Columns["MaNV"].HeaderText = "Mã NV";
            if (_grid.Columns["HoTen"] != null) _grid.Columns["HoTen"].HeaderText = "Họ và Tên";
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

        private void UpdateStats(List<PayrollDTO> list)
        {
            lblStatNhanVienVal.Text = list.Count.ToString();
            lblStatNgayCongVal.Text = list.Any() ? list.Average(b => (double)b.SoNgayCong).ToString("F1") : "0";
            lblStatQuyLuongVal.Text = list.Sum(b => b.LuongThucTe).ToString("N0") + " đ";
            lblStatThueVal.Text = list.Sum(b => b.KhauTruThue).ToString("N0") + " đ";
        }

        private async void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (_ketQua.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xuất. Hãy tính lương trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int thang = _cboThang.SelectedIndex + 1;
            int nam   = _cboNam.Items.Count > 0 ? (int)_cboNam.SelectedItem! : DateTime.Now.Year;
            
            using var sfd = new SaveFileDialog() 
            { 
                Filter = "Excel Workbook|*.xlsx", 
                FileName = $"BangLuong_T{thang}_{nam}.xlsx" 
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var bll = new BLL.PayrollBLL();
                var (ok, msg) = await bll.ExportToExcelAsync(_ketQua, sfd.FileName);
                if (ok)
                {
                    var res = MessageBox.Show($"Xuất Excel thành công!\nBạn có muốn mở file ngay không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                else MessageBox.Show(msg, "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


