using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc
{
    internal class ThongTinPhim
    {
        public DateTime NgayChieu { get; set; }
        public string TenPhim { get; set; }
        public string SoRap { get; set; }

        public ThongTinPhim()
        {
        }

        public ThongTinPhim(DateTime ngayChieu, string tenPhim, string soRap)
        {
            NgayChieu = ngayChieu;
            TenPhim = tenPhim;
            SoRap = soRap;
        }


    }
}
