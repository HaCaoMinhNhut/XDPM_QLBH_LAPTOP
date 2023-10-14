using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CTHD
    {
        Connect my_conn = new Connect();
        public DataTable ListSP()
        {
            string sql = "SELECT MASP,TENSP,SL,DONGIA FROM SANPHAM";
            return my_conn.GetTable(sql);
        }
        public DataTable ListCTHD(string mahd)
        {
            //string sql = "SELECT*FROM CHITIETHOADON";
            string sql = "SELECT*FROM CHITIETHOADON WHERE MAHD='"+mahd+"'";
            return my_conn.GetTable(sql);
        }
        public DataTable SP(string masp)
        {
            string sql = "SELECT*FROM SANPHAM WHERE MASP='"+masp+"'";
            return my_conn.GetTable(sql);
        }
        public DataTable DeleteHDfromCTHD(string mahd)
        {
            string sql = "DELETE FROM HOADON WHERE MAHD='"+mahd+"'";
                return my_conn.GetTable(sql);
        }
        public bool UpdateHDfromCTHD(string mahd,float tongtien)
        {
            bool bl=true;
            try { 
            string sql = "UPDATE HOADON SET TONGTIEN="+tongtien+" WHERE MAHD='" + mahd + "'";
            my_conn.GetTable(sql);
            }
            catch (Exception ex)
            {
                bl = false;
            }
            return bl;
        }
        public bool InsertCTHD(DTO_CTHD cthd)
        {
            bool bl = false;
            string sql = "INSERT INTO CHITIETHOADON(MAHD,MASP,SOLUONG,THANHTIEN)";
            sql += " VALUES(@MAHD,@MASP,@SOLUONG,@THANHTIEN)";
            if (my_conn.CTHD(sql, cthd))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateCTHD(DTO_CTHD cthd)
        {
            bool bl = false;
            string sql = "UPDATE CHITIETHOADON SET SOLUONG=@SOLUONG,THANHTIEN=@THANHTIEN WHERE MASP=@MASP AND MAHD=@MAHD";
            if(my_conn.CTHD(sql,cthd))
            {
                bl = true;
            }    
            return bl;
        }
        public bool DeleteCTHD(DTO_CTHD cthd)
        {
            bool bl = false;
            string sql = "DELETE FROM CHITIETHOADON WHERE MASP=@MASP";
            if(my_conn.CTHD(sql,cthd))
            {
                bl = true;
            }
            return bl;
        }
      
    }
}
