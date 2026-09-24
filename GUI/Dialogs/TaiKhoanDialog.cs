using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using UIHelper = VietLandHR.GUI.Helpers.UIHelper;
using VietLandHR.Utils;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;

namespace VietLandHR.GUI.Dialogs
{
    public partial class TaiKhoanDialog : Form
    {
        private readonly AccountDAL _repo = new();
        private readonly AccountDTO? _entity;
        private readonly bool _isNew;

        private RegistrationRequestDTO? _regData;
        public RegistrationRequestDTO? RegistrationData
        {
            get => _regData;
            set
            {
                _regData = value;
                if (_regData != null)
                {
                    txtTenDN.Text = _regData.Email;
                    txtHoTen.Text = _regData.FullName;
                    txtEmail.Text = _regData.Email;
                    txtSDT.Text = _regData.Phone;
                }
            }
        }

        public TaiKhoanDialog(AccountDTO? entity)
        {
            _entity = entity;
            _isNew = entity == null;
            InitializeComponent();
            
            lblTitle.Text = _isNew ? "➕  Tạo tài khoản mới" : "🔐  Thông tin tài khoản";
            
            UIHelper.ApplyLightBackground(this);
            tbl.BackColor = Color.White;
            
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.AddRange(new object[] { "1 (Admin)", "2 (Manager)", "3 (Employee)" });
            cboVaiTro.SelectedIndex = 2;

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGioiTinh.SelectedIndex = 0;

            cboLoaiHD.Items.Clear();
            cboLoaiHD.Items.AddRange(new object[] { "Thử việc", "Hữu hạn", "Vô hạn" });
            cboLoaiHD.SelectedIndex = 0;
            
            lblMatKhau.Visible = _isNew;
            txtMatKhau.Visible = _isNew;
            
            btnResetPass.Visible = !_isNew;
            btnResetPass.Click += BtnResetPass_Click;

            // btnDoiPass chỉ hiện khi chỉnh sửa (không phải tạo mới)
            btnDoiPass.Visible = !_isNew;
            
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
            
            this.Load += async (s, e) => await InitAndFillDataAsync();
        }

