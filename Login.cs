using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTinHoc
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát?",
                                                        "Xác nhận thoát",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

           
            if (dialogResult == DialogResult.Yes)
            {
               
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string defaultUsername = "1";
            string defaultPassword = "1";

            string inputUsername = txtUsername.Text.Trim();
            string inputPassword = txtPassword.Text.Trim();
            string inputMaNhanVien = txtMaNhanVien.Text.Trim();
            string inputPassNhanVien = txtPassNhanVien.Text.Trim();

            string danhSachNhanVienFilePath = @"D:\DoAnTinHoc\DoAnTinHoc\DanhSachNhanVien.txt";
            string lichSuDangNhapFilePath = @"D:\DoAnTinHoc\DoAnTinHoc\LichSuDangNhap.txt";

           
            if (inputUsername != defaultUsername || inputPassword != defaultPassword)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (!File.Exists(danhSachNhanVienFilePath))
            {
                MessageBox.Show("File danh sách nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            bool isValidEmployee = false;
            string[] lines = File.ReadAllLines(danhSachNhanVienFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string maNhanVien = parts[0].Trim();
                    string passNhanVien = parts[1].Trim();

                    if (maNhanVien == inputMaNhanVien && passNhanVien == inputPassNhanVien)
                    {
                        isValidEmployee = true;

                       
                        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string loginInfo = $"Mã Nhân Viên:  {maNhanVien} Đăng Nhập Vào Lúc: {currentTime}";

                        File.AppendAllText(lichSuDangNhapFilePath, loginInfo + Environment.NewLine);
                        break;
                    }
                }
            }

            if (isValidEmployee)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                frmHome home = new frmHome();
                this.Hide();  
                home.ShowDialog();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Bạn không có QUYỀN TRUY CẬP!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.facebook.com/nguyenhoangluc.user")
            {
                UseShellExecute = true
            });
        }
    

      
    }
}
