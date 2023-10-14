using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_SANPHAM
    {
        Connect my_conn = new Connect();
        DataTable dt = new DataTable();

        public DataTable ListOfSql()
        {
            string sql = "SELECT*FROM SANPHAM";
            return my_conn.GetTable(sql);
        }
        public bool CheckSANPHAM(string masp)
        {
            bool bl = true;
            string sql = "SELECT*FROM SANPHAM WHERE MASP='"+masp+"'";
            dt=my_conn.GetTable(sql);
            if(dt.Rows.Count>0)
            {
                bl=false;
            }    
            return bl;
        }    

        public bool InsertSANPHAM(DTO_SANPHAM sp)
        {
           
          bool bl = false;
            string sql = "INSERT INTO SANPHAM(MASP,TENSP,SL,GIANHAP,DONGIA,HINHANH) ";
            sql += "VALUES (@MASP,@TENSP,@SL,@GIANHAP,@DONGIA,@HINHANH)";
            if (my_conn.SANPHAM(sql, sp))
            {
                bl = true;
            }
            return bl;
        }
        public bool DeleteSANPHAM(DTO_SANPHAM sp)
        {
            bool bl = false;
            string sql = "DELETE FROM SANPHAM WHERE MASP=@MASP";
            if (my_conn.SANPHAM(sql, sp))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateSANPHAM(DTO_SANPHAM sp)
        {//MASP,TENSP,SL,GIANHAP,DONGIA,HINHANH
          bool bl = false;
            string sql = "UPDATE SANPHAM SET TENSP=@TENSP,SL=@SL,GIANHAP=@GIANHAP,DONGIA=@DONGIA,HINHANH=@HINHANH";
            sql += " WHERE MASP=@MASP";
            if (my_conn.SANPHAM(sql, sp))
            {
                bl = true;
            }
            return bl;
        }
        public DataTable SearchSANPHAM(DTO_SANPHAM sp)
        {
            string sql = "SELECT * FROM SANPHAM WHERE TENSP LIKE N'%" + sp.TENSP +"%'";
            return my_conn.GetTable(sql);

        }
    }
}
