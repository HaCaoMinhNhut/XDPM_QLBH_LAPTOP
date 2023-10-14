namespace DTO
{
    public class DTO_NHANVIEN
    {//MANV,TENNV,NGAYSINH,DIACHI,GIOITINH,MACV
        private string manv;
        private string tennv;
        private string  ngaysinh;
        private string  diachi;
        private bool gioitinh;
        private string macv;

        public DTO_NHANVIEN(string manv, string tennv, string ngaysinh, string diachi, bool gioitinh, string macv
 )
        {
            this.manv = manv;
            this.tennv = tennv;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.gioitinh= gioitinh;
            this.macv = macv;
        }
        public DTO_NHANVIEN(string tennv, string macv)
        {
            this.macv = macv;
            this.tennv = tennv;
        }
        public string MANV {
            get => manv;set => manv = value;
        }
        public string TENNV { get=> tennv;set => tennv = value; }
        public string NGAYSINH { get=> ngaysinh; set => ngaysinh = value;
        }
        public string DIACHI { get=> diachi; set => diachi = value;
        }
        public bool GIOITINH { get => gioitinh; set => gioitinh = value; }
        public string MACV { get => macv; set => macv = value;
        }
  }
}