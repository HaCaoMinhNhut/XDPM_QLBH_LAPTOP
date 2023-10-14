using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TAIKHOAN
    {// Quản trị viên
        private string manv;
        private string tk;
        private string mk;
        private string macv;
        public DTO_TAIKHOAN(string manv, string macv, string tk, string mk)
        {
            this.manv = manv;
            this.tk = tk;
            this.mk = mk;
            this.macv = macv;
        }
        public string Manv { get => manv; set => manv = value; }
        public string TAIKHOAN { get => tk; set => tk = value; }
        public string MATKHAU { get => mk;set=> mk = value; }
        public string MACV { get => macv; set => macv = value; }
    }
}
