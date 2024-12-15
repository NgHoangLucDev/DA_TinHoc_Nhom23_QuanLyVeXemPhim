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
        //====================================================================//
        private List<ThongTinPhim> danhSachPhim = new List<ThongTinPhim>();
        //====================================================================//

        private string m_hoten;
        private string m_sdt;
        public frmDanhsachphim(string m_hoten, string m_sdt)
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;


        }


        private frmHome frmhomeInstance;

        public frmDanhsachphim(frmHome frmhome)
        {
            InitializeComponent();
        
           

        }
     
   


      

        Dictionary<string, (string gioChieu, string rapChieu)> danhSachThongTinPhim = new Dictionary<string, (string, string)>();


        public frmDanhsachphim()
        {

            InitializeComponent();

        }
       

        private void lstDanhSachPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }



        private void btnDatghe_Click(object sender, EventArgs e)
        {
           

            
            frmDatghe form4 = new frmDatghe();
            form4.Show();
            this.Hide();
        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

          
            if (dgvThongTinPhim.DataSource is DataTable dataTable)
            {
                
                string filterExpression = $"TenPhim LIKE '%{searchText}%'";
                dataTable.DefaultView.RowFilter = filterExpression;
            }

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frmHome ql = new frmHome();
            ql.SetThongTin(m_hoten,m_sdt);

            ql.Show();
            this.Close();
        }

        private void frmDanhsachphim_Load(object sender, EventArgs e)
        {


            string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\ThongTinPhim.txt";

            try
            {
                
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File ThongTinPhim.txt không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                string[] lines = File.ReadAllLines(filePath);

              
                dgvThongTinPhim.Rows.Clear();

                
                foreach (string line in lines)
                {
                    
                    string[] parts = line.Split('|');

                    
                    if (parts.Length == 3)
                    {
                       
                        DateTime ngayChieu = DateTime.Parse(parts[0].Trim());
                        string tenPhim = parts[1].Trim();
                        string soRap = parts[2].Trim();

                       
                        dgvThongTinPhim.Rows.Add(ngayChieu.ToString("dd/MM/yyyy"), tenPhim, soRap);
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Có lỗi xảy ra khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CapNhatDataGridView(List<ThongTinPhim> danhSach)
        {
            dgvThongTinPhim.Rows.Clear(); 
            foreach (var phim in danhSach)
            {
                dgvThongTinPhim.Rows.Add(phim.NgayChieu.ToString("dd/MM/yyyy"), phim.TenPhim, phim.SoRap);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool hasSuggestions = txtSearch.Tag != null && (bool)txtSearch.Tag;

                if (!hasSuggestions)
                {
                    MessageBox.Show("Không tìm thấy phim nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDatghe_Click_1(object sender, EventArgs e)
        {
            if (dgvThongTinPhim.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bộ phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                DataGridViewRow selectedRow = dgvThongTinPhim.SelectedRows[0];

                
                if (selectedRow.Cells["TenPhim"] == null || selectedRow.Cells["SoRap"] == null)
                {
                    MessageBox.Show("Dữ liệu không đầy đủ! Vui lòng kiểm tra lại bảng thông tin phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ngayDat = DateTime.Now.ToString("dd/MM/yyyy"); 
                string tenPhim = selectedRow.Cells["TenPhim"].Value.ToString();
                string soRap = selectedRow.Cells["SoRap"].Value.ToString();

               
                string filePath = @"D:\DoAnTinHoc\DoAnTinHoc\KhachHang.txt";

               
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File KhachHang.txt không tồn tại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

             
                List<string> lines = File.ReadAllLines(filePath).ToList();

              
                if (lines.Count > 0)
                {
                  
                    lines[lines.Count - 1] += $" {ngayDat} | {tenPhim} | {soRap} |";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng trong file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            
                File.WriteAllLines(filePath, lines);

       
                frmDatghe datGheForm = new frmDatghe();
                datGheForm.Show();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}