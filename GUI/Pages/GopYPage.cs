using VietLandHR.BLL;
using VietLandHR.GUI.Dialogs;
using VietLandHR.GUI.Helpers;
using VietLandHR.DTOs;
using VietLandHR.Utils;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI.Pages
{
    public partial class GopYPage : UserControl
    {
        private readonly FeedbackBLL _service = new();
        
        
        
        
        private List<FeedbackDTO> _allGopY = new();

        public GopYPage() {
            InitializeComponent();
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkBackground(this);
            VietLandHR.GUI.Helpers.UIHelper.ApplyDarkTheme(grid);
            cboTrangThai.SelectedIndex = 0;
            cboTrangThai.SelectedIndexChanged += (_, _) => FilterData();
            btnExport.Click += BtnExport_Click;
            grid.CellDoubleClick += Grid_CellDoubleClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                if (cboTrangThai.SelectedIndex < 0) cboTrangThai.SelectedIndex = 0;
                _ = LoadDataAsync();
            }
        }

        

        private async Task LoadDataAsync()
        {
            try
            {
                _allGopY = await _service.GetAllAsync();
                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private void FilterData()
        {
            var filter = cboTrangThai.SelectedItem?.ToString();
            var query = _allGopY.AsEnumerable();
            if (filter != "Tất cả")
                query = query.Where(g => g.TrangThai == filter);

            grid.DataSource = query.Select(g => new
            {
                FeedbackId = g.MaGopY,
                HoTen = g.TenNhanVien,
                NgayGui = FormatDateTime(g.NgayGui),
                TieuDe = g.TieuDe,
                TrangThai = g.TrangThai == "Submitted" ? "Pending" : g.TrangThai,
                NgayPhanHoi = FormatDateTime(g.NgayPhanHoi)
            }).ToList();

            if (grid.Columns["FeedbackId"] != null) grid.Columns["FeedbackId"].HeaderText = "Mã Góp Ý";
            if (grid.Columns["HoTen"] != null) grid.Columns["HoTen"].HeaderText = "Họ và Tên";
            if (grid.Columns["NgayGui"] != null) grid.Columns["NgayGui"].HeaderText = "Ngày gửi";
            if (grid.Columns["TieuDe"] != null) grid.Columns["TieuDe"].HeaderText = "Tiêu đề";
            if (grid.Columns["TrangThai"] != null) 
            {
                grid.Columns["TrangThai"].HeaderText = "Trạng thái";
                grid.Columns["TrangThai"].MinimumWidth = 130;
                grid.Columns["TrangThai"].Width = 140;
            }
            if (grid.Columns["NgayPhanHoi"] != null) grid.Columns["NgayPhanHoi"].HeaderText = "Ngày phản hồi";
        }

        private void BtnExport_Click(object? sender, EventArgs e)
        {
            VietLandHR.Utils.ExcelExportHelper.ExportDataGridView(grid, "DanhSachGopY");
        }

        private void Grid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var maGopY = grid.Rows[e.RowIndex].Cells["FeedbackId"].Value?.ToString();
            var gy = _allGopY.FirstOrDefault(g => g.MaGopY == maGopY);
            if (gy != null)
            {
                using var dlg = new GopYDialog(gy);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadDataAsync();
                }
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



