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
using System.Net.NetworkInformation;



namespace DoAnTinHoc
{

    public partial class frmDanhsachphim : Form
    {
        //-------------------------------------------------//
        private frmHome frmhomeInstance;

        public frmDanhsachphim(frmHome frmhome)
        {
            InitializeComponent();
            // -----------------------------------------------------------------//
            frmhomeInstance = frmhome;
            cmbTheLoaiPhim = new ComboBox { Dock = DockStyle.Top };
            cmbTheLoaiPhim.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTheLoaiPhim.AutoCompleteSource = AutoCompleteSource.ListItems;
            lstDanhSachPhim = new ListBox { Dock = DockStyle.Fill };
            txtSearch.TextChanged += txtSearch_TextChanged ;
            this.Controls.Add(lstDanhSachPhim);
            this.Controls.Add(txtSearch);
            this.Controls.Add(cmbTheLoaiPhim);


        }
        //-----------------------------------------------//
        Dictionary<string, List<string>> danhSachPhim = new Dictionary<string, List<string>>()

{
    { "Kinh dị", new List<string> { "Mười", "Insidious", "Ngôi Nhà Trong Hẻm", "Vong Nhi" } },
    { "Tình yêu", new List<string> { "Thương Mến", "La La Land", "Trước Ngày Em Đến", "Titanic" } },
    { "Hoạt hình", new List<string> { "The Lion King - Vua Sư Tử", "Zootopia - Phi Vụ Động Trời", "Big Hero 6 - Biệt Đội Big Hero 6", "Rumble - Quái Thú So Chiêu" } },
    { "Hài", new List<string> { "Lật Mặt 6: Tấm Vé Định Mệnh", "Con Nhót Mót Chồng ", "Siêu Lừa Gặp Siêu Lầy", "Biệt Đội Rất Ổn" } },
    { "Hành động", new List<string> { "Godzilla x Kong: Đế chế mới", "The Beekeeper - Mật vụ ong", "The Roundup Punishment - Vây hãm: Kẻ trừng phạt", "Hành Tinh Khỉ: Vương Quốc Mới" } },
    { "Khoa học viễn tưởng", new List<string> { "The Hunger Games", "Guardians of the Galaxy Vol. 3", "Transformers: Rise of the Beasts", "Spaceman" } }

};
        Dictionary<string, string> duongDanAnhPhim = new Dictionary<string, string>()
{
    { "Mười", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\PhimMuoi.jpg" },
    { "Insidious", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Insidious.jpg" },
    { "Ngôi Nhà Trong Hẻm", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\ngôi nhà trong hẻm.jpg" },
    { "Vong Nhi", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\vong-nhi-poster.jpg" },
    { "Thương Mến", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Thương Mến.png" },
    { "La La Land", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\La La Land.jpg" },
    { "Trước Ngày Em Đến", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Trước Ngày Em Đến.png" },
    { "Titanic", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Titanic.jpg" },
    { "The Lion King - Vua Sư Tử", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\The Lion King - Vua Sư Tử.jpg" },
    { "Zootopia - Phi Vụ Động Trời", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Zootopia - Phi Vụ Động Trời.png" },
    { "Big Hero 6 - Biệt Đội Big Hero 6", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Big Hero 6 - Biệt Đội Big Hero 6.jpg" },
    { "Rumble - Quái Thú So Chiêu", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Rumble - Quái Thú So Chiêu.jpg" },
    { "Lật Mặt 6: Tấm Vé Định Mệnh", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Lật Mặt 6_Tấm Vé Định Mệnh.jpg" },
    { "Con Nhót Mót Chồng", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\con-nhot-mot-chong.jpg" },
    { "Siêu Lừa Gặp Siêu Lầy", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Siêu Lừa Gặp Siêu Lầy.jpg" },
    { "Biệt Đội Rất Ổn", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Biệt Đội Rất Ổn.jpg" },
    { "Godzilla x Kong: Đế chế mới", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Godzilla x Kong_ Đế chế mới.jpg" },
    { "The Beekeeper - Mật vụ ong", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\The Beekeeper - Mật vụ ong.jpg" },
    { "The Roundup Punishment - Vây hãm: Kẻ trừng phạt", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\The Roundup Punishment - Vây hãm_ Kẻ trừng phạt.jpg" },
    { "Hành Tinh Khỉ: Vương Quốc Mới", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Hành Tinh Khỉ_ Vương Quốc Mới.jpg" },
    { "The Hunger Games", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\The Hunger Games.jpg" },
    { "Guardians of the Galaxy Vol. 3", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Guardians of the Galaxy Vol. 3.jpg" },
    { "Transformers: Rise of the Beasts", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Transformers_ Rise of the Beasts.jpg" },
    { "Spaceman", @"D:\DoAnTinHoc\DoAnTinHoc\HinhAnhPhim\Spaceman.jpg" },

        };

        Dictionary<string, (string gioChieu, string rapChieu)> danhSachThongTinPhim = new Dictionary<string, (string, string)>();


        public frmDanhsachphim()
        {

            InitializeComponent();
            cmbTheLoaiPhim.Items.AddRange(danhSachPhim.Keys.ToArray());
    
            lstDanhSachPhim.Items.AddRange(duongDanAnhPhim.Keys.ToArray());
            
            cmbTheLoaiPhim.SelectedIndexChanged += cmbTheLoaiPhim_SelectedIndexChanged;






            cmbTheLoaiPhim.Items.Add("Kinh dị");
            cmbTheLoaiPhim.Items.Add("Tình yêu");
            cmbTheLoaiPhim.Items.Add("Hoạt hình");
            cmbTheLoaiPhim.Items.Add("Hài");
            cmbTheLoaiPhim.Items.Add("Hành động");
            cmbTheLoaiPhim.Items.Add("Khoa học viễn tưởng");




        }
       

        private void lstDanhSachPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDanhSachPhim.SelectedItem != null)
            {
                string tenPhim = lstDanhSachPhim.SelectedItem.ToString();

             
                if (duongDanAnhPhim.ContainsKey(tenPhim))
                {
                    string duongDanHinhAnh = duongDanAnhPhim[tenPhim];

                    try
                    {
                       
                        picPhim.Image = Image.FromFile(duongDanHinhAnh);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    picPhim.Image = null; 
                }
               
                lblThongTinFilm.Text = tenPhim + "\n" + "Được chiếu tại GALAXY CINEMA "+ "\n "+ DateTime.Now.Date+" "+ DateTime.Now.Month+ " " + DateTime.Now.Year;
            }
        }



        private void btnDatghe_Click(object sender, EventArgs e)
        {
           

            
            frmDatghe form4 = new frmDatghe();
            form4.Show();
        }

        private void cmbTheLoaiPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = cmbTheLoaiPhim.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedGenre)) return;

         
            string searchTerm = txtSearch.Text.ToLower();
            if (danhSachPhim.TryGetValue(selectedGenre, out List<string> movies))
            {
                var filteredMovies = movies
                    .Where(movie => movie.ToLower().Contains(searchTerm))
                    .ToArray();

                lstDanhSachPhim.Items.Clear();
                lstDanhSachPhim.Items.AddRange(filteredMovies);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

         
            lstDanhSachPhim.Items.Clear();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
           
                return;
            }

           
            foreach (var category in danhSachPhim)
            {
                
                foreach (var movie in category.Value)
                {
                   
                    if (movie.ToLower().Contains(searchTerm))
                    {
                        lstDanhSachPhim.Items.Add(movie);
                    }
                }
            }
        }
    }
}