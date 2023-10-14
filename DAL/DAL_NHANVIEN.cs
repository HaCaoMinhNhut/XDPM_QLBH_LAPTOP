using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NHANVIEN : Connect
    {
        Connect my_conn = new Connect();
        DataTable dt = new DataTable();
        public DataTable ListOfSql()
        {//,CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,
           // CONVERT(varchar, GETDATE(), 103) AS NGAYSINH
            string sql = "SELECT MANV,TENNV, CONVERT(varchar, NGAYSINH, 103) AS NGAYSINH,DIACHI, CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,MACV FROM NHANVIEN";
            return my_conn.GetTable(sql);
        }
        public bool CheckNHANVIEN(string masp)
        {
            bool bl = true;
            string sql = "SELECT MANV,TENNV, CONVERT(varchar, NGAYSINH, 103) AS NGAYSINH,DIACHI, CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,MACV FROM NHANVIEN";
            sql += " WHERE MANV='"+masp+"'";
            dt = my_conn.GetTable(sql);
            if (dt.Rows.Count>0)
            {
                bl = false;
            }
            return bl;
        }
        public DataTable CheckNHANVIENfromTK(DTO_NHANVIEN dto)
        {
            
            string sql = "SELECT MANV,TENNV, CONVERT(varchar, NGAYSINH, 103) AS NGAYSINH,DIACHI, CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,MACV FROM NHANVIEN";
            sql += " WHERE TENNV=N'"+dto.TENNV+"' AND GIOITINH=N'"+dto.GIOITINH+"' AND NGAYSINH='"+dto.NGAYSINH+"' AND MACV='"+dto.MACV+"'";
          
                return my_conn.GetTable(sql);
        }
        public DataTable ListOfcb()
        {
            string sql = "SELECT*FROM CHUCVU";
            return my_conn.GetTable(sql);
        }
        public bool InsertNHANVIEN(DTO_NHANVIEN nv)
        {
           bool bl = false;
            string sql = "INSERT INTO NHANVIEN(MANV,TENNV,NGAYSINH,DIACHI,GIOITINH,MACV) ";
            sql += "VALUES (@MANV,@TENNV,CONVERT(VARCHAR,@NGAYSINH,103),@DIACHI,@GIOITINH,@MACV)";
            if(my_conn.NHANVIEN(sql,nv))
            {
                bl = true;
            }
                return bl;
        }
        public bool DeleteNHANVIEN(DTO_NHANVIEN nv)
        {
           bool bl = false;
            string sql = "DELETE FROM NHANVIEN WHERE MANV=@MANV";
            if (my_conn.NHANVIEN(sql, nv))
            {
                bl = true;
            }
            return bl;
        }
        public bool UpdateNHANVIEN(DTO_NHANVIEN nv)
        {
           bool bl = false;
            string sql = "UPDATE NHANVIEN SET TENNV=@TENNV,NGAYSINH=@NGAYSINH,DIACHI=@DIACHI,GIOITINH=@GIOITINH,MACV=@MACV ";
            sql += "WHERE MANV=@MANV";
            if (my_conn.NHANVIEN(sql, nv))
            {
                bl = true;
            }
            return bl;
        }
        public DataTable SearchNHANVIEN(DTO_NHANVIEN nv)
        {
            string sql = "SELECT MANV,TENNV, CONVERT(varchar, NGAYSINH, 103) AS NGAYSINH,DIACHI, CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,MACV  FROM NHANVIEN WHERE TENNV LIKE N'%" + nv.TENNV+"%'";
            return my_conn.GetTable(sql);

        }    
        public DataTable LoginNHANVIEN(string manv)
        {
            string sql="SELECT * FROM NHANVIEN WHERE MANV='"+manv+"'";

            return my_conn.GetTable(sql);
        }
        public DataTable LoadNHANVIEN(DTO_NHANVIEN dto)
        {
            string sql = "SELECT MANV,TENNV, CONVERT(varchar, NGAYSINH, 103) AS NGAYSINH,DIACHI, CASE GIOITINH WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GIOITINH,MACV FROM NHANVIEN WHERE TENNV=N'"+dto.TENNV+"' AND MACV='"+dto.MACV+"'";
            return my_conn.GetTable(sql);
        }
    }
}
