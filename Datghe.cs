using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnTinHoc
{
    public partial class frmDatghe : Form
    {
        public string SoGheDaNhap { get; set; }
        public string ThanhTien { get; set; }
        public frmDatghe()
        {
            InitializeComponent();

        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\KhachHang.txt";
            string soGheMoi = txtSoGhe.Text.Trim();

            if (string.IsNullOrEmpty(soGheMoi))
            {
                MessageBox.Show("Vui lòng nhập số ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            string[] danhSachGhe = soGheMoi.Split(',').Select(g => g.Trim()).ToArray();
            int giaVe = 50000; 
            int tongTien = danhSachGhe.Length * giaVe;

            try
            {
               
                List<string> lines = File.ReadAllLines(filePath).ToList();
                bool gheDaDat = false;
                string ngayHienTai = DateTime.Now.ToString("dd/MM/yyyy");

               
                foreach (string line in lines)
                {
                    foreach (string ghe in danhSachGhe)
                    {
                        if (line.Contains(ngayHienTai) && line.Contains($"Ghế {ghe}"))
                        {
                            gheDaDat = true;
                            MessageBox.Show($"Ghế {ghe} đã có người đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

              
                if (lines.Count > 0)
                {
                    string dongCuoi = lines[lines.Count - 1];

                   
                    if (!dongCuoi.Contains("Ghế"))
                    {
                        dongCuoi += $" Ghế {string.Join(", ", danhSachGhe)} | {tongTien:N0}";
                    }
                    else
                    {
                        dongCuoi += $", {string.Join(", ", danhSachGhe)} | {tongTien:N0}";
                    }

                    
                    lines[lines.Count - 1] = dongCuoi;

                    File.WriteAllLines(filePath, lines);

                    
                    lblThanhtien.Text = $"{tongTien:N0} VND";

                    MessageBox.Show("Đặt ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng trong file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
             SoGheDaNhap= txtSoGhe.Text;
            ThanhTien = lblThanhtien.Text;

      
            frmDanhsachphim frmDanhSachPhim = new frmDanhsachphim();
            frmDanhSachPhim.Show();

          
        }

        private void btnKetthuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát về trang in vé không?",
                                         "Xác nhận",
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
    
                this.Close();
            }
        }
    }
    }
    
