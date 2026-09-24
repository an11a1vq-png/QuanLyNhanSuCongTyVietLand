using System;
using System.Windows.Forms;
using VietLandHR.GUI;
using VietLandHR.Utils;   // <-- cần cho SupabaseClientManager

namespace VietLandHR
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Gọi đồng bộ vì WinForms yêu cầu luồng STA
                SupabaseClientManager.Instance.InitializeAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Application.Run(new LoginForm());
        }
    }
}
