using VietLandHR.GUI.Pages.Employee;

namespace VietLandHR.GUI
{
    public partial class EmployeeDashboard : Form
    {
        private UserControl? _currentPage;

        public EmployeeDashboard()
        {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyLightBackground(this);
            SetupDashboard();
            SetupFormDrag();
        }

        private void SetupDashboard()
        {
            var user = LoginForm.CurrentUser;
            lblUserInfo.Text = $"👤  {user?.TenDangNhap}";

            // Style all sidebar buttons as RadioButtons so they highlight when selected
            var navButtons = new[] { btnChamCong, btnNghiPhep, btnLuong, btnHopDong, btnThongTin, btnGopY };
            foreach (var btn in navButtons)
            {
                btn.Animated = true;
                btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                btn.CheckedState.FillColor = Color.FromArgb(67, 56, 202);
                btn.CheckedState.ForeColor = Color.White;
                btn.HoverState.FillColor = Color.FromArgb(224, 231, 255);
                btn.HoverState.ForeColor = Color.FromArgb(67, 56, 202);
            }

            btnChamCong.Checked = true;
            LoadPage(new EmpChamCongPage(), "Chấm công");
        }

        private void SetupFormDrag()
        {
            bool drag = false; Point lp = default;
            titleBar.MouseDown += (_, e) => { drag = true; lp = e.Location; };
            titleBar.MouseMove += (_, e) => { if (drag) Location = new Point(Location.X + e.X - lp.X, Location.Y + e.Y - lp.Y); };
            titleBar.MouseUp   += (_, _) => drag = false;
        }

        private void BtnMin_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void BtnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.Show();
            login.FormClosed += (_, _) => Application.Exit();
        }

        private void BtnNav_Click(object sender, EventArgs e)
        {
            if (sender is not Guna.UI2.WinForms.Guna2Button btn) return;

            var navButtons = new[] { btnChamCong, btnNghiPhep, btnLuong, btnHopDong, btnThongTin, btnGopY };
            foreach (var b in navButtons)
            {
                b.Checked = false;
            }
            btn.Checked = true;
            if      (btn == btnChamCong) LoadPage(new EmpChamCongPage(), "Chấm công");
            else if (btn == btnNghiPhep) LoadPage(new EmpNghiPhepPage(), "Đơn nghỉ phép");
            else if (btn == btnLuong)    LoadPage(new EmpLuongPage(),    "Lương của tôi");
            else if (btn == btnHopDong)  LoadPage(new EmpHopDongPage(),  "Hợp đồng của tôi");
            else if (btn == btnThongTin) LoadPage(new EmpThongTinCaNhanPage(), "Thông tin cá nhân");
            else if (btn == btnGopY)     LoadPage(new EmpGopYPage(),     "Góp ý / Yêu cầu");
        }

        public void LoadPage(UserControl page, string title)
        {
            _currentPage?.Dispose();
            contentArea.Controls.Clear();
            _currentPage = page;
            page.Dock = DockStyle.Fill;
            page.BackColor = Color.Transparent;
            contentArea.Controls.Add(page);
        }
    }
}

