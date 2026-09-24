using VietLandHR.BLL;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpChamCongPage : UserControl
    {
        private readonly AttendanceBLL _ccService = new();
        private readonly string _maNV;

        public EmpChamCongPage()
        {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkBackground(this);
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkTheme(this._grid);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlTop);
            VietLandHR.GUI.Helpers.UIHelper.ApplyShadow(this.pnlBottom);
            _maNV = GUI.LoginForm.CurrentUser?.MaNV ?? "";
            lblDate.Text = $"📅  {DateTime.Now:dddd, dd/MM/yyyy}";
            SetupFilter();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadGridAsync();
            }
        }

        private void SetupFilter()
        {
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++) cboThang.Items.Add($"Tháng {i}");
            cboThang.SelectedIndex = DateTime.Now.Month - 1;

            cboNam.Items.Clear();
            for (int y = DateTime.Now.Year; y >= DateTime.Now.Year - 3; y--) cboNam.Items.Add(y);
            cboNam.SelectedIndex = 0;
        }

        private async Task LoadGridAsync()
        {
            try
            {
                int thang = cboThang.SelectedIndex + 1;
                int nam   = (int)cboNam.SelectedItem!;
                var list  = await _ccService.GetMyAttendanceAsync();
                var mine  = list.Where(c => c.WorkDate.Month == thang && c.WorkDate.Year == nam).ToList();
                _grid.DataSource = mine.Select(c =>
                {
                    var (wHrs, otHrs) = c.CheckIn.HasValue && c.CheckOut.HasValue
                        ? AttendanceBLL.CalculateWorkAndOTHours(c.CheckIn.Value, c.CheckOut.Value)
                        : (c.TotalHours ?? 0m, 0m);

                    return new
                    {
                        WorkDate  = c.WorkDate.ToString("dd/MM/yyyy"),
                        CheckIn   = FormatTime(c.CheckIn),
                        CheckOut  = FormatTime(c.CheckOut),
                        WorkHours = wHrs.ToString("F1") + "h",
                        OTHours   = otHrs.ToString("F1") + "h",
                        TrangThai = (c.Status == "Active" || string.IsNullOrEmpty(c.Status)) ? "Present" : c.Status
                    };
                }).ToList();

                if (_grid.Columns["WorkDate"] != null) _grid.Columns["WorkDate"].HeaderText = "Ngày chấm";
                if (_grid.Columns["CheckIn"] != null) _grid.Columns["CheckIn"].HeaderText = "Giờ Vào";
                if (_grid.Columns["CheckOut"] != null) _grid.Columns["CheckOut"].HeaderText = "Giờ Ra";
                if (_grid.Columns["WorkHours"] != null) _grid.Columns["WorkHours"].HeaderText = "Giờ làm";
                if (_grid.Columns["OTHours"] != null) _grid.Columns["OTHours"].HeaderText = "Giờ OT";
                if (_grid.Columns["TrangThai"] != null) _grid.Columns["TrangThai"].HeaderText = "Trạng thái";
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}"); }
        }

        private async void BtnCheckIn_Click(object sender, EventArgs e)
        {
            var btn = sender as Control;
            if (btn != null) btn.Enabled = false;
            try
            {
                var (ok, msg) = await _ccService.CheckInAsync();
                lblStatus.Text      = msg;
                lblStatus.ForeColor = ok ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
                if (ok) await LoadGridAsync();
            }
            finally
            {
                if (btn != null) btn.Enabled = true;
            }
        }

        private async void BtnCheckOut_Click(object sender, EventArgs e)
        {
            var btn = sender as Control;
            if (btn != null) btn.Enabled = false;
            try
            {
                var (ok, msg) = await _ccService.CheckOutAsync();
                lblStatus.Text      = msg;
                lblStatus.ForeColor = ok ? Color.FromArgb(52, 211, 153) : Color.FromArgb(248, 113, 113);
                if (ok) await LoadGridAsync();
            }
            finally
            {
                if (btn != null) btn.Enabled = true;
            }
        }

        private async void BtnXem_Click(object sender, EventArgs e) => await LoadGridAsync();

        private static string FormatTime(DateTime? dt)
        {
            if (!dt.HasValue) return "—";
            DateTime d = dt.Value;
            DateTime local = d.Kind == DateTimeKind.Utc ? d.ToLocalTime() : d;

            if (local.Hour >= 19 && local.Hour <= 23)
            {
                local = local.AddHours(-7);
            }

            return local.ToString(@"HH\:mm");
        }
    }
}



