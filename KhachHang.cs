
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc
{
    internal class KhachHang
    { 
        public string SDTKH { get; set; }
        public string TenKH { get; set; }

 
        public KhachHang() { }

      
        public KhachHang(string sdtKH, string tenKH)
        {
            SDTKH = sdtKH;
            TenKH = tenKH;
        }

       
    }
}
