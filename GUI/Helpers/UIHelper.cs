using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace VietLandHR.GUI.Helpers
{
    public static class UIHelper
    {
        // ─── Màu Light Pastel Theme (Phân tích chuẩn 100% theo Ảnh) ────────
        public static readonly Color LightBg       = Color.FromArgb(197, 210, 246);  // #C5D2F6 / Tím Xanh Lavender Periwinkle
        public static readonly Color LightPanel    = Color.FromArgb(245, 248, 255);  // #F5F8FF / Trắng mờ Glassmorphism
        public static readonly Color LightBorder   = Color.FromArgb(255, 255, 255);  // #FFFFFF / Viền trắng mỏng
        public static readonly Color LightText     = Color.FromArgb(15,  23,  42);   // #0F172A
        public static readonly Color LightSubText  = Color.FromArgb(71,  85,  105);  // #475569

        // Aliases cho tương thích ngược với các Dialog cũ
        public static readonly Color DarkBg        = LightBg;
        public static readonly Color DarkPanel     = LightPanel;
        public static readonly Color DarkBorder    = LightBorder;
        public static readonly Color DarkText      = LightText;
        public static readonly Color DarkSubText   = LightSubText;
        public static readonly Color AccentSelect  = Color.FromArgb(67, 56, 202);

        public static readonly Color PurpleHeader  = Color.FromArgb(59,  55, 173);  // #3B37AD Header Tím Indigo đậm
        public static readonly Color AccentBlue    = Color.FromArgb(37,  99, 235);  // #2563EB
        public static readonly Color AccentGreen   = Color.FromArgb(22, 163,  74);  // #16A34A
        public static readonly Color AccentRed     = Color.FromArgb(220, 38,  38);  // #DC2626
        public static readonly Color AccentYellow  = Color.FromArgb(217, 119,   6);  // #D97706

        // ─── Light Theme (Chuẩn theo Ảnh) ─────────────────────────────────
        public static void ApplyModernTheme(this DataGridView grid)
        {
            if (grid == null) return;

            grid.EnableHeadersVisualStyles = false;

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(241, 245, 249);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToOrderColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.RowTemplate.Height = 44;
            grid.ColumnHeadersHeight = 46;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            var font     = new Font("Segoe UI", 10F, FontStyle.Regular);
            var fontBold = new Font("Segoe UI", 10F, FontStyle.Bold);

            var headerStyle = new DataGridViewCellStyle
            {
                Alignment            = DataGridViewContentAlignment.MiddleLeft,
                BackColor            = Color.FromArgb(67, 56, 202), // Tím xanh như ảnh mẫu
                ForeColor            = Color.White,
                Font                 = fontBold,
                SelectionBackColor   = Color.FromArgb(67, 56, 202),
                SelectionForeColor   = Color.White,
                WrapMode             = DataGridViewTriState.True
            };
            grid.ColumnHeadersDefaultCellStyle = headerStyle;

            var altStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(248, 250, 252) };
            grid.AlternatingRowsDefaultCellStyle = altStyle;

            var defaultStyle = new DataGridViewCellStyle
            {
                Alignment          = DataGridViewContentAlignment.MiddleLeft,
                BackColor          = Color.White,
                ForeColor          = Color.FromArgb(30, 41, 59),
                Font               = font,
                SelectionBackColor = Color.FromArgb(224, 231, 255),
                SelectionForeColor = Color.FromArgb(49, 46, 129),
                WrapMode           = DataGridViewTriState.False
            };
            grid.DefaultCellStyle = defaultStyle;

            if (grid is Guna2DataGridView gunaGrid)
            {
                gunaGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
                gunaGrid.ThemeStyle.RowsStyle.BorderStyle   = DataGridViewCellBorderStyle.SingleHorizontal;
            }

            // Đăng ký vẽ Status Pill Badge mượt mà
            grid.CellPainting -= Grid_CellPainting;
            grid.CellPainting += Grid_CellPainting;
        }

        private static void Grid_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && sender is DataGridView dgv)
            {
                string colName = dgv.Columns[e.ColumnIndex].Name ?? "";
                string headerText = dgv.Columns[e.ColumnIndex].HeaderText ?? "";

                if (colName.IndexOf("TrangThai", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    colName.IndexOf("TrạngThái", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    headerText.IndexOf("Trạng thái", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    headerText.IndexOf("TrạngThái", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    colName.IndexOf("Status", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    string val = e.Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(val))
                    {
                        Color badgeBg = Color.FromArgb(220, 252, 231); // Xanh lá nhạt (#DCFCE7)
                        Color badgeFg = Color.FromArgb(22, 163, 74);   // Xanh lá đậm (#16A34A)

                        if (val.Equals("Pending", StringComparison.OrdinalIgnoreCase) || val.Contains("Chờ"))
                        {
                            badgeBg = Color.FromArgb(254, 243, 199); // Vàng nhạt (#FEF3C7)
                            badgeFg = Color.FromArgb(217, 119, 6);   // Cam đậm (#D97706)
                        }
                        else if (val.Equals("Inactive", StringComparison.OrdinalIgnoreCase) || 
                                 val.Equals("Not Active", StringComparison.OrdinalIgnoreCase) || 
                                 val.Equals("Rejected", StringComparison.OrdinalIgnoreCase) || 
                                 val.Contains("Khóa") || val.Contains("Hủy") || val.Contains("Nghỉ"))
                        {
                            badgeBg = Color.FromArgb(254, 226, 226); // Đỏ nhạt (#FEE2E2)
                            badgeFg = Color.FromArgb(220, 38, 38);   // Đỏ đậm (#DC2626)
                        }

                        using var bgBrush = new SolidBrush(badgeBg);
                        using var fgBrush = new SolidBrush(badgeFg);
                        using var font = new Font("Segoe UI", 8.5F, FontStyle.Bold);

                        if (e.Graphics == null) return;
                        SizeF textSize = e.Graphics.MeasureString(val, font);
                        int badgeWidth = Math.Min((int)textSize.Width + 20, Math.Max(70, e.CellBounds.Width - 10));
                        int badgeHeight = 26;
                        int x = e.CellBounds.X + (e.CellBounds.Width - badgeWidth) / 2;
                        int y = e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2;

                        var rect = new Rectangle(x, y, badgeWidth, badgeHeight);

                        // Draw rounded pill
                        using (var path = GetRoundedPath(rect, 13))
                        {
                            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            e.Graphics.FillPath(bgBrush, path);
                        }

                        // Text alignment center with no wrapping
                        var sf = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center,
                            FormatFlags = StringFormatFlags.NoWrap,
                            Trimming = StringTrimming.EllipsisCharacter
                        };
                        e.Graphics.DrawString(val, font, fgBrush, rect, sf);
                    }
                    e.Handled = true;
                }
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ─── Dark Theme ────────────────────────────────────────────────────
        public static void ApplyDarkTheme(this DataGridView grid)
        {
            ApplyModernTheme(grid); // Áp dụng đồng bộ Light Modern Theme chuẩn theo Ảnh
        }

        /// <summary>Tô màu tối cho Control (UserControl, Panel, ...)</summary>
        public static void ApplyDarkBackground(this Control control)
        {
            ApplyLightBackground(control); // Chuyển đồng bộ sang Light Background
        }

        /// <summary>Tô màu sáng cho Control (UserControl, Panel, ...) chuẩn Pastel Glassmorphism</summary>
        public static void ApplyLightBackground(this Control control)
        {
            control.BackColor = LightBg;
            control.ForeColor = LightText;
        }

        /// <summary>Tô màu tối cho TextBox của Guna.</summary>
        public static void ApplyDark(this Guna2TextBox txt)
        {
            txt.FillColor            = DarkPanel;
            txt.BorderColor          = DarkBorder;
            txt.ForeColor            = DarkText;
            txt.PlaceholderForeColor = DarkSubText;
        }

        /// <summary>Tô màu tối cho ComboBox của Guna.</summary>
        public static void ApplyDark(this Guna2ComboBox cbo)
        {
            cbo.FillColor   = DarkPanel;
            cbo.BorderColor = DarkBorder;
            cbo.ForeColor   = DarkText;
        }

        /// <summary>Tô màu tối cho Guna2Panel.</summary>
        public static void ApplyDark(this Guna2Panel panel)
        {
            panel.FillColor = DarkPanel;
            panel.ForeColor = DarkText;
        }

        // ─── Shadow (giữ nguyên) ───────────────────────────────────────────
        public static void ApplyShadow(this Guna2Panel panel)
        {
            if (panel == null) return;
            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.Depth   = 15;
            panel.ShadowDecoration.Color   = Color.FromArgb(10, 15, 25);
            panel.ShadowDecoration.Shadow  = new Padding(0, 0, 5, 5);

            panel.FillColor = DarkPanel;
            panel.ForeColor = DarkText;
        }

        /// <summary>Hiện dialog với overlay tối phủ lên form cha.</summary>
        public static DialogResult ShowWithDimOverlay(this Form dialog, Control caller)
        {
            Form? owner = caller.FindForm();
            Form? overlay = null;
            if (owner != null)
            {
                overlay = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    BackColor       = Color.Black,
                    Opacity         = 0.45,
                    StartPosition   = FormStartPosition.Manual,
                    Bounds          = owner.Bounds,
                    ShowInTaskbar   = false,
                    Owner           = owner
                };
                overlay.Show(owner);
            }

            var result = dialog.ShowDialog(owner);

            overlay?.Close();
            overlay?.Dispose();
            return result;
        }
    }
}


