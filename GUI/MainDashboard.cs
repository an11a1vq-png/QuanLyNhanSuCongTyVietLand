using VietLandHR.GUI.Pages;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI
{
    public partial class MainDashboard : Form
    {
        private UserControl? _currentPage;

        public MainDashboard()
        {
            InitializeComponent();
            SetupDashboard();
            SetupFormDrag();
        }

        private async void SetupDashboard()
        {
            // Set user info dựa theo role
            string roleTitle = SessionManager.CurrentRoleName ?? "—";
            if (SessionManager.IsManager)
            {
                string deptName = "";
                if (SessionManager.CurrentEmployee?.DepartmentId != null)
                {
                    try
                    {
                        var dept = await new VietLandHR.BLL.DepartmentBLL().GetByIdAsync(SessionManager.CurrentEmployee.DepartmentId.Value);
                        if (dept != null) deptName = $" ({dept.DepartmentName})";
                    }
                    catch { }
                }
                roleTitle = $"Manager - Trưởng phòng{deptName}";
            }

            _lblUserInfo.Text = $"👤  {roleTitle}  |  {LoginForm.CurrentUser?.TenDangNhap}";

            // Ẩn/hiện nút Quản lý Tài khoản theo quyền
            if (btnNavTaiKhoan != null)
            {
                btnNavTaiKhoan.Visible = SessionManager.IsAdmin;
            }

            // Chỉ Admin mới có nút Duyệt đăng ký
            if (SessionManager.IsAdmin)
            {
                AddRegistrationApprovalButton();
            }

            // Load default page
            LoadPage(new DashboardHomePage(), "Tổng quan");
        }

        private void AddRegistrationApprovalButton()
        {
            var btn = new Guna2Button();
            btn.Animated = true;
            btn.BorderRadius = 10;
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn.CheckedState.FillColor = Color.FromArgb(67, 56, 202);
            btn.CheckedState.ForeColor = Color.White;
            btn.FillColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btn.ForeColor = Color.FromArgb(51, 65, 85);
            btn.HoverState.FillColor = Color.FromArgb(241, 245, 249);
            btn.HoverState.ForeColor = Color.FromArgb(15, 23, 42);
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Size = new Size(202, 40);
            btn.Text = "📝   Duyệt đăng ký";
            btn.TextAlign = HorizontalAlignment.Left;
            btn.Margin = new Padding(3, 3, 3, 3);
            btn.Click += (s, e) => {
                LoadPage(new VietLandHR.GUI.Pages.DuyetDangKyPage(), "Duyệt yêu cầu đăng ký");
            };
            
            // Add right before the logout button or at the end of nav container
            pnlNavContainer.Controls.Add(btn);
            
            // Move logout to the bottom if it's in a flow layout, wait, logout is not in the flow layout, it's anchored.
            // Actually, just add it to pnlNavContainer which is a FlowLayoutPanel.
        }

        private void SetupFormDrag()
        {
            // Cho phép drag to move form từ title bar
            bool drag = false; Point lp = default;
            titleBar.MouseDown += (_, e) => { drag = true; lp = e.Location; };
            titleBar.MouseMove += (_, e) => { if (drag) Location = new Point(Location.X + e.X - lp.X, Location.Y + e.Y - lp.Y); };
            titleBar.MouseUp   += (_, _) => drag = false;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // Đã xử lý ở SetupFormDrag()
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.Show();
            login.FormClosed += (_, _) => Application.Exit();
        }

        private void BtnNav_Click(object sender, EventArgs e)
        {
            if (sender is not Guna2Button btn) return;

            foreach (Control c in pnlNavContainer.Controls)
            {
                if (c is Guna2Button b) b.Checked = false;
            }
            btn.Checked = true;

            if (btn == btnNavTongQuan)
                LoadPage(new DashboardHomePage(), "Tổng quan");
            else if (btn == btnNavNhanVien)
                LoadPage(new NhanVienPage(), "Quản lý Nhân viên");
            else if (btn == btnNavPhongBan)
                LoadPage(new PhongBanPage(), "Quản lý Phòng ban");
            else if (btn == btnNavChamCong)
                LoadPage(new ChamCongPage(), "Chấm công");
            else if (btn == btnNavNghiPhep)
                LoadPage(new NghiPhepPage(), "Duyệt đơn nghỉ phép");
            else if (btn == btnNavTinhLuong)
                LoadPage(new TinhLuongPage(), "Tính lương tháng");
            else if (btn == btnNavBaoCao)    LoadPage(new BaoCaoPage(),   "Báo cáo & Thống kê");
            else if (btn == btnNavHopDong)   LoadPage(new HopDongPage(),  "Hợp đồng");
            else if (btn == btnNavTaiKhoan)  LoadPage(new TaiKhoanPage(), "Tài khoản");
            else if (btn == btnNavGopY)      LoadPage(new GopYPage(),     "Quản lý Góp ý");
        }

        public void LoadPage(UserControl page, string title)
        {
            _lblPageTitle.Text = title;

            // Dispose page cũ để tiết kiệm RAM
            _currentPage?.Dispose();
            _contentArea.Controls.Clear();

            _currentPage = page;
            page.Dock = DockStyle.Fill;
            page.BackColor = Color.Transparent;
            _contentArea.Controls.Add(page);
        }
    }
}

