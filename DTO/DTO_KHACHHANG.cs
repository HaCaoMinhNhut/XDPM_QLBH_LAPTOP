using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KHACHHANG
    {
        private string makh;
        private string tenkh;
        private string diachi;
        private string sdt;
        public DTO_KHACHHANG()
        { }
         
        public DTO_KHACHHANG(string makh, string tenkh, string diachi, string sdt)
        {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
            this.sdt = sdt;
        }
        public DTO_KHACHHANG(string makh) {
            this.makh = makh;
        }

        public string MAKH { get => makh;set => makh = value; }
        public string TENKH { get => tenkh;set => tenkh = value; }
        public string DIACHI { get => diachi; set => diachi = value;
        }
        public string SDT { get => sdt; set => sdt = value;
        }
    }
}
