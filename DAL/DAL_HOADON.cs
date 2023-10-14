using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_HOADON
    {//MAHD,NGAY,MAKH,MANV,TONGTIEN

        Connect my_conn = new Connect();

        public DataTable ListOfSql()
        {//,CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,
         // CONVERT(varchar, GETDATE(), 103) AS NGAYSINH
            string sql = "SELECT MAHD,CONVERT(varchar, NGAY, 103) AS NGAY,MAKH,MANV,TONGTIEN FROM HOADON";
            return my_conn.GetTable(sql);
        }
        public DataTable ListOfNV()
        {
            string sql = "SELECT*FROM NHANVIEN WHERE MACV='TN'";
            return my_conn.GetTable(sql);
        }
        public DataTable ListOfKH()
        {
            string sql = "SELECT*FROM KHACHHANG";
            return my_conn.GetTable(sql);
        }
        public bool InsertHOADON(DTO_HOADON hd)
        {
            bool bl = false;
            string sql = "INSERT INTO HOADON(MAHD,NGAY,MANV,MAKH,TONGTIEN) ";
            sql += "VALUES (@MAHD,CONVERT(VARCHAR,@NGAY,103),@MANV,@MAKH,@TONGTIEN)";
          if (my_conn.HOADON(sql, hd))
            {
                bl = true;
            }
            return bl;
        }
        public bool DeleteHOADON(DTO_HOADON hd)
        {
            bool bl = false;
            DTO_CTHD cthd = new DTO_CTHD(hd.MAHD, "", 0, 0);
            string sql = "DELETE FROM CHITIETHOADON WHERE MAHD=@MAHD";
            my_conn.CTHD(sql, cthd);
             sql = "DELETE FROM HOADON WHERE MAHD=@MAHD";
            if (my_conn.HOADON(sql, hd))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateHOADON(DTO_HOADON hd)
        {//MAHD,NGAY,MANV,MAKH,TONGTIEN
            bool bl = false;
            string sql = "UPDATE HOADON SET NGAY=@NGAY,MANV=@MANV,MAKH=@MAKH,TONGTIEN=@TONGTIEN";
            sql += " WHERE MAHD=@MAHD";
        if (my_conn.HOADON(sql, hd))
            {
                bl = true;
            }
            return bl;
        }
        public DataTable SearchHOADON(string timebegin, string timeend)
        {
            string sql = "SELECT MAHD,CONVERT(varchar, NGAY, 103) AS NGAY,MAKH,MANV,TONGTIEN FROM HOADON WHERE NGAY BETWEEN '" + timebegin+"' AND '"+timeend+"' ";
            return my_conn.GetTable(sql);

        }
    }
}
