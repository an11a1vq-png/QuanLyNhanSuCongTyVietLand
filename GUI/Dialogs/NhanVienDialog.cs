using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DAL;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;

namespace VietLandHR.GUI.Dialogs
{
    public partial class NhanVienDialog : Form
    {
        private readonly EmployeeBLL _service = new();
        private readonly EmployeeDTO? _entity;
        private readonly bool _isNew;

        private List<string> _danhSachPhongBan = new();
        private List<string> _danhSachChucVu = new();

        public EmployeeDTO? Result { get; private set; }

        public NhanVienDialog(EmployeeDTO? entity)
        {
            _entity = entity;
            _isNew = entity == null;
            InitializeComponent();
            
            // Format UI that couldn't be done in Designer easily
            UIHelper.ApplyLightBackground(this);
            tbl.BackColor = Color.White;
            
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new[] { "Active", "Inactive" });
            
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new[] { "Nam", "Nữ" });
            
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
                    ReleaseCapture();
                    SendMessage(Handle, 0x112, 0xF012, 0);
                }
            };
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                await LoadDropdownsAsync();
                ApplyMode();
                FillData();
            }
        }

        private List<PositionDTO> _positionsList = new();

        private async Task LoadDropdownsAsync()
        {
            cboLoaiHD.Items.Clear();
            cboLoaiHD.Items.AddRange(new object[] { "Thử việc", "Hữu hạn", "Vô hạn" });
            cboLoaiHD.SelectedIndex = 0;

            var deptDal = new DepartmentDAL();
            var depts = await deptDal.GetAllAsync();
            _danhSachPhongBan = depts.Select(d => $"{d.DepartmentId} - {d.DepartmentName}").ToList();
            cboPhongBan.Items.Clear();
            cboPhongBan.Items.AddRange(_danhSachPhongBan.ToArray());

            var posDal = new PositionDAL();
            _positionsList = await posDal.GetAllAsync();
            _danhSachChucVu = _positionsList.Select(p => $"{p.PositionId} - {p.PositionName}").ToList();
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(_danhSachChucVu.ToArray());

            cboChucVu.SelectedIndexChanged -= CboChucVu_SelectedIndexChanged;
            cboChucVu.SelectedIndexChanged += CboChucVu_SelectedIndexChanged;
        }

        private void CboChucVu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboChucVu.SelectedItem == null) return;
            var pStr = cboChucVu.SelectedItem.ToString();
            if (pStr != null && pStr.Contains("-"))
            {
                if (int.TryParse(pStr.Split('-')[0].Trim(), out int posId))
                {
                    var pos = _positionsList.FirstOrDefault(p => p.PositionId == posId);
                    if (pos != null && pos.BaseSalary > 0)
                    {
                        txtLuongCoBan.Text = pos.BaseSalary.ToString("0.##");
                    }
                    if (posId == 2)
                    {
                        cboLoaiHD.SelectedItem = "Hữu hạn";
                    }
                }
            }
        }

        private async void ApplyMode()
        {
            txtMaNV.ReadOnly = true; // Khóa không cho người dùng tự sửa/nhập tay Mã NV
            if (_isNew)
            {
                txtMaNV.Text = await _service.GetNextEmployeeCodeAsync(); // Tự động sinh mã NV001, NV002...
                cboGioiTinh.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
                cboLoaiHD.SelectedIndex = 0;
                if (cboPhongBan.Items.Count > 0) cboPhongBan.SelectedIndex = 0;
                if (cboChucVu.Items.Count > 0) cboChucVu.SelectedIndex = 0;
            }

            // Nếu không phải Admin (Manager/Employee) -> Chỉ xem thông tin, không được chỉnh sửa
            if (!SessionManager.IsAdmin)
            {
                lblTitle.Text = "👁️  Xem chi tiết thông tin nhân viên";
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnHuy.Text = "Đóng";

                txtHoTen.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtCCCD.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtLuongCoBan.ReadOnly = true;

                dtpNgaySinh.Enabled = false;
                dtpNgayVaoLam.Enabled = false;
                cboGioiTinh.Enabled = false;
                cboPhongBan.Enabled = false;
                cboChucVu.Enabled = false;
                cboLoaiHD.Enabled = false;
                cboTrangThai.Enabled = false;
            }
        }

        private async void FillData()
        {
            if (_entity == null) return;
            txtMaNV.Text = _entity.EmployeeCode;
            txtHoTen.Text = _entity.FullName;
            if (!string.IsNullOrEmpty(_entity.Gender)) cboGioiTinh.SelectedItem = _entity.Gender;
            if (_entity.BirthDate.HasValue) dtpNgaySinh.Value = _entity.BirthDate.Value;
            txtEmail.Text = _entity.Email;
            txtSDT.Text = _entity.Phone;
            txtDiaChi.Text = _entity.Address;
            txtCCCD.Text = _entity.CitizenId;
            txtLuongCoBan.Text = _entity.BaseSalary > 0 ? _entity.BaseSalary.ToString("0.##") : "";
            if (_entity.DepartmentId.HasValue) cboPhongBan.SelectedItem = _danhSachPhongBan.FirstOrDefault(p => p.StartsWith(_entity.DepartmentId.ToString() + " -"));
            if (_entity.PositionId.HasValue) cboChucVu.SelectedItem = _danhSachChucVu.FirstOrDefault(p => p.StartsWith(_entity.PositionId.ToString() + " -"));
            if (_entity.HireDate != DateTime.MinValue) dtpNgayVaoLam.Value = _entity.HireDate;
            cboTrangThai.SelectedItem = _entity.Status;

            // Đọc loại hợp đồng hiện tại từ CSDL
            try
            {
                var contracts = await new ContractBLL().GetByEmployeeIdAsync(_entity.EmployeeId);
                var contract = contracts.FirstOrDefault(c => c.Status == "Active") ?? contracts.FirstOrDefault();
                if (contract != null && !string.IsNullOrEmpty(contract.ContractType))
                {
                    cboLoaiHD.SelectedItem = contract.ContractType;
                }
            }
            catch { }
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || 
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc: Mã NV, Họ tên, Email, Số điện thoại và Số CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdt = txtSDT.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                if (sdt.Length != 10 || !sdt.StartsWith("0") || !sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số, chỉ chứa số và bắt đầu bằng số 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var allEmps = await _service.GetVisibleEmployeesAsync();
                if (allEmps.Any(e => (_isNew || e.EmployeeId != _entity?.EmployeeId) && e.Phone?.Trim() == sdt))
                {
                    MessageBox.Show($"Số điện thoại '{sdt}' đã được đăng ký cho một nhân viên khác trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string cccd = txtCCCD.Text.Trim();
            if (!string.IsNullOrEmpty(cccd))
            {
                if (cccd.Length != 12 || !cccd.All(char.IsDigit))
                {
                    MessageBox.Show("Số CCCD phải gồm đúng 12 chữ số và không chứa chữ cái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var allEmps = await _service.GetVisibleEmployeesAsync();
                if (allEmps.Any(e => (_isNew || e.EmployeeId != _entity?.EmployeeId) && e.CitizenId?.Trim() == cccd))
                {
                    MessageBox.Show($"Số CCCD '{cccd}' đã được đăng ký cho một nhân viên khác trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 1. Kiểm tra độ tuổi (Phải từ đủ 18 tuổi)
            if (dtpNgaySinh.Value > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Nhân viên phải từ đủ 18 tuổi trở lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chặn trùng Mã nhân viên khi thêm mới
            if (_isNew)
            {
                string codeInput = txtMaNV.Text.Trim();
                var allEmps = await _service.GetVisibleEmployeesAsync();
                if (allEmps.Any(e => e.EmployeeCode?.Trim().Equals(codeInput, StringComparison.OrdinalIgnoreCase) == true))
                {
                    MessageBox.Show($"Mã nhân viên '{codeInput}' đã tồn tại trong hệ thống. Vui lòng sử dụng Mã NV khác!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Chặn trùng và kiểm tra định dạng Email nhân viên
            string emailInput = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(emailInput))
            {
                if (!Utils.ValidationHelper.IsValidEmail(emailInput))
                {
                    MessageBox.Show("Email không đúng định dạng. Vui lòng nhập đúng định dạng Email (VD: name@domain.com).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var allEmps = await _service.GetVisibleEmployeesAsync();
                if (allEmps.Any(e => (_isNew || e.EmployeeId != _entity?.EmployeeId) && e.Email?.Trim().Equals(emailInput, StringComparison.OrdinalIgnoreCase) == true))
                {
                    MessageBox.Show($"Email '{emailInput}' đã được đăng ký cho một nhân viên khác!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 2. Kiểm tra ngày vào làm (Không được ở tương lai)
            if (dtpNgayVaoLam.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày ký/vào làm không được ở thời điểm tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Kiểm tra lương cơ bản (Không âm)
            decimal.TryParse(txtLuongCoBan.Text.Trim(), out decimal luongCB);
            if (luongCB < 0)
            {
                MessageBox.Show("Mức lương cơ bản không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? deptId = null;
            if (cboPhongBan.SelectedItem != null)
            {
                var pStr = cboPhongBan.SelectedItem.ToString();
                if (pStr != null && pStr.Contains("-"))
                {
                    if (int.TryParse(pStr.Split('-')[0].Trim(), out int dId)) deptId = dId;
                }
            }
            
            int? posId = null;
            if (cboChucVu.SelectedItem != null)
            {
                var pStr = cboChucVu.SelectedItem.ToString();
                if (pStr != null && pStr.Contains("-"))
                {
                    if (int.TryParse(pStr.Split('-')[0].Trim(), out int pId)) posId = pId;
                }
            }

            var nv = new EmployeeDTO
            {
                EmployeeCode = txtMaNV.Text.Trim(),
                FullName = txtHoTen.Text.Trim(),
                Gender = cboGioiTinh.SelectedItem?.ToString(),
                BirthDate = dtpNgaySinh.Value.Date,
                CitizenId = string.IsNullOrWhiteSpace(txtCCCD.Text) ? null : txtCCCD.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim(),
                DepartmentId = deptId,
                PositionId = posId,
                HireDate = dtpNgayVaoLam.Value.Date,
                BaseSalary = luongCB,
                Status = cboTrangThai.SelectedItem?.ToString() ?? "Active"
            };

            if (!_isNew && _entity != null)
                nv.EmployeeId = _entity.EmployeeId;

            // Kiểm tra ràng buộc: 1 phòng ban chỉ được phép có 1 Trưởng phòng
            var selectedPos = _positionsList.FirstOrDefault(p => p.PositionId == posId);
            bool isTruongPhong = posId == 2 || (selectedPos != null && selectedPos.PositionName.Contains("Trưởng"));

            if (isTruongPhong && deptId.HasValue)
            {
                try
                {
                    var allEmps = await _service.GetVisibleEmployeesAsync();
                    var oldManager = allEmps.FirstOrDefault(e => e.DepartmentId == deptId.Value && e.EmployeeId != nv.EmployeeId &&
                        (e.PositionId == 2 || (_positionsList.FirstOrDefault(p => p.PositionId == e.PositionId)?.PositionName.Contains("Trưởng") == true)));

                    if (oldManager != null)
                    {
                        var confirm = MessageBox.Show(
                            $"Phòng ban này hiện đã có Trưởng phòng là '{oldManager.FullName}'.\n\nBạn có muốn bổ nhiệm '{nv.FullName}' làm Trưởng phòng mới và chuyển '{oldManager.FullName}' về chức vụ Nhân viên không?",
                            "Xác nhận thay thế Trưởng phòng",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirm != DialogResult.Yes) return;

                        // Chuyển Trưởng phòng cũ về Nhân viên (position_id = 3 & role_id = 3)
                        oldManager.PositionId = 3;
                        await _service.UpdateAsync(oldManager);

                        var accBll = new AccountBLL();
                        var accDal = new AccountDAL();
                        var allAccs = await accBll.GetAllAsync();
                        var oldAcc = allAccs.FirstOrDefault(a => a.EmployeeId == oldManager.EmployeeId);
                        if (oldAcc != null && oldAcc.RoleId == 2)
                        {
                            oldAcc.RoleId = 3;
                            await accDal.UpdateAsync(oldAcc);
                        }
                    }
                }
                catch { }
            }

            try
            {
                (bool ok, string msg) res;
                if (_isNew) res = await _service.CreateAsync(nv);
                else res = await _service.UpdateAsync(nv);

                if (res.ok)
                {
                    int targetEmpId = nv.EmployeeId > 0 ? nv.EmployeeId : (Result?.EmployeeId ?? nv.EmployeeId);

                    // Cập nhật manager_id trong bảng departments & role_id trong bảng accounts
                    try
                    {
                        var accBll = new AccountBLL();
                        var accDal = new AccountDAL();
                        var allAccs = await accBll.GetAllAsync();
                        var targetAcc = allAccs.FirstOrDefault(a => a.EmployeeId == targetEmpId);

                        if (isTruongPhong)
                        {
                            if (deptId.HasValue)
                            {
                                var deptBll = new DepartmentBLL();
                                var dept = await deptBll.GetByIdAsync(deptId.Value);
                                if (dept != null)
                                {
                                    dept.ManagerId = targetEmpId;
                                    await deptBll.UpdateAsync(dept);
                                }
                            }
                            if (targetAcc != null && targetAcc.RoleId != 1) // Giữ nguyên nếu là Admin
                            {
                                targetAcc.RoleId = 2; // Manager
                                await accDal.UpdateAsync(targetAcc);
                            }
                        }
                        else
                        {
                            if (deptId.HasValue)
                            {
                                var deptBll = new DepartmentBLL();
                                var dept = await deptBll.GetByIdAsync(deptId.Value);
                                if (dept != null && dept.ManagerId == targetEmpId)
                                {
                                    dept.ManagerId = null;
                                    await deptBll.UpdateAsync(dept);
                                }
                            }
                            if (targetAcc != null && targetAcc.RoleId == 2)
                            {
                                targetAcc.RoleId = 3; // Employee
                                await accDal.UpdateAsync(targetAcc);
                            }
                        }
                    }
                    catch { }

                    // Tự động khởi tạo hoặc cập nhật Hợp đồng Lao động theo loại hợp đồng đã chọn
                    if (targetEmpId > 0)
                    {
                        try
                        {
                            var contractBll = new ContractBLL();
                            var contracts = await contractBll.GetByEmployeeIdAsync(targetEmpId);
                            var contract = contracts.FirstOrDefault(c => c.Status == "Active") ?? contracts.FirstOrDefault();

                            string selectedType = cboLoaiHD.SelectedItem?.ToString() ?? "Thử việc";
                            DateTime startDate = nv.HireDate != DateTime.MinValue ? nv.HireDate : DateTime.Today;
                            DateTime? endDate = selectedType == "Thử việc" ? startDate.AddMonths(2) :
                                                selectedType == "Hữu hạn" ? startDate.AddYears(1) : (DateTime?)null;
                            decimal finalSalary = nv.BaseSalary > 0 ? nv.BaseSalary : luongCB;

                            if (contract != null)
                            {
                                contract.ContractType = selectedType;
                                contract.StartDate = startDate;
                                contract.EndDate = endDate;
                                if (finalSalary > 0) contract.Salary = finalSalary;
                                await contractBll.UpdateAsync(contract);
                            }
                            else
                            {
                                string empCodeStr = !string.IsNullOrWhiteSpace(nv.EmployeeCode) ? nv.EmployeeCode : $"NV{targetEmpId:D3}";
                                string newCode = $"HD-{empCodeStr}";

                                var allContracts = await contractBll.GetAllAsync();
                                if (allContracts.Any(c => c.ContractCode.Equals(newCode, StringComparison.OrdinalIgnoreCase)))
                                {
                                    newCode = $"HD-{empCodeStr}-{targetEmpId}";
                                }

                                var newContract = new ContractDTO
                                {
                                    ContractCode = newCode,
                                    EmployeeId = targetEmpId,
                                    ContractType = selectedType,
                                    StartDate = startDate,
                                    EndDate = endDate,
                                    Salary = finalSalary,
                                    Status = "Active"
                                };
                                await contractBll.CreateAsync(newContract);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi tạo/cập nhật hợp đồng: " + ex.Message);
                        }
                    }

                    Result = nv;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}

