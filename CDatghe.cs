using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc
{
    internal class CDatghe
    {
        public string SoGheDaNhap { get; set; }
        public string ThanhTien { get; set; }
        public CDatghe() { }
        public CDatghe(string soGheDaNhap, string thanhTien)
        {
            SoGheDaNhap = soGheDaNhap;
            ThanhTien = thanhTien;
        }
    }
}
