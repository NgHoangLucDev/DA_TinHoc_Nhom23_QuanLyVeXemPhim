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
          
            string danhSachNhanVienFilePath = @"D:\DoAnTinHoc\DoAnTinHoc\DanhSachNhanVien.txt";

          
            string lichSuDangNhapFilePath = @"D:\DoAnTinHoc\DoAnTinHoc\LichSuDangNhap.txt";

            string inputMaNhanVien = txtMaNhanVien.Text.Trim();
            string inputPassNhanVien = txtPassNhanVien.Text.Trim();

            
            if (string.IsNullOrEmpty(inputMaNhanVien) || string.IsNullOrEmpty(inputPassNhanVien))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            if (inputPassNhanVien.Length < 8)
            {
                MessageBox.Show("Mật khẩu có ít nhất 8 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
           
                if (File.Exists(danhSachNhanVienFilePath))
                {
                    string[] lines = File.ReadAllLines(danhSachNhanVienFilePath);
                    bool isValidEmployee = false;

                    foreach (string line in lines)
                    {
                        
                        string[] parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            string maNhanVien = parts[0].Trim();
                            string passNhanVien = parts[1].Trim();

                            if (maNhanVien == inputMaNhanVien && passNhanVien == inputPassNhanVien)
                            {
                                isValidEmployee = true;

                               
                                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loginInfo = $"{maNhanVien} Đăng Nhập Vào Lúc: {currentTime}";
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
                    }
                    else
                    {
                        MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File danh sách nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtPassNhanVien.PasswordChar = '*';


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
