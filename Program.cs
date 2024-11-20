using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTinHoc
{
    internal static class Program
    {

        /// <summary>
        /// Điểm bắt đầu của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Hiển thị frmLogin đầu tiên
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK) // Nếu frmLogin trả về OK
            {
                Application.Run(new frmHome()); // Chạy frmHome
            }
        }
    }
}
