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
using Net.Codecrete.QrCodeGenerator;


namespace DoAnTinHoc
{
    public partial class frmHome : Form
    {
        
        public frmHome()
        {
            InitializeComponent();
        }
        public void SetThongTin(string hoTen, string sdt)
        {
            txtHoten1.Text = hoTen;
            txtSDT.Text = sdt;
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
                        lblHoten2.Text = fields[0].Trim();
                        lblSDT2.Text = fields[1].Trim();
                        lblNgaydatve.Text = fields[2].Trim();
                        lblTenPhim.Text = fields[3].Trim();
                        lblThuturap.Text = fields[4].Trim();
                        lblThutughe.Text = fields[5].Trim();
                        lblTongTien.Text = fields[6].Trim();          
                        DateTime ngayDatVe = DateTime.Parse(fields[2].Trim());
                        ThongTinVe ve = new ThongTinVe(
                            fields[0].Trim(), 
                            fields[1].Trim(), 
                            ngayDatVe,        
                            fields[3].Trim(), 
                            fields[4].Trim(), 
                            fields[5].Trim() 
                        );
                        List<ThongTinVe> veList = new List<ThongTinVe>();
                        veList.Add(ve);

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
            string hoTen = txtHoten1.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\KhachHang.txt";

           
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để đặt vé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine();
                    writer.WriteLine($"{hoTen} | {sdt} |");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lưu thông tin vào file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            frmDanhsachphim danhSachPhim = new frmDanhsachphim(hoTen, sdt);
            danhSachPhim.Show();



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
            
            string tenKhachHang = lblHoten2.Text;
            string sdt = lblSDT2.Text;
            DateTime ngayDatVe = DateTime.Parse(lblNgaydatve.Text); 
            string tenPhim = lblTenPhim.Text;
            string thuTuRap = lblThuturap.Text;
            string soGhe = lblThutughe.Text;

           
            thongTinVe = new ThongTinVe(
                tenKhachHang,   
                sdt,             
                ngayDatVe,       
                tenPhim,         
                thuTuRap,        
                soGhe          
            );

            
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;
            previewDialog.ShowDialog();
        }

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {






          
            Font titleFont = new Font("Arial", 20, FontStyle.Bold);
            Font infoFont = new Font("Arial", 12, FontStyle.Regular);
            Font thankYouFont = new Font("Arial", 14, FontStyle.Italic);
            Brush brush = Brushes.Black;

            float x = 100;
            float y = 50;

       
            e.Graphics.DrawString("GALAXY CINEMA", titleFont, Brushes.DarkRed, x, y);
            y += 50;

            e.Graphics.DrawLine(Pens.Black, x, y, x + 400, y); 
            y += 10;

         
            e.Graphics.DrawString("THÔNG TIN VÉ", new Font("Arial", 16, FontStyle.Bold), brush, x, y);
            y += 40;

            e.Graphics.DrawString("Tên khách hàng: " + thongTinVe.TenKhachHang, infoFont, brush, x, y);
            y += 30;

            e.Graphics.DrawString("Số điện thoại: " + thongTinVe.Sdt, infoFont, brush, x, y);
            y += 30;

            e.Graphics.DrawString("Ngày đặt vé: " + thongTinVe.NgayDatVe.ToString("dd/MM/yyyy"), infoFont, brush, x, y);
            y += 30;

            e.Graphics.DrawString("Tên phim: " + thongTinVe.TenPhim, infoFont, brush, x, y);
            y += 30;

            e.Graphics.DrawString("Thứ tự rạp: " + thongTinVe.ThuTuRap, infoFont, brush, x, y);
            y += 30;

            e.Graphics.DrawString("Số ghế: " + thongTinVe.SoGhe, infoFont, brush, x, y);
            y += 50;

            string qrData = $"Tên KH: {thongTinVe.TenKhachHang}\nSĐT: {thongTinVe.Sdt}\nNgày: {thongTinVe.NgayDatVe:dd/MM/yyyy}\nPhim: {thongTinVe.TenPhim}\nRạp: {thongTinVe.ThuTuRap}\nGhế: {thongTinVe.SoGhe}";
            using (QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator())
            {
                QRCoder.QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCoder.QRCodeGenerator.ECCLevel.Q);
                using (QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData))
                {
                    using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                    {
                     
                        e.Graphics.DrawImage(qrCodeImage, x + 200, y - 50, 150, 150); 
                    }
                }
            }

            e.Graphics.DrawRectangle(Pens.Black, 90, 40, 420, y + 110);

            
            e.Graphics.DrawString("CẢM ƠN BẠN ĐÃ DÀNH THỜI GIAN CHO GALAXY CINEMA", thankYouFont, Brushes.DarkBlue, x, y + 180);

           



        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }
    }
}
  