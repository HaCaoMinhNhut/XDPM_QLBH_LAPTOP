using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_RESPORT
    {
        Connect my_conn = new Connect();
        DataTable dt = new DataTable();
        public DataTable reportHOADON(string mahd)
        {
            string sql = "SELECT *FROM HOADON WHERE MAHD='"+mahd+"'";
            //MAHD,TENSP,NGAY,TENV,TENKH,TONGTIEN,
            sql = "SELECT CTHD.MAHD,SP.TENSP,SP.DONGIA,HD.NGAY,NV.TENNV,KH.TENKH,HD.TONGTIEN,CTHD.SOLUONG, CTHD.THANHTIEN, HD.NGAY  FROM HOADON AS HD, NHANVIEN AS NV, KHACHHANG AS KH, SANPHAM AS SP ,CHITIETHOADON AS CTHD  WHERE NV.MANV=HD.MANV AND KH.MAKH=HD.MAKH AND SP.MASP=CTHD.MASP AND HD.MAHD=CTHD.MAHD AND  HD.MAHD='" + mahd+"'";
            return my_conn.GetTable(sql);
        }
        public DataTable reportNHANVIEN(string manv)
        {
            string sql = "SELECT*FROM NHANVIEN WHERE MANV='"+manv+"'";
            return my_conn.GetTable(sql);
        }
    }
}
