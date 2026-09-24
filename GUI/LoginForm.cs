using VietLandHR.BLL;
using VietLandHR.DTOs;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI
{
    public partial class LoginForm : Form
    {
        private readonly EmployeeBLL _nvService = new();

        // Lưu thông tin người dùng đã đăng nhập (dùng toàn ứng dụng)
        public static AccountDTO? CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            SetupFormDrag();
        }

        private void SetupFormDrag()
        {
            // Drag to move (vì không có border)
            bool isDragging = false;
            Point lastPos = default;
            this.MouseDown += (s, e) => { isDragging = true; lastPos = e.Location; };
            this.MouseMove += (s, e) => { if (isDragging) Location = new Point(Location.X + e.X - lastPos.X, Location.Y + e.Y - lastPos.Y); };
            this.MouseUp   += (s, e) => isDragging = false;

            // Đồng thời gán drag cho leftPanel
            this.leftPanel.MouseDown += (s, e) => { isDragging = true; lastPos = e.Location; };
            this.leftPanel.MouseMove += (s, e) => { if (isDragging) Location = new Point(Location.X + e.X - lastPos.X, Location.Y + e.Y - lastPos.Y); };
            this.leftPanel.MouseUp   += (s, e) => isDragging = false;
        }

        private void LeftPanel_Paint(object sender, PaintEventArgs e)
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                leftPanel.ClientRectangle,
                Color.FromArgb(76, 46, 171),  // Tím Indigo đậm (#4A2EAB)
                Color.FromArgb(45, 76, 200),  // Xanh Cobalt (#2D4CC8)
                45f);                         // Góc chéo 45 độ mượt mà
            e.Graphics.FillRectangle(brush, leftPanel.ClientRectangle);
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (_btnLogin != null && _btnLogin.Enabled)
                {
                    BtnLogin_Click(sender, e);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            if (_btnLogin == null || _lblError == null || _txtUsername == null || _txtPassword == null) return;
            if (!_btnLogin.Enabled) return;

            _lblError.Text = "";
            string user = _txtUsername.Text.Trim();
            string pass = _txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                _lblError.Text = "⚠  Vui lòng nhập đầy đủ thông tin.";
                return;
            }

            _btnLogin.Text    = "Đang kiểm tra...";
            _btnLogin.Enabled = false;

            try
            {
                var tk = await new VietLandHR.BLL.AccountBLL().LoginAsync(user, pass);

                if (tk.Account == null)
                {
                    _lblError.Text = "⚠  Sai tên đăng nhập hoặc mật khẩu.";
                    return;
                }

                CurrentUser = tk.Account;

                Form nextForm = (tk.Role?.RoleName == "Employee")
                    ? (Form)new EmployeeDashboard()
                    : new MainDashboard();

                nextForm.Show();
                this.Hide();
                nextForm.FormClosed += (_, _) => Application.Exit();
            }
            catch (Exception ex)
            {
                _lblError.Text = $"Lỗi kết nối: {ex.Message}";
            }
            finally
            {
                _btnLogin.Text    = "ĐĂNG NHẬP";
                _btnLogin.Enabled = true;
            }
        }

        private void LblRegister_Click(object sender, EventArgs e)
        {
            var frm = new RegisterForm();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
            this.Hide();
        }

        private void LblRegister_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(129, 140, 248);
            }
        }

        private void LblRegister_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(99, 102, 241);
            }
        }
    }
}

