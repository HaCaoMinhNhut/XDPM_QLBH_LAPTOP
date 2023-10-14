using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_KHACHHANG
    {
        Connect my_conn = new Connect();
        DataTable dt= new DataTable();
        public DataTable ListOfSql()
        {
            string sql = "SELECT* FROM KHACHHANG";
            return my_conn.GetTable(sql);
        }
        public bool CheckKHACHHANG(string makh)
        {
            bool bl = true;
            string sql = "SELECT* FROM KHACHHANG";
            sql += " WHERE MAKH='"+makh+"'";
            dt=my_conn.GetTable(sql);
            if(dt.Rows.Count > 0 )
            {
                bl = false;
            }    
            return bl;
        }    
        
        public bool InsertKHACHHANG(DTO_KHACHHANG kh)
        {
            // makh, string tenkh, string diachi, string sdt
          bool bl = false;
            string sql = "INSERT INTO KHACHHANG(MAKH,TENKH,DIACHI,SDT) ";
            sql += "VALUES (@MAKH,@TENKH,@DIACHI,@SDT)";
            if (my_conn.KHACHHANG(sql, kh))
            {
                bl = true;
            }
            return bl;
        }
        public bool DeleteKHACHHANG(DTO_KHACHHANG kh)
        {
          bool bl = false;
            string sql = "DELETE FROM KHACHHANG WHERE MAKH=@MAKH";
            if (my_conn.KHACHHANG(sql, kh))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateKHACHHANG(DTO_KHACHHANG kh)
        {
          bool bl = false;
            string sql = "UPDATE KHACHHANG SET TENKH=@TENKH,DIACHI=@DIACHI,SDT=@SDT";
            sql += " WHERE MAKH=@MAKH";
            if (my_conn.KHACHHANG(sql, kh))
            {
                bl = true;
            }
            return bl;
        }
        public DataTable SearchKHACHHANG(DTO_KHACHHANG kh)
        {
            string sql = "SELECT * FROM KHACHHANG WHERE TENKH LIKE N'%" + kh.TENKH + "%'";
            return my_conn.GetTable(sql);

        }
    }
}
