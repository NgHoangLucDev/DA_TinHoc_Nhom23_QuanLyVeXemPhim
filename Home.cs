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
using System.Drawing.Printing;

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

                        // Lưu thông tin vào đối tượng ThongTinVe
                        DateTime ngayDatVe = DateTime.Parse(fields[2].Trim());
                        ThongTinVe ve = new ThongTinVe(
                            fields[0].Trim(), // TenKhachHang
                            fields[1].Trim(), // Sdt
                            ngayDatVe,        // NgayDatVe
                            fields[3].Trim(), // TenPhim
                            fields[4].Trim(), // ThuTuRap
                            fields[5].Trim()  // SoGhe
                        );


                        List<ThongTinVe> veList = new List<ThongTinVe>();
                        veList.Add(ve);

                        found = true;
                        break;
                    }
                }

                // Nếu không tìm thấy vé
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
     
            frmDanhsachphim danhSachPhimForm = new frmDanhsachphim();
            danhSachPhimForm.Show();

        



        }

     

        private void btnLogout_Click(object sender, EventArgs e)
        {

           

     
            DateTime currentDateTime = DateTime.Now;
            string timeLogout = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

          
            string logEntry = $"-------------- Thời gian đăng xuất: {timeLogout}\n";

           
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\LichSuDangNhap.txt";

          
            try
            {
                File.AppendAllText(filePath, logEntry);  
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi vào file: {ex.Message}");
            }

           
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                        "Xác nhận đăng xuất",
                                                        MessageBoxButtons.YesNo,


                                                        MessageBoxIcon.Warning);

            if(dialogResult == DialogResult.Yes)
            MessageBox.Show("Đăng xuất thành công!");

            if (dialogResult == DialogResult.Yes)
            {
               
                this.Close();

              
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
        }
        ThongTinVe thongTinVe;
        private void btnInVe_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các Label
            string tenKhachHang = lblHoten2.Text;
            string sdt = lblSDT2.Text;
            DateTime ngayDatVe = DateTime.Parse(lblNgaydatve.Text);  // Chuyển đổi từ Text sang DateTime
            string tenPhim = lblTenPhim.Text;
            string thuTuRap = lblThuturap.Text;
            string soGhe = lblThutughe.Text;

            // Tạo đối tượng ThongTinVe với thông tin lấy từ các Label
            thongTinVe = new ThongTinVe(
                tenKhachHang,    // TenKhachHang
                sdt,             // Sdt
                ngayDatVe,       // NgayDatVe
                tenPhim,         // TenPhim
                thuTuRap,        // ThuTuRap
                soGhe            // SoGhe
            );

            // Gọi hàm in
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;
            previewDialog.ShowDialog();
        }

        // Sự kiện PrintPage để định dạng nội dung in
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Tạo font và brush
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            // Vẽ nội dung thông tin vé lên trang in
            float x = 100;
            float y = 100;

            e.Graphics.DrawString("Thông Tin Vé", new Font("Arial", 16), Brushes.Black, x, y);
            y += 30;

            e.Graphics.DrawString("Tên khách hàng: " + thongTinVe.TenKhachHang, font, brush, x, y);
            y += 25;

            e.Graphics.DrawString("Số điện thoại: " + thongTinVe.Sdt, font, brush, x, y);
            y += 25;

            e.Graphics.DrawString("Ngày đặt vé: " + thongTinVe.NgayDatVe.ToString("dd/MM/yyyy"), font, brush, x, y);
            y += 25;

            e.Graphics.DrawString("Tên phim: " + thongTinVe.TenPhim, font, brush, x, y);
            y += 25;

            e.Graphics.DrawString("Thứ tự rạp: " + thongTinVe.ThuTuRap, font, brush, x, y);
            y += 25;

            e.Graphics.DrawString("Số ghế: " + thongTinVe.SoGhe, font, brush, x, y);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }
    }
}
  