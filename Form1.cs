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
            string username = txtUsername.Text; 
            string password = txtPassword.Text;
            string tenNhanVien = txtTenNhanVien.Text;
            string thoiGianDangNhap = dtpNow.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\LichSuDangNhap.txt";
            try
            {
                // Ghi thông tin vào file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{tenNhanVien} - {thoiGianDangNhap}");
                }
                MessageBox.Show($"Chào Mừng {tenNhanVien} đến với trình quản lý vé xem phim.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu lịch sử đăng nhập: " + ex.Message);
            }
            if (username == "1" && password == "1")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
               
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
            }
            else
            {
                
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.facebook.com/nguyenhoangluc.user")
            {
                UseShellExecute = true
            });
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                btnLogin_Click(sender, e);
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        private void txtTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
