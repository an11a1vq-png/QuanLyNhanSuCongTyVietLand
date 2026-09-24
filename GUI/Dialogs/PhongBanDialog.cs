using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Helpers;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;
using VietLandHR.DAL;

namespace VietLandHR.GUI.Dialogs
{
    public partial class PhongBanDialog : Form
    {
        private readonly DepartmentBLL _service = new();
        private readonly DepartmentDTO? _entity;
        private readonly bool _isNew;

        public PhongBanDialog(DepartmentDTO? entity)
        {
            _entity = entity;
            _isNew = entity == null;
            InitializeComponent();
            
            this.Text = _isNew ? "Thêm phòng ban mới" : "Sửa thông tin phòng ban";
            lblTitle.Text = _isNew ? "Thêm phòng ban mới" : "Sửa thông tin phòng ban";
            
            UIHelper.ApplyLightBackground(this);
            tbl.BackColor = Color.White;
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

        private List<EmployeeDTO> _empList = new();

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

        private async Task LoadDropdownsAsync()
        {
            try
            {
                _empList = await new EmployeeBLL().GetVisibleEmployeesAsync();
                cboTruongPhong.Items.Clear();
                cboTruongPhong.Items.Add("0 - (Chưa phân công)");
                foreach (var emp in _empList)
                {
                    cboTruongPhong.Items.Add($"{emp.EmployeeId} - {emp.FullName}");
                }
                cboTruongPhong.SelectedIndex = 0;
            }
            catch { }
        }

        private void ApplyMode()
        {
        }

        private void FillData()
        {
            if (_entity == null) return;
            txtTenPB.Text = _entity.DepartmentName;

            if (_entity.ManagerId.HasValue)
            {
                for (int i = 0; i < cboTruongPhong.Items.Count; i++)
                {
                    var itemStr = cboTruongPhong.Items[i]?.ToString();
                    if (itemStr != null && itemStr.StartsWith(_entity.ManagerId.Value.ToString() + " -"))
                    {
                        cboTruongPhong.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private async void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenPB.Text))
            {
                MessageBox.Show("Tên phòng ban không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? managerId = null;
            if (cboTruongPhong.SelectedItem != null)
            {
                var selStr = cboTruongPhong.SelectedItem.ToString();
                if (selStr != null && selStr.Contains("-"))
                {
                    if (int.TryParse(selStr.Split('-')[0].Trim(), out int empId) && empId > 0)
                    {
                        managerId = empId;
                    }
                }
            }

            var pb = new DepartmentDTO
            {
                DepartmentName = txtTenPB.Text.Trim(),
                ManagerId = managerId
            };
            if (!_isNew && _entity != null)
                pb.DepartmentId = _entity.DepartmentId;

            try
            {
                if (_isNew)
                    await _service.CreateAsync(pb);
                else
                    await _service.UpdateAsync(pb);

                // Đồng bộ chức vụ Trưởng phòng cho nhân viên được gán
                if (managerId.HasValue && pb.DepartmentId > 0)
                {
                    try
                    {
                        var empBll = new EmployeeBLL();
                        var allEmps = await empBll.GetVisibleEmployeesAsync();

                        var accBll = new AccountBLL();
                        var accDal = new AccountDAL();
                        var allAccs = await accBll.GetAllAsync();

                        // Chuyển các Trưởng phòng cũ của phòng ban này về Nhân viên (chức vụ 3 & role 3)
                        var oldEmps = allEmps.Where(e => e.DepartmentId == pb.DepartmentId && e.EmployeeId != managerId.Value && e.PositionId == 2).ToList();
                        foreach (var oldE in oldEmps)
                        {
                            oldE.PositionId = 3;
                            await empBll.UpdateAsync(oldE);

                            var oldAcc = allAccs.FirstOrDefault(a => a.EmployeeId == oldE.EmployeeId);
                            if (oldAcc != null && oldAcc.RoleId == 2)
                            {
                                oldAcc.RoleId = 3;
                                await accDal.UpdateAsync(oldAcc);
                            }
                        }

                        // Gán chức vụ Trưởng phòng (position_id = 2) & role_id = 2 (Manager) cho nhân viên mới
                        var newMgr = await empBll.GetByIdAsync(managerId.Value);
                        if (newMgr != null)
                        {
                            newMgr.DepartmentId = pb.DepartmentId;
                            newMgr.PositionId = 2;
                            await empBll.UpdateAsync(newMgr);

                            var newAcc = allAccs.FirstOrDefault(a => a.EmployeeId == newMgr.EmployeeId);
                            if (newAcc != null && newAcc.RoleId != 1) // Giữ nguyên nếu là Admin
                            {
                                newAcc.RoleId = 2; // Manager
                                await accDal.UpdateAsync(newAcc);
                            }
                        }
                    }
                    catch { }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
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

