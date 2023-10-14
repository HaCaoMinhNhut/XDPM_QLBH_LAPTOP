using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SANPHAM
    {//MASP,TENSP,SL,GIANHAP,DONGIA,HINHANH
        private string masp;
       private string tensp;
        private int sl;
        private float gianhap;
        private float giaban;
        private byte[] hinhanh; 
       
        public DTO_SANPHAM(string masp, string tensp, int sl, float gianhap, float giaban, byte[] hinhanh)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.sl = sl;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.hinhanh= hinhanh;
        }
        public string MASP { get => masp;set => masp = value; }
        public string TENSP { get => tensp;set => tensp = value; }
        public int SL { get => sl; set => sl = value; }
        public float GIANHAP { get => gianhap; set => gianhap = value; }
        public float DONGIA { get => giaban; set => giaban = value; }
        public byte[] HINHANH { get => hinhanh; set => hinhanh = value; }
    }
}
