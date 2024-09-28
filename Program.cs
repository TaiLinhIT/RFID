using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHF_RFID_READER.Resources;
using UHF_RFID_READER.Views;

namespace UHF_RFID_READER
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (IsAdmin())
                {
                    // Ứng dụng được chạy với quyền admin
                    Application.Run(new fMain());
                }
                else
                {
                    // Yêu cầu quyền admin và khởi động lại ứng dụng
                    RequestAdminPrivileges();
                }
            } catch (Exception ex)
            {
                Helper.WriteLogError($"Errors running App: {ex.Message} / {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", "Running Error");
            }

        }

        static bool IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void RequestAdminPrivileges()
        {
            // Khởi tạo quyền admin bằng cách chạy lại ứng dụng với quyền admin
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas"; // Chạy với quyền admin

            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // Người dùng từ chối cấp quyền admin
                //MessageBox.Show("Please 'Run as Administrator' to Open App.");
            }

            Application.Exit(); // Kết thúc ứng dụng hiện tại
        }
    }
}
