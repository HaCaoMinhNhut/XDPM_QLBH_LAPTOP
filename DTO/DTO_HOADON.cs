using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HOADON
    {//MAHD,NGAY,MAKH,MANV,TONGTIEN
        private string mahd;
        private string ngay;
        private string manv;
        private string makh;
        private float tongtien;
        public DTO_HOADON(string mahd, string ngay, string manv, string makh, float tongtien)
        {
            this.mahd = mahd;
            this.ngay = ngay;
            this.makh = makh;
            this.manv = manv;
            this.tongtien = tongtien;
        }
        public string MAHD { get=>mahd; set=>mahd = value; }
        public string NGAY { get=>ngay; set=>ngay = value; }
        public string MAKH { get=>makh; set=>makh = value; }
        public string MANV { get=>manv; set=>manv = value; }    
        public float TONGTIEN { get=>tongtien; set=>tongtien = value; }

    }
}
