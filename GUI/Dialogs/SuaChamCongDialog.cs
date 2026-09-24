using System;
using System.Drawing;
using System.Windows.Forms;
using VietLandHR.BLL;
using VietLandHR.DTOs;

namespace VietLandHR.GUI.Dialogs
{
    public partial class SuaChamCongDialog : Form
    {
        private readonly AttendanceBLL _bll = new();
        private readonly AttendanceDTO _item;
        private readonly string _tenNV;

        public SuaChamCongDialog(AttendanceDTO item, string tenNV)
        {
            InitializeComponent();
            _item = item;
            _tenNV = tenNV;
            SetupData();
        }

        private void SetupData()
        {
            lblInfo.Text = $"👤 Nhân viên: {_tenNV}\n📅 Ngày chấm công: {_item.WorkDate:dd/MM/yyyy}";

            if (_item.CheckIn.HasValue)
            {
                dtpCheckInDate.Value = _item.CheckIn.Value.ToLocalTime();
                dtpCheckInTime.Value = _item.CheckIn.Value.ToLocalTime();
            }
            else
            {
                dtpCheckInDate.Value = _item.WorkDate.Date.AddHours(8);
                dtpCheckInTime.Value = _item.WorkDate.Date.AddHours(8);
            }

            if (_item.CheckOut.HasValue)
            {
                dtpCheckOutDate.Value = _item.CheckOut.Value.ToLocalTime();
                dtpCheckOutTime.Value = _item.CheckOut.Value.ToLocalTime();
            }
            else
            {
                dtpCheckOutDate.Value = _item.WorkDate.Date.AddHours(17).AddMinutes(30);
                dtpCheckOutTime.Value = _item.WorkDate.Date.AddHours(17).AddMinutes(30);
            }

            cboStatus.SelectedItem = _item.Status ?? "Present";
        }

        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            DateTime checkIn = dtpCheckInDate.Value.Date + dtpCheckInTime.Value.TimeOfDay;
            DateTime checkOut = dtpCheckOutDate.Value.Date + dtpCheckOutTime.Value.TimeOfDay;

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Giờ Check-out phải lớn hơn giờ Check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = cboStatus.SelectedItem?.ToString() ?? "Present";

            btnLuu.Enabled = false;
            try
            {
                var (ok, msg) = await _bll.UpdateAttendanceAdminAsync(_item.AttendanceId, checkIn, checkOut, status);
                if (ok)
                {
                    MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(msg, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLuu.Enabled = true;
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

