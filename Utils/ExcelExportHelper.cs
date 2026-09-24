using System;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Reflection;

namespace VietLandHR.Utils
{
    public static class ExcelExportHelper
    {
        public static void ExportDataGridView(DataGridView dgv, string defaultFileName = "Export", string worksheetName = "Data")
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Lưu file Excel"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(worksheetName);

                        // Ghi Header
                        int colIndex = 1;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                worksheet.Cell(1, colIndex).Value = dgv.Columns[i].HeaderText;
                                // Định dạng header
                                var headerCell = worksheet.Cell(1, colIndex);
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Fill.BackgroundColor = XLColor.FromArgb(14, 116, 144);
                                headerCell.Style.Font.FontColor = XLColor.White;
                                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                colIndex++;
                            }
                        }

                        // Ghi Data
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            colIndex = 1;
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                if (dgv.Columns[j].Visible)
                                {
                                    var val = dgv.Rows[i].Cells[j].Value;
                                    worksheet.Cell(i + 2, colIndex).Value = val != null ? val.ToString() : "";
                                    worksheet.Cell(i + 2, colIndex).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                    colIndex++;
                                }
                            }
                        }

                        // AutoFit columns
                        worksheet.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }

                    var res = MessageBox.Show($"Xuất Excel thành công!\nBạn có muốn mở file ngay không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ExportList<T>(IEnumerable<T> dataList, string defaultFileName = "Export", string worksheetName = "Data")
        {
            using SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Lưu file Excel"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(worksheetName);
                        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                        // Headers
                        for (int i = 0; i < properties.Length; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = properties[i].Name;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.FromArgb(14, 116, 144);
                            worksheet.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
                            worksheet.Cell(1, i + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }

                        // Rows
                        int row = 2;
                        foreach (var item in dataList)
                        {
                            for (int i = 0; i < properties.Length; i++)
                            {
                                var val = properties[i].GetValue(item);
                                worksheet.Cell(row, i + 1).Value = val != null ? val.ToString() : "";
                                worksheet.Cell(row, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            }
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    var res = MessageBox.Show($"Xuất Excel thành công!\nBạn có muốn mở file ngay không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

