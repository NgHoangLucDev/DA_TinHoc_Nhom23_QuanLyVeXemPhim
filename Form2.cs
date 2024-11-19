using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DoAnTinHoc
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnTimVe_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\KhachHang.txt";
            string sdtCanTim = txtSDT.Text;
            bool found = false;

            try
            {
                // Đọc tất cả các dòng trong file KhachHang.txt
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split('|');

                    if (fields.Length >= 7 && fields[1].Trim() == sdtCanTim)
                    {
                        // Gán thông tin vào các label
                        lblHoten2.Text = fields[0].Trim();
                        lblSDT2.Text = fields[1].Trim();
                        lblNgaydatve.Text = fields[2].Trim();
                        lblTenPhim.Text = fields[3].Trim();
                        lblThuturap.Text = fields[4].Trim();
                        lblThutughe.Text = fields[5].Trim();
                        lblTongTien.Text = fields[6].Trim();

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Không tìm thấy thông tin vé cho số điện thoại này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi đọc file: " + ex.Message);
            }
        }



        private void btnThemThongTinKH_Click(object sender, EventArgs e)
        {
         
            string hoTen = txtHoten1.Text;
            string sdt = txtSDT.Text;

           
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\KhachHangThanhVien.txt";

            if (!string.IsNullOrWhiteSpace(hoTen) && !string.IsNullOrWhiteSpace(sdt))
            {
              
                if (System.IO.File.Exists(filePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(filePath);

                 
                    bool isDuplicate = false;
                    foreach (string line in lines)
                    {
                        if (line.Contains(sdt))
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    
                    if (isDuplicate)
                    {
                        MessageBox.Show("Khách Hàng Đã Là Thành Viên!", "Thông báo");
                        return;
                    }
                }

    
                string noiDung = $"Họ tên: {hoTen}\nSĐT: {sdt}\n--------------------------\n";

               
                System.IO.File.AppendAllText(filePath, noiDung);

                
                MessageBox.Show("Thông tin khách hàng đã được thêm!", "Thông báo");
            }
            else
            {
                
                MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại!", "Thông báo");
            }
        }

        private void btnDatve_Click(object sender, EventArgs e)
        {
            frmDanhsachphim form3 = new frmDanhsachphim();
            form3.Show(); 
        }

        public string HoTenKhachHang
        {
            get { return txtHoten1.Text; }
        }

        public string SDTKhachHang
        {
            get { return txtSDT.Text; }
        }
    }
}
  