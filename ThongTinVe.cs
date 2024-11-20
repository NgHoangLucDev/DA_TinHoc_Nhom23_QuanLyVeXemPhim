using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc
{
    internal class ThongTinVe
    {
        public string TenKhachHang { get; set; }
        public string Sdt { get; set; }
        public DateTime NgayDatVe { get; set; }
        public string TenPhim { get; set; }
        public string ThuTuRap { get; set; }
        public string SoGhe { get; set; }

   
        public ThongTinVe(string tenKhachHang, string sdt, DateTime ngayDatVe, string tenPhim, string thuTuRap, string soGhe)
        {
            TenKhachHang = tenKhachHang;
            Sdt = sdt;
            NgayDatVe = ngayDatVe;
            TenPhim = tenPhim;
            ThuTuRap = thuTuRap;
            SoGhe = soGhe;
        }
    }
}
