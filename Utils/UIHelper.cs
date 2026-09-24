using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace VietLandHR.Utils
{
    public static class UIHelper
    {
        public enum ButtonType
        {
            Primary, // Blue
            Success, // Green
            Danger,  // Red
            Warning, // Yellow/Orange
            Secondary // Gray
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            // Basic Properties
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Colors & Fonts
            dgv.GridColor = Color.FromArgb(231, 235, 240); // Light gray borders

            // Header Style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(243, 244, 246); // Tailwind gray-100
            headerStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(55, 65, 81); // Tailwind gray-700
            headerStyle.SelectionBackColor = Color.FromArgb(243, 244, 246);
            headerStyle.SelectionForeColor = Color.FromArgb(55, 65, 81);
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 45;
            dgv.EnableHeadersVisualStyles = false;

            // Row Style
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = Color.White;
            rowStyle.Font = new Font("Segoe UI", 10.5F);
            rowStyle.ForeColor = Color.FromArgb(75, 85, 99); // Tailwind gray-600
            rowStyle.SelectionBackColor = Color.FromArgb(224, 231, 255); // Tailwind indigo-100
            rowStyle.SelectionForeColor = Color.FromArgb(31, 41, 55); // Tailwind gray-800
            rowStyle.Padding = new Padding(5, 0, 5, 0);
            dgv.DefaultCellStyle = rowStyle;
            dgv.RowTemplate.Height = 45;

            // Alternating Row Style
            DataGridViewCellStyle altRowStyle = new DataGridViewCellStyle();
            altRowStyle.BackColor = Color.FromArgb(249, 250, 251); // Tailwind gray-50
            dgv.AlternatingRowsDefaultCellStyle = altRowStyle;
        }

        public static void StyleButton(Guna2Button btn, ButtonType type)
        {
            if (btn == null) return;

            btn.BorderRadius = 8;
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;

            switch (type)
            {
                case ButtonType.Primary:
                    btn.FillColor = Color.FromArgb(59, 130, 246); // Tailwind blue-500
                    btn.HoverState.FillColor = Color.FromArgb(37, 99, 235); // Tailwind blue-600
                    break;
                case ButtonType.Success:
                    btn.FillColor = Color.FromArgb(34, 197, 94); // Tailwind green-500
                    btn.HoverState.FillColor = Color.FromArgb(22, 163, 74); // Tailwind green-600
                    break;
                case ButtonType.Danger:
                    btn.FillColor = Color.FromArgb(239, 68, 68); // Tailwind red-500
                    btn.HoverState.FillColor = Color.FromArgb(220, 38, 38); // Tailwind red-600
                    break;
                case ButtonType.Warning:
                    btn.FillColor = Color.FromArgb(245, 158, 11); // Tailwind amber-500
                    btn.HoverState.FillColor = Color.FromArgb(217, 119, 6); // Tailwind amber-600
                    break;
                case ButtonType.Secondary:
                    btn.FillColor = Color.FromArgb(107, 114, 128); // Tailwind gray-500
                    btn.HoverState.FillColor = Color.FromArgb(75, 85, 99); // Tailwind gray-600
                    break;
            }
        }

        public static void StyleButton(Button btn, ButtonType type)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;

            switch (type)
            {
                case ButtonType.Primary:
                    btn.BackColor = Color.FromArgb(59, 130, 246);
                    break;
                case ButtonType.Success:
                    btn.BackColor = Color.FromArgb(34, 197, 94);
                    break;
                case ButtonType.Danger:
                    btn.BackColor = Color.FromArgb(239, 68, 68);
                    break;
                case ButtonType.Warning:
                    btn.BackColor = Color.FromArgb(245, 158, 11);
                    break;
                case ButtonType.Secondary:
                    btn.BackColor = Color.FromArgb(107, 114, 128);
                    break;
            }
        }

        public static TableLayoutPanel CreateTableLayout(Control[][] rows, bool fillWidth = true)
        {
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp.RowCount = rows.Length;
            
            int maxCols = 0;
            foreach(var row in rows)
            {
                if (row.Length > maxCols) maxCols = row.Length;
            }
            tlp.ColumnCount = maxCols;

            for (int i = 0; i < maxCols; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / maxCols));
            }
            for (int i = 0; i < rows.Length; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                for (int j = 0; j < rows[i].Length; j++)
                {
                    var ctrl = rows[i][j];
                    if (ctrl != null)
                    {
                        ctrl.Anchor = fillWidth ? (AnchorStyles.Left | AnchorStyles.Right) : AnchorStyles.None;
                        ctrl.Margin = new Padding(10, 10, 10, 10);
                        tlp.Controls.Add(ctrl, j, i);
                    }
                }
            }
            return tlp;
        }
    }
}

