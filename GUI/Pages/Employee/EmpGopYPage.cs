using VietLandHR.DTOs;
using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpGopYPage : UserControl
    {
        private readonly FeedbackBLL _service = new();

        public EmpGopYPage()
        {
            InitializeComponent();
            UIHelper.ApplyDarkBackground(this);
            UIHelper.ApplyDarkTheme(grid);
            grid.CellDoubleClick += Grid_CellDoubleClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadDataAsync();
            }
        }

        private async void BtnGui_Click(object? sender, EventArgs e)
        {
            var tk = SessionManager.CurrentAccount;
            if (tk == null || tk.EmployeeId == null) return;

            try
            {
                var res = await _service.CreateAsync(tk.EmployeeId.Value, txtTieuDe.Text.Trim(), txtNoiDung.Text.Trim());
                if (res.Success)
                {
                    MessageBox.Show("Gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTieuDe.Text = "";
                    txtNoiDung.Text = "";
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show(res.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDataAsync()
        {
            var tk = SessionManager.CurrentAccount;
            if (tk == null || tk.EmployeeId == null) return;

            try
            {
                var list = await _service.GetByEmployeeIdAsync(tk.EmployeeId.Value);
                grid.DataSource = list.Select(g => new
                {
                    FeedbackId   = g.FeedbackCode,
                    NgayGui      = FormatDateTime(g.SubmitDate),
                    TieuDe       = g.Title,
                    NoiDung      = g.Content,
                    TrangThai    = g.Status == "Submitted" ? "Pending" : g.Status,
                    PhanHoi      = g.ReplyContent ?? "—",
                    NguoiPhanHoi = g.RepliedBy.HasValue ? "Admin" : "—",
                    NgayPhanHoi  = FormatDateTime(g.RepliedAt)
                }).ToList();

                if (grid.Columns["FeedbackId"] != null) grid.Columns["FeedbackId"].HeaderText = "Mã Góp Ý";
                if (grid.Columns["NgayGui"] != null) grid.Columns["NgayGui"].HeaderText = "Ngày gửi";
                if (grid.Columns["TieuDe"] != null) grid.Columns["TieuDe"].HeaderText = "Tiêu đề";
                if (grid.Columns["NoiDung"] != null) grid.Columns["NoiDung"].HeaderText = "Nội dung";
                if (grid.Columns["TrangThai"] != null) grid.Columns["TrangThai"].HeaderText = "Trạng thái";
                if (grid.Columns["PhanHoi"] != null) grid.Columns["PhanHoi"].HeaderText = "Phản hồi";
                if (grid.Columns["NguoiPhanHoi"] != null) grid.Columns["NguoiPhanHoi"].HeaderText = "Người phản hồi";
                if (grid.Columns["NgayPhanHoi"] != null) grid.Columns["NgayPhanHoi"].HeaderText = "Ngày phản hồi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var reply = grid.Rows[e.RowIndex].Cells["PhanHoi"].Value?.ToString();
            var status = grid.Rows[e.RowIndex].Cells["TrangThai"].Value?.ToString();
            
            if (status == "Đã phản hồi")
            {
                MessageBox.Show(reply ?? "Không có nội dung.", "Phản hồi từ Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static string FormatDateTime(DateTime? dt)
        {
            if (!dt.HasValue || dt.Value == DateTime.MinValue) return "—";
            DateTime d = dt.Value;
            DateTime local = d.Kind == DateTimeKind.Utc ? d.ToLocalTime() : d;

            if (local.Hour >= 19 && local.Hour <= 23)
            {
                local = local.AddHours(-7);
            }

            return local.ToString("dd/MM/yyyy HH:mm");
        }
    }
}

