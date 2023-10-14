using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_TAIKHOAN
    {
        Connect my_conn = new Connect();
        DataTable dt = new DataTable();
        public DataTable ListofTAIKHOAN()
        {
            string sql = "SELECT * FROM TAIKHOAN";
            return my_conn.GetTable(sql);
        }
        public bool InsertTAIKHOAN(DTO_TAIKHOAN dto)
        {
            bool bl=false;
            string sql = "INSERT INTO TAIKHOAN(MANV,MACV,TAIKHOAN,MATKHAU)";
            sql += "VALUES(@MANV,@MACV,@TAIKHOAN,@MATKHAU)";
            if(my_conn.TAIKHOAN(sql,dto))
            {
                bl=true;
            }    
            return bl;
        }
        public DataTable LoginTAIKHOAN(string username, string password)
        {
           // bool bl = false;
            string sql = "SELECT*FROM TAIKHOAN WHERE TAIKHOAN='"+username+"'";
            sql += " AND MATKHAU='"+password+"'";
            //dt=my_conn.GetTable(sql);
            //if(dt.Rows.Count>0)
            //{
            //    bl=true;
            //}    
            return my_conn.GetTable(sql);
        }
        public DataTable CheckTAIKHOAN(string manv)
        {
            string sql = "SELECT * FROM TAIKHOAN WHERE MANV='"+manv+"'";
            return my_conn.GetTable(sql);

        }
        public bool UpdateTAIKHOAN(DTO_TAIKHOAN dto)
        {
            bool bl = false;
            string sql = "UPDATE TAIKHOAN SET MATKHAU=@MATKHAU WHERE TAIKHOAN=@TAIKHOAN";
            if(my_conn.TAIKHOAN(sql,dto))
            {
                bl=true;
            }    
            return bl;
        }
    }

}
