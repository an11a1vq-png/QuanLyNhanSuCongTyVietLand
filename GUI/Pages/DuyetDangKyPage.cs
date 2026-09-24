using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;
using VietLandHR.Utils;

namespace VietLandHR.GUI.Pages
{
    public partial class DuyetDangKyPage : UserControl
    {
        private readonly RegistrationRequestBLL _bll = new RegistrationRequestBLL();
        private readonly DepartmentBLL _deptBLL = new DepartmentBLL();
        private readonly PositionBLL _posBLL = new PositionBLL();

        private List<RegistrationRequestDTO> _pendingList = new List<RegistrationRequestDTO>();
        private List<DepartmentDTO> _departments = new List<DepartmentDTO>();
        private List<PositionDTO> _positions = new List<PositionDTO>();
        private RegistrationRequestDTO? _selected = null;

        public DuyetDangKyPage()
        {
            InitializeComponent();
            
            // Apply Styling
            UIHelper.StyleButton(btnRefresh, UIHelper.ButtonType.Secondary);
            UIHelper.StyleButton(btnApprove, UIHelper.ButtonType.Success);
            UIHelper.StyleButton(btnReject, UIHelper.ButtonType.Danger);
            
            this.Load += async (s, e) => await InitComboboxesAndData();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            _ = LoadDataAsync();
        }

        private void dgvPending_SelectionChanged(object? sender, EventArgs e)
        {
            int selectedCount = dgvPending.SelectedRows.Count;
            if (selectedCount == 0)
            {
                _selected = null;
                lblInfo.Text = $"Có {_pendingList.Count} yêu cầu đăng ký đang chờ duyệt.";
                return;
            }

            if (selectedCount == 1)
            {
                var val = dgvPending.SelectedRows[0].Cells[0].Value;
                if (val != null)
                {
                    var id = Convert.ToInt32(val);
                    _selected = _pendingList.Find(x => x.RegistrationId == id);
                    lblInfo.Text = _selected != null
                        ? $"Đang chọn: {_selected.FullName} ({_selected.Email}) – Gán phòng ban & chức vụ rồi bấm Duyệt"
                        : "Chọn một hoặc nhiều yêu cầu đăng ký (dùng Ctrl/Shift)...";
                }
            }
            else
            {
                _selected = null;
                lblInfo.Text = $"⚡ ĐANG CHỌN HÀNG LOẠT: {selectedCount} yêu cầu – Gán Phòng ban & Chức vụ (nếu cần) rồi bấm Duyệt / Từ Chối Hàng Loạt";
            }
        }

        private void pnlBottom_Paint(object? sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, pnlBottom.Width - 1, pnlBottom.Height - 1);
            using var pen = new Pen(Color.FromArgb(226, 232, 240));
            e.Graphics.DrawRectangle(pen, rect);
        }

