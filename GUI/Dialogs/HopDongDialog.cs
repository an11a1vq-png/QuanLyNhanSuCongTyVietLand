using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DAL;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;
using Guna.UI2.WinForms;
using System.Linq;

namespace VietLandHR.GUI.Dialogs
{
    public partial class HopDongDialog : Form
    {
        private readonly ContractBLL _service = new();
        private readonly EmployeeDAL _empDal = new();
        private readonly ContractDTO? _entity;
        private readonly bool _isNew;

        public HopDongDialog(ContractDTO? entity)
        {
            _entity = entity;
            _isNew = entity == null;
            InitializeComponent();
            
            UIHelper.ApplyLightBackground(this);
            tbl.BackColor = Color.White;
            
            cboLoaiHD.Items.Clear();
            cboLoaiHD.Items.AddRange(new[] { "Hữu hạn", "Vô hạn", "Thử việc" });
            
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new[] { "Active", "Expired", "Terminated" });
            
            chkVoHan.ForeColor = Color.FromArgb(15, 23, 42);
            chkVoHan.CheckedChanged += (s, e) => dtpNgayKT.Enabled = !chkVoHan.Checked;
            
            pnlBtns.BackColor = Color.FromArgb(248, 250, 252);
            
            btnLuu.FillColor = UIHelper.AccentSelect;
            btnLuu.HoverState.FillColor = ControlPaint.Light(UIHelper.AccentSelect, 0.1f);
            
            btnHuy.FillColor = Color.FromArgb(71, 85, 105);
            btnHuy.HoverState.FillColor = ControlPaint.Light(Color.FromArgb(71, 85, 105), 0.1f);
            
            this.KeyPreview = true;
            this.KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };

            lblTitle.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(Handle, 0x112, 0xF012, 0);
                }
            };
            
            ApplyMode();
        }

        private List<EmployeeDTO> _employeesList = new();

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                await LoadEmployeesAsync();
                ApplyMode();
                FillData();
            }
        }

        private async Task LoadEmployeesAsync()
        {
            var allEmps = await _empDal.GetAllAsync();
            // Sắp xếp mã nhân viên từ nhỏ đến lớn (NV001, NV002, NV003...)
            _employeesList = allEmps.OrderBy(x => x.EmployeeCode).ToList();

            cboMaNV.Items.Clear();
            foreach (var emp in _employeesList)
            {
                cboMaNV.Items.Add($"{emp.EmployeeCode} - {emp.FullName}");
            }
            if (cboMaNV.Items.Count > 0) cboMaNV.SelectedIndex = 0;

            cboMaNV.SelectedIndexChanged += (s, e) =>
            {
                if (_isNew && cboMaNV.SelectedIndex >= 0 && cboMaNV.SelectedIndex < _employeesList.Count)
                {
                    var selectedEmp = _employeesList[cboMaNV.SelectedIndex];
                    if (selectedEmp.BaseSalary > 0)
                    {
                        txtLuongThoa.Text = selectedEmp.BaseSalary.ToString("0");
                    }
                }
            };
        }

        private async void ApplyMode()
        {
            txtMaHD.ReadOnly = true; // Khóa không cho người dùng tự sửa/nhập tay Mã HĐ
            if (_isNew)
            {
                cboLoaiHD.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0; // Default Active

                // Tự động sinh Mã HĐ duy nhất dạng HD-NVxxx-yyMMddHHmm
                var allContracts = await _service.GetAllAsync();
                int nextId = allContracts.Count + 1;
                txtMaHD.Text = $"HD-{DateTime.Now:yyMMddHHmm}-{nextId}";
            }
        }

        private void FillData()
        {
            if (_entity == null) return;
            txtMaHD.Text = _entity.ContractCode;
            if (!string.IsNullOrEmpty(_entity.MaNV))
            {
                var matching = cboMaNV.Items.OfType<string>().FirstOrDefault(i => i.StartsWith(_entity.MaNV + " -") || i == _entity.MaNV);
                if (matching != null) cboMaNV.SelectedItem = matching;
            }
            cboLoaiHD.SelectedItem = _entity.ContractType;
            dtpNgayBD.Value = _entity.StartDate;
            chkVoHan.Checked = !_entity.EndDate.HasValue;
            if (_entity.EndDate.HasValue) dtpNgayKT.Value = _entity.EndDate.Value;
            txtLuongThoa.Text = _entity.Salary?.ToString("0");
            txtGhiChu.Text = _entity.Notes ?? "";
            cboTrangThai.SelectedItem = _entity.Status;
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text) || cboMaNV.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Mã NV và kiểm tra Mã HĐ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal? luong = null;
            if (!string.IsNullOrWhiteSpace(txtLuongThoa.Text))
            {
                if (decimal.TryParse(txtLuongThoa.Text, out decimal l))
                {
                    if (l < 0)
                    {
                        MessageBox.Show("Mức lương thỏa thuận không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    luong = l;
                }
                else
                {
                    MessageBox.Show("Lương thỏa không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 1. Kiểm tra ngày ký hợp đồng (Không ở tương lai)
            if (dtpNgayBD.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày ký/bắt đầu hợp đồng không được ở thời điểm tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra ngày kết thúc (Không nhỏ hơn ngày ký)
            if (!chkVoHan.Checked && dtpNgayKT.Value.Date < dtpNgayBD.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc hợp đồng không được nhỏ hơn ngày ký bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedMaNV = cboMaNV.SelectedItem.ToString()!.Split('-')[0].Trim();
                var emp = _employeesList.FirstOrDefault(x => x.EmployeeCode.Equals(selectedMaNV, StringComparison.OrdinalIgnoreCase))
                          ?? (await _empDal.GetAllAsync()).FirstOrDefault(x => x.EmployeeCode.Equals(selectedMaNV, StringComparison.OrdinalIgnoreCase));
                
                if (emp == null)
                {
                    MessageBox.Show("Không tìm thấy Nhân viên với Mã NV này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var hd = new ContractDTO
                {
                    ContractCode = txtMaHD.Text.Trim(),
                    EmployeeId = emp.EmployeeId,
                    ContractType = cboLoaiHD.SelectedItem?.ToString(),
                    StartDate = dtpNgayBD.Value.Date,
                    EndDate = chkVoHan.Checked ? null : dtpNgayKT.Value.Date,
                    Salary = luong,
                    Notes = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim(),
                    Status = cboTrangThai.SelectedItem?.ToString() ?? "Active"
                };

                if (!_isNew && _entity != null)
                {
                    hd.ContractId = _entity.ContractId;
                }

                (bool Success, string Message) res;
                if (_isNew) res = await _service.CreateAsync(hd);
                else res = await _service.UpdateAsync(hd);

                if (res.Success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(UIHelper.DarkBorder, 1.5f), 0, 0, Width - 1, Height - 1);
        }
    }
}

