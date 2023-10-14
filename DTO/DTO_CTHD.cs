using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHD
    {
        private string mahd;
        private string masp;
        private int sl;
        private float thanhtien;
        public DTO_CTHD(string mahd, string masp, int sl, float thanhtien)
        {
            this.mahd = mahd;
            this.masp = masp;
            this.sl = sl;
            this.thanhtien = thanhtien;
        }
        public string MAHD { get => mahd;set => mahd = value; }
        public string MASP { get => masp; set => masp = value; }
        public int SL { get => sl; set => sl = value;  }
        public float THANHTIEN { get => thanhtien; set => thanhtien = value;
        }
    }
}
