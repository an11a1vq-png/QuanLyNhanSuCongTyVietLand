using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Dialogs
{
    public partial class DanhSachNhanVienPhongBanDialog : Form
    {
        private readonly DepartmentDTO _department;
        private readonly EmployeeBLL _empService = new();
        private readonly PositionBLL _posService = new();

        private List<EmployeeDTO> _allDepartmentEmployees = new();
        private List<PositionDTO> _positionsList = new();

        public DanhSachNhanVienPhongBanDialog()
        {
            _department = new DepartmentDTO { DepartmentId = 0, DepartmentName = "Phòng ban" };
            InitializeComponent();
            
            UIHelper.ApplyLightBackground(this);

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

        public DanhSachNhanVienPhongBanDialog(DepartmentDTO department) : this()
        {
            _department = department;
            this.Text = $"Danh sách nhân viên - {department.DepartmentName}";
            lblTitle.Text = $"👥  Danh sách Nhân viên — {department.DepartmentName}";

            this.Load += async (s, e) => await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _positionsList = await _posService.GetAllAsync();
                var allEmps = await _empService.GetVisibleEmployeesAsync();
                
                _allDepartmentEmployees = allEmps.Where(e => e.DepartmentId == _department.DepartmentId).ToList();
                
                BindGrid(_allDepartmentEmployees);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<EmployeeDTO> list)
        {
            int index = 1;
            _grid.DataSource = list.Select(e =>
            {
                string positionName = "Nhân viên";
                if (e.PositionId.HasValue)
                {
                    var pos = _positionsList.FirstOrDefault(p => p.PositionId == e.PositionId.Value);
                    if (pos != null) positionName = pos.PositionName;
                }

                return new
                {
                    STT = index++,
                    EmployeeCode = e.EmployeeCode,
                    FullName = e.FullName,
                    PositionName = positionName,
                    Phone = string.IsNullOrWhiteSpace(e.Phone) ? "—" : e.Phone,
                    Email = string.IsNullOrWhiteSpace(e.Email) ? "—" : e.Email,
                    Status = e.Status == "Active" ? "Đang làm việc" : "Nghỉ việc"
                };
            }).ToList();

            if (_grid.Columns["STT"] != null) { _grid.Columns["STT"].HeaderText = "STT"; _grid.Columns["STT"].Width = 55; }
            if (_grid.Columns["EmployeeCode"] != null) { _grid.Columns["EmployeeCode"].HeaderText = "Mã NV"; _grid.Columns["EmployeeCode"].Width = 90; }
            if (_grid.Columns["FullName"] != null) _grid.Columns["FullName"].HeaderText = "Họ và Tên";
            if (_grid.Columns["PositionName"] != null) _grid.Columns["PositionName"].HeaderText = "Chức vụ";
            if (_grid.Columns["Phone"] != null) _grid.Columns["Phone"].HeaderText = "Số điện thoại";
            if (_grid.Columns["Email"] != null) _grid.Columns["Email"].HeaderText = "Email";
            if (_grid.Columns["Status"] != null) _grid.Columns["Status"].HeaderText = "Trạng thái";

            lblCount.Text = $"📊  Tổng số: {list.Count} nhân viên";
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw))
            {
                BindGrid(_allDepartmentEmployees);
                return;
            }

            var filtered = _allDepartmentEmployees.Where(e =>
                (e.FullName != null && e.FullName.ToLower().Contains(kw)) ||
                (e.EmployeeCode != null && e.EmployeeCode.ToLower().Contains(kw)) ||
                (e.Phone != null && e.Phone.Contains(kw)) ||
                (e.Email != null && e.Email.ToLower().Contains(kw))
            ).ToList();

            BindGrid(filtered);
        }

        private void BtnDong_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(99, 102, 241), 2f), 0, 0, Width - 1, Height - 1);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