        private async void btnApprove_Click(object? sender, EventArgs e)
        {
            if (!btnApprove.Enabled) return;

            int selectedCount = dgvPending.SelectedRows.Count;
            if (selectedCount == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 yêu cầu đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int deptId = cbDepartment.SelectedValue != null ? Convert.ToInt32(cbDepartment.SelectedValue) : 1;
            int posId = cbPosition.SelectedValue != null ? Convert.ToInt32(cbPosition.SelectedValue) : 1;

            if (selectedCount == 1 && _selected != null && cbDepartment.SelectedIndex == -1 && cbPosition.SelectedIndex == -1)
            {
                using var dialog = new VietLandHR.GUI.Dialogs.TaiKhoanDialog(null);
                dialog.RegistrationData = _selected;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _selected = null;
                    await LoadDataAsync();
                }
                return;
            }

            // Kiểm tra nếu duyệt với chức vụ Trưởng phòng (posId = 2) và phòng ban đã có Trưởng phòng cũ
            if (posId == 2 && deptId > 0)
            {
                try
                {
                    var empBll = new EmployeeBLL();
                    var allEmps = await empBll.GetVisibleEmployeesAsync();
                    var oldManager = allEmps.FirstOrDefault(e => e.DepartmentId == deptId && e.PositionId == 2);
                    if (oldManager != null)
                    {
                        var deptName = _departments.FirstOrDefault(d => d.DepartmentId == deptId)?.DepartmentName ?? "";
                        var confirmMsg = $"Phòng ban '{deptName}' hiện đã có Trưởng phòng là '{oldManager.FullName}'.\n\nKhi bạn duyệt yêu cầu này, người mới sẽ trở thành Trưởng phòng và '{oldManager.FullName}' sẽ được chuyển về chức vụ Nhân viên.\n\nBạn có chắc chắn muốn tiếp tục không?";
                        if (MessageBox.Show(confirmMsg, "Xác nhận thay thế Trưởng phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }
                catch { }
            }

            if (MessageBox.Show($"Xác nhận DUYỆT HÀNG LOẠT {selectedCount} yêu cầu đăng ký đã chọn?", "Xác nhận duyệt hàng loạt",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                int successCount = 0;
                var requestsToApprove = new List<RegistrationRequestDTO>();

                foreach (DataGridViewRow row in dgvPending.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int regId = Convert.ToInt32(row.Cells[0].Value);
                        var req = _pendingList.FirstOrDefault(r => r.RegistrationId == regId);
                        if (req != null) requestsToApprove.Add(req);
                    }
                }

                foreach (var req in requestsToApprove)
                {
                    var (ok, msg) = await _bll.ApproveAsync(req, deptId, posId);
                    if (ok) successCount++;
                }

                MessageBox.Show($"Đã duyệt thành công {successCount}/{selectedCount} yêu cầu đăng ký!", "Hoàn tất duyệt hàng loạt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selected = null;
                await LoadDataAsync();
            }
            finally
            {
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async void btnReject_Click(object? sender, EventArgs e)
        {
            if (!btnReject.Enabled) return;

            int selectedCount = dgvPending.SelectedRows.Count;
            if (selectedCount == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 yêu cầu để từ chối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận TỪ CHỐI HÀNG LOẠT {selectedCount} yêu cầu đăng ký đã chọn?", "Xác nhận từ chối hàng loạt",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                int successCount = 0;
                var requestsToReject = new List<RegistrationRequestDTO>();

                foreach (DataGridViewRow row in dgvPending.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        int regId = Convert.ToInt32(row.Cells[0].Value);
                        var req = _pendingList.FirstOrDefault(r => r.RegistrationId == regId);
                        if (req != null) requestsToReject.Add(req);
                    }
                }

                foreach (var req in requestsToReject)
                {
                    var (ok, msg) = await _bll.RejectAsync(req);
                    if (ok) successCount++;
                }

                MessageBox.Show($"Đã từ chối {successCount}/{selectedCount} yêu cầu đăng ký!", "Hoàn tất",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selected = null;
                await LoadDataAsync();
            }
            finally
            {
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async System.Threading.Tasks.Task InitComboboxesAndData()
        {
            try
            {
                _departments = await _deptBLL.GetAllAsync();
                cbDepartment.DataSource = new System.Collections.Generic.List<DepartmentDTO>(_departments);
                cbDepartment.DisplayMember = "DepartmentName";
                cbDepartment.ValueMember = "DepartmentId";
                cbDepartment.SelectedIndex = -1;

                _positions = await _posBLL.GetAllAsync();
                cbPosition.DataSource = new System.Collections.Generic.List<PositionDTO>(_positions);
                cbPosition.DisplayMember = "PositionName";
                cbPosition.ValueMember = "PositionId";
                cbPosition.SelectedIndex = -1;

                if (this.IsDisposed) return;
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                _pendingList = await _bll.GetPendingAsync();
                if (this.IsDisposed) return;
                dgvPending.Rows.Clear();
                foreach (var item in _pendingList)
                {
                    dgvPending.Rows.Add(
                        item.RegistrationId,
                        item.FullName,
                        item.Email,
                        item.Phone,
                        item.BirthDate,
                        item.CreatedAt.ToLocalTime()
                    );
                }
                lblInfo.Text = $"Có {_pendingList.Count} yêu cầu đăng ký đang chờ duyệt.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

