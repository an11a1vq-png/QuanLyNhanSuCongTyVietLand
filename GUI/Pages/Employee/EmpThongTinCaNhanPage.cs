using VietLandHR.DTOs;
using VietLandHR.BLL;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.GUI.Pages.Employee
{
    public partial class EmpThongTinCaNhanPage : UserControl
    {
        private readonly EmployeeBLL _repoNV = new();
        private readonly DepartmentBLL _repoPB = new();
        private readonly PositionBLL _repoCV = new();

        public EmpThongTinCaNhanPage()
        {
            InitializeComponent();
            UIHelper.ApplyDarkBackground(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                _ = LoadDataAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            var tk = SessionManager.CurrentAccount;
            if (tk == null || !tk.EmployeeId.HasValue) return;

            var nv = await _repoNV.GetByIdAsync(tk.EmployeeId.Value);
            if (nv == null) return;

            lblMaNVVal.Text = string.IsNullOrEmpty(nv.EmployeeCode) ? "—" : nv.EmployeeCode;
            lblHoTenVal.Text = string.IsNullOrEmpty(nv.FullName) ? "—" : nv.FullName;
            lblGioiTinhVal.Text = string.IsNullOrEmpty(nv.Gender) ? "—" : nv.Gender;
            lblNgaySinhVal.Text = nv.BirthDate?.ToString("dd/MM/yyyy") ?? "—";
            lblCCCDVal.Text = string.IsNullOrEmpty(nv.CitizenId) ? "—" : nv.CitizenId;
            lblSDTVal.Text = string.IsNullOrEmpty(nv.Phone) ? "—" : nv.Phone;
            lblEmailVal.Text = string.IsNullOrEmpty(nv.Email) ? "—" : nv.Email;
            lblDiaChiVal.Text = string.IsNullOrEmpty(nv.Address) ? "—" : nv.Address;

            if (nv.DepartmentId.HasValue)
            {
                var pb = await _repoPB.GetByIdAsync(nv.DepartmentId.Value);
                lblPhongBanVal.Text = pb?.DepartmentName ?? nv.DepartmentId.ToString()!;
            }
            else
            {
                lblPhongBanVal.Text = "—";
            }

            decimal displaySalary = nv.BaseSalary;
            if (nv.PositionId.HasValue)
            {
                var pos = await _repoCV.GetByIdAsync(nv.PositionId.Value);
                lblChucVuVal.Text = pos?.PositionName ?? nv.PositionId.ToString()!;
                if (displaySalary == 0 && pos != null && pos.BaseSalary > 0)
                {
                    displaySalary = pos.BaseSalary;
                }
            }
            else
            {
                lblChucVuVal.Text = "—";
            }

            lblNgayVaoLamVal.Text = nv.HireDate.ToString("dd/MM/yyyy");
            lblLuongCoBanVal.Text = displaySalary > 0 ? $"{displaySalary:N0} ₫" : "0 ₫";
            lblTrangThaiVal.Text = string.IsNullOrEmpty(nv.Status) ? "Active" : nv.Status;
        }

        private void BtnDoiPass_Click(object? sender, EventArgs e)
        {
            using var dlg = new VietLandHR.GUI.Dialogs.DoiMatKhauDialog();
            dlg.ShowDialog();
        }
    }
}