        private async System.Threading.Tasks.Task InitAndFillDataAsync()
        {
            try
            {
                var depts = await new DepartmentBLL().GetAllAsync();
                cboPhongBan.DataSource = depts;
                cboPhongBan.DisplayMember = "DepartmentName";
                cboPhongBan.ValueMember = "DepartmentId";

                var poss = await new PositionBLL().GetAllAsync();
                cboChucVu.DataSource = poss;
                cboChucVu.DisplayMember = "PositionName";
                cboChucVu.ValueMember = "PositionId";

                cboChucVu.SelectedIndexChanged -= CboChucVu_SelectedIndexChanged;
                cboChucVu.SelectedIndexChanged += CboChucVu_SelectedIndexChanged;

                if (_isNew)
                {
                    txtTenDN.ReadOnly = false;
                    txtMatKhau.Text = "123456";
                    txtMatKhau.ReadOnly = true;
                    txtMatKhau.FillColor = Color.FromArgb(241, 245, 249);
                    cboVaiTro.SelectedIndex = 2;

                    if (_regData != null)
                    {
                        txtTenDN.Text = _regData.Email;
                        txtEmail.Text = _regData.Email;
                        txtHoTen.Text = _regData.FullName;
                        txtSDT.Text = _regData.Phone;
                        if (_regData.BirthDate.HasValue) dtpNgaySinh.Value = _regData.BirthDate.Value;

                        // Nếu là duyệt đơn đăng ký -> Khóa không cho sửa Tên ĐN / Email
                        txtTenDN.ReadOnly = true;
                        txtTenDN.FillColor = Color.FromArgb(241, 245, 249);
                    }
                }
                else if (_entity != null)
                {
                    txtTenDN.ReadOnly = false; // Cho phép sửa Tên đăng nhập / Email ở màn hình Tài khoản
                    txtTenDN.FillColor = Color.White;
                    txtMatKhau.ReadOnly = false;
                    txtTenDN.Text = _entity.Username;
                    txtEmail.Text = _entity.Username;
                    txtMatKhau.Text = "";
                    cboVaiTro.SelectedIndex = (_entity.RoleId >= 1 && _entity.RoleId <= 3) ? _entity.RoleId - 1 : 2;

                    // Chặn Admin tự đổi Vai Trò của chính mình
                    bool isSelf = _entity.AccountId == SessionManager.CurrentAccount?.AccountId;
                    if (isSelf)
                    {
                        cboVaiTro.Enabled = false;
                    }

                    if (_entity.EmployeeId.HasValue)
                    {
                        var emp = await new EmployeeBLL().GetByIdAsync(_entity.EmployeeId.Value);
                        if (emp != null)
                        {
                            txtHoTen.Text = emp.FullName;
                            if (!string.IsNullOrEmpty(emp.Gender)) cboGioiTinh.SelectedItem = emp.Gender;
                            if (emp.BirthDate.HasValue) dtpNgaySinh.Value = emp.BirthDate.Value;
                            txtSDT.Text = emp.Phone;
                            txtEmail.Text = emp.Email ?? _entity.Username;
                            if (emp.DepartmentId.HasValue) cboPhongBan.SelectedValue = emp.DepartmentId.Value;
                            if (emp.PositionId.HasValue) cboChucVu.SelectedValue = emp.PositionId.Value;

                            // Hiển thị lương cơ bản (fallback theo chức vụ nếu = 0)
                            decimal salary = emp.BaseSalary;
                            if (salary == 0 && emp.PositionId.HasValue && cboChucVu.DataSource is List<PositionDTO> posList)
                            {
                                var pos = posList.FirstOrDefault(p => p.PositionId == emp.PositionId.Value);
                                if (pos != null && pos.BaseSalary > 0) salary = pos.BaseSalary;
                            }
                            txtLuong.Text = salary > 0 ? salary.ToString("0.##") : "";

                            // Đọc hợp đồng cá nhân
                            try
                            {
                                var contracts = await new ContractBLL().GetByEmployeeIdAsync(emp.EmployeeId);
                                var contract = contracts.FirstOrDefault(c => c.Status == "Active") ?? contracts.FirstOrDefault();
                                if (contract != null)
                                {
                                    if (!string.IsNullOrEmpty(contract.ContractType)) cboLoaiHD.SelectedItem = contract.ContractType;
                                    if (contract.StartDate != DateTime.MinValue) dtpNgayBD.Value = contract.StartDate;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch
            {
                // Ignored
            }
        }

        private void CboChucVu_SelectedIndexChanged(object? sender, EventArgs e)
        {
            PositionDTO? pos = cboChucVu.SelectedItem as PositionDTO;
            if (pos == null && cboChucVu.SelectedValue is int posId && cboChucVu.DataSource is List<PositionDTO> posList)
            {
                pos = posList.FirstOrDefault(p => p.PositionId == posId);
            }

            if (pos != null && pos.BaseSalary > 0)
            {
                txtLuong.Text = pos.BaseSalary.ToString("0.##");
            }
        }

        private async void BtnResetPass_Click(object? sender, EventArgs e)
        {
            if (_entity == null) return;
            if (MessageBox.Show($"Xác nhận Reset mật khẩu tài khoản '{_entity.Username}' về mặc định ('123456')?",
                "Xác nhận Reset Mật Khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                _entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456");
                await _repo.UpdateAsync(_entity);
                MessageBox.Show($"Đã Reset mật khẩu cho tài khoản '{_entity.Username}' thành công!\nMật khẩu mới: 123456",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Reset mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDN.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập (Email) và Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string emailInput = txtTenDN.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(emailInput, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email/Tên đăng nhập không hợp lệ. Vui lòng nhập đúng định dạng (VD: name@gmail.com).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdtInput = txtSDT.Text.Trim();
            if (!string.IsNullOrEmpty(sdtInput))
            {
                if (sdtInput.Length != 10 || !sdtInput.StartsWith("0") || !sdtInput.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số, chỉ chứa số và bắt đầu bằng số 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                if (_isNew)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text) || txtMatKhau.Text.Trim().Length < 6)
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu có độ dài ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra độ tuổi nếu có tạo hồ sơ nhân viên
                    if (!string.IsNullOrWhiteSpace(txtHoTen.Text) && dtpNgaySinh.Value > DateTime.Today.AddYears(-18))
                    {
                        MessageBox.Show("Nhân viên phải từ đủ 18 tuổi trở lên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra lương không âm
                    decimal.TryParse(txtLuong.Text.Trim(), out decimal checkSal);
                    if (checkSal < 0)
                    {
                        MessageBox.Show("Mức lương không được là số âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string username = txtTenDN.Text.Trim();
                    
                    // Chặn trùng Tên đăng nhập / Email trong bảng accounts
                    var existingAcc = await _repo.GetByUsernameAsync(username);
                    if (existingAcc != null)
                    {
                        MessageBox.Show($"Tên đăng nhập / Email '{username}' đã tồn tại tài khoản trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string rawPassword = txtMatKhau.Text.Trim();
                    var client = SupabaseClientManager.Instance.GetClient();
                    var adminSession = client.Auth.CurrentSession;

                    string? authUserId = null;
                    try
                    {
                        var authSession = await client.Auth.SignUp(username, rawPassword);
                        authUserId = authSession?.User?.Id;
                    }
                    catch
                    {
                        try
                        {
                            var loginSession = await client.Auth.SignInWithPassword(username, rawPassword);
                            authUserId = loginSession?.User?.Id;
                        }
                        catch
                        {
                            authUserId = Guid.NewGuid().ToString();
                        }
                    }

                    if (adminSession?.AccessToken != null)
                        await client.Auth.SetSession(adminSession.AccessToken, adminSession.RefreshToken ?? "");

                    if (string.IsNullOrEmpty(authUserId))
                        authUserId = Guid.NewGuid().ToString();

                    // 2. Tạo Hồ sơ Nhân viên mới nếu có nhập tên
                    int? createdEmpId = null;
                    if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                    {
                        var empBll = new EmployeeBLL();

                        // Chặn trùng Email nhân viên
                        var allEmps = await empBll.GetVisibleEmployeesAsync();
                        if (allEmps.Any(e => e.Email?.Trim().Equals(username, StringComparison.OrdinalIgnoreCase) == true))
                        {
                            MessageBox.Show($"Email '{username}' đã được đăng ký cho một nhân viên khác!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string newCode = await empBll.GetNextEmployeeCodeAsync();
                        if (allEmps.Any(e => e.EmployeeCode?.Trim().Equals(newCode, StringComparison.OrdinalIgnoreCase) == true))
                        {
                            MessageBox.Show($"Mã nhân viên '{newCode}' đã tồn tại trong hệ thống!", "Cảnh báo trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int? deptId = cboPhongBan.SelectedValue is int dId ? dId : null;
                        int? posId = cboChucVu.SelectedValue is int pId ? pId : null;
                        decimal.TryParse(txtLuong.Text.Trim(), out decimal sal);

                        var emp = new EmployeeDTO
                        {
                            FullName = txtHoTen.Text.Trim(),
                            Email = username,
                            Phone = txtSDT.Text.Trim(),
                            Gender = cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                            BirthDate = dtpNgaySinh.Value.Date,
                            DepartmentId = deptId,
                            PositionId = posId,
                            BaseSalary = sal,
                            HireDate = dtpNgayBD.Value.Date,
                            Status = "Active",
                            EmployeeCode = newCode
                        };
                        var empRes = await client.From<EmployeeDTO>().Insert(emp);
                        if (empRes.Models.Count > 0)
                        {
                            createdEmpId = empRes.Models[0].EmployeeId;

                            // Tạo Hợp đồng lao động
                            string loaiHD = cboLoaiHD.SelectedItem?.ToString() ?? "Thử việc";
                            DateTime startDate = dtpNgayBD.Value.Date;
                            DateTime? endDate = loaiHD == "Thử việc" ? startDate.AddMonths(2) :
                                                loaiHD == "Hữu hạn" ? startDate.AddYears(1) : (DateTime?)null;

                            var contract = new ContractDTO
                            {
                                ContractCode = $"HD-{newCode}",
                                EmployeeId = createdEmpId.Value,
                                ContractType = loaiHD,
                                StartDate = startDate,
                                EndDate = endDate,
                                Salary = sal,
                                Status = "Active"
                            };
                            await new ContractBLL().CreateAsync(contract);
                        }
                    }

                    // 3. Tạo tài khoản trong bảng accounts
                    var tk = new AccountDTO
                    {
                        UserId = Guid.Parse(authUserId),
                        Username = username,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(rawPassword),
                        RoleId = cboVaiTro.SelectedIndex + 1,
                        EmployeeId = createdEmpId,
                        IsActive = true
                    };
                    await _repo.CreateAsync(tk);

                    // 4. Nếu được tạo từ Yêu cầu Đăng ký -> Cập nhật trạng thái Yêu cầu thành Approved
                    if (_regData != null)
                    {
                        try
                        {
                            _regData.Status = "Approved";
                            _regData.ReviewedBy = SessionManager.CurrentAccount?.EmployeeId;
                            _regData.ReviewedAt = DateTime.UtcNow;
                            await new RegistrationRequestDAL().UpdateAsync(_regData);
                        }
                        catch { }
                    }

                    MessageBox.Show("Tạo tài khoản và đồng bộ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (_entity != null)
                    {
                        bool isSelf = _entity.AccountId == SessionManager.CurrentAccount?.AccountId;
                        int newRoleId = cboVaiTro.SelectedIndex + 1;
                        if (isSelf && newRoleId != 1)
                        {
                            MessageBox.Show("Bạn không thể tự hạ quyền Admin của chính mình!", "Cảnh báo an toàn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _entity.RoleId = newRoleId;
                        _entity.Username = emailInput;
                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            _entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                        }
                        await _repo.UpdateAsync(_entity);

                        // Cập nhật thông tin nhân viên liên kết
                        if (_entity.EmployeeId.HasValue)
                        {
                            var emp = await new EmployeeBLL().GetByIdAsync(_entity.EmployeeId.Value);
                            if (emp != null)
                            {
                                emp.Email = emailInput;
                                if (!string.IsNullOrWhiteSpace(txtHoTen.Text)) emp.FullName = txtHoTen.Text.Trim();
                                if (!string.IsNullOrWhiteSpace(txtSDT.Text)) emp.Phone = txtSDT.Text.Trim();
                                if (cboGioiTinh.SelectedItem != null) emp.Gender = cboGioiTinh.SelectedItem.ToString();
                                emp.BirthDate = dtpNgaySinh.Value.Date;
                                if (cboPhongBan.SelectedValue is int deptId) emp.DepartmentId = deptId;
                                if (cboChucVu.SelectedValue is int posId) emp.PositionId = posId;
                                decimal.TryParse(txtLuong.Text.Trim(), out decimal sal);
                                if (sal > 0) emp.BaseSalary = sal;
                                await new EmployeeBLL().UpdateAsync(emp);

                                // Đồng bộ thông tin Hợp đồng
                                try
                                {
                                    var contractBll = new ContractBLL();
                                    var contracts = await contractBll.GetByEmployeeIdAsync(emp.EmployeeId);
                                    var contract = contracts.FirstOrDefault(c => c.Status == "Active") ?? contracts.FirstOrDefault();
                                    string loaiHD = cboLoaiHD.SelectedItem?.ToString() ?? "Thử việc";

                                    if (contract != null)
                                    {
                                        contract.ContractType = loaiHD;
                                        contract.StartDate = dtpNgayBD.Value.Date;
                                        if (sal > 0) contract.Salary = sal;
                                        await contractBll.UpdateAsync(contract);
                                    }
                                    else
                                    {
                                        string empCodeStr = !string.IsNullOrWhiteSpace(emp.EmployeeCode) ? emp.EmployeeCode : $"NV{emp.EmployeeId:D3}";
                                        string newCode = $"HD-{empCodeStr}";
                                        var allContracts = await contractBll.GetAllAsync();
                                        if (allContracts.Any(c => c.ContractCode.Equals(newCode, StringComparison.OrdinalIgnoreCase)))
                                        {
                                            newCode = $"HD-{empCodeStr}-{emp.EmployeeId}";
                                        }

                                        var newContract = new ContractDTO
                                        {
                                            ContractCode = newCode,
                                            EmployeeId = emp.EmployeeId,
                                            ContractType = loaiHD,
                                            StartDate = dtpNgayBD.Value.Date,
                                            Salary = sal,
                                            Status = "Active"
                                        };
                                        await contractBll.CreateAsync(newContract);
                                    }
                                }
                                catch { }
                            }
                        }

                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnDoiPass_Click(object? sender, EventArgs e)
        {
            if (_entity?.AccountId == SessionManager.CurrentAccount?.AccountId)
            {
                using var dlg = new DoiMatKhauDialog();
                dlg.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn chỉ có thể đổi mật khẩu của chính mình.\nDùng nút 'Reset Mật Khẩu' để đặt lại mật khẩu cho tài khoản khác.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f);
            e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
        
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}

