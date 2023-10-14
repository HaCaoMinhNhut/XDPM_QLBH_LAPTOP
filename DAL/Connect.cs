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
    public class Connect
    {
       static string SqlConnect = "DATA SOURCE=DESKTOP-F3ASEVO;DATABASE=QLBANMAYTINH;Integrated security=true";
      public  SqlConnection Sqlcon = new SqlConnection(SqlConnect);
        public void OpenConnection()
        {
            try { 
          //  Sqlcon = new SqlConnection(SqlConnect);
            if (Sqlcon.State==ConnectionState.Closed)
            {
                Sqlcon.Open();
            }
            }catch (Exception ex)
            {
                throw ex;
            }
        }    
        public void CloseConnection()
        {
            try
            {
            
                if (Sqlcon.State == ConnectionState.Open)
                {
                    Sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,Sqlcon);
            adapter.Fill(dt);
            return dt;
        }
        public bool NHANVIEN(string sql,DTO_NHANVIEN nv)
        {
            bool bl= true;
            try { 
             OpenConnection();
            SqlCommand comm = new SqlCommand(sql, Sqlcon);
            comm.Parameters.Add(new SqlParameter("@MANV", nv.MANV));
            comm.Parameters.Add(new SqlParameter("@TENNV", nv.TENNV));
            comm.Parameters.Add(new SqlParameter("@NGAYSINH", nv.NGAYSINH));
            comm.Parameters.Add(new SqlParameter("@DIACHI", nv.DIACHI));
            comm.Parameters.Add(new SqlParameter("@GIOITINH", nv.GIOITINH));
            comm.Parameters.Add(new SqlParameter("@MACV", nv.MACV));
            comm.ExecuteNonQuery();
                CloseConnection();
            }catch(Exception ex)
            {
                bl = false;
                throw ex;
            }
            return bl;
        }
        public bool KHACHHANG(string sql, DTO_KHACHHANG kh)
        {
            bool bl = true;
            try
            {
                OpenConnection();
                SqlCommand comm = new SqlCommand(sql, Sqlcon);
                comm.Parameters.Add(new SqlParameter("@MAKH", kh.MAKH));
                comm.Parameters.Add(new SqlParameter("@TENKH", kh.TENKH));
                comm.Parameters.Add(new SqlParameter("@DIACHI", kh.DIACHI));
                comm.Parameters.Add(new SqlParameter("@SDT", kh.SDT));
                comm.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                bl = false;
                throw ex;
            }
            return bl;
        }
        public bool SANPHAM(string sql, DTO_SANPHAM sp)
        {
            bool bl = true;
            try
            {//MASP,TENSP,SL,GIANHAP,DONGIA,HINHANH
                OpenConnection();
                SqlCommand comm = new SqlCommand(sql, Sqlcon);
                comm.Parameters.Add(new SqlParameter("@MASP", sp.MASP));
                comm.Parameters.Add(new SqlParameter("@TENSP", sp.TENSP));
                comm.Parameters.Add(new SqlParameter("@SL", sp.SL));
                comm.Parameters.Add(new SqlParameter("@GIANHAP", sp.GIANHAP));
                comm.Parameters.Add(new SqlParameter("@DONGIA", sp.DONGIA));
                comm.Parameters.Add(new SqlParameter("@HINHANH", sp.HINHANH));
                comm.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                bl = false;
                throw ex;
            }
            return bl;
        }
        public bool HOADON(string sql,DTO_HOADON hd)
        {//MAHD,NGAY,MANV,MAKH,TONGTIEN
            bool bl = true;
            try
            {
                OpenConnection();
                SqlCommand comm = new SqlCommand(sql, Sqlcon);
                comm.Parameters.Add(new SqlParameter("@MAHD", hd.MAHD));
                comm.Parameters.Add(new SqlParameter("@NGAY", hd.NGAY));
                comm.Parameters.Add(new SqlParameter("@MANV", hd.MANV));
                comm.Parameters.Add(new SqlParameter("@MAKH", hd.MAKH));
                comm.Parameters.Add(new SqlParameter("@TONGTIEN", hd.TONGTIEN));
                comm.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                bl = false;
                throw ex;
            }
            return bl;
        }
        public bool CTHD(string sql, DTO_CTHD cthd)
        {//MAHD,MASP,SOLUONG,THANHTIEN
            bool bl = true;
            try
            {
                OpenConnection();
                SqlCommand comm = new SqlCommand(sql, Sqlcon);
                comm.Parameters.Add(new SqlParameter("@MAHD", cthd.MAHD));
                comm.Parameters.Add(new SqlParameter("@MASP", cthd.MASP));
                comm.Parameters.Add(new SqlParameter("@SOLUONG",cthd.SL));
                comm.Parameters.Add(new SqlParameter("@THANHTIEN", cthd.THANHTIEN));
                comm.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                bl = false;
            }
            return bl;
        }
        public bool TAIKHOAN(string sql,DTO_TAIKHOAN tk)
        {
            bool bl = true;
            try
            {
                OpenConnection();
                SqlCommand comm = new SqlCommand(sql, Sqlcon);
                comm.Parameters.Add(new SqlParameter("@MANV", tk.Manv));
                comm.Parameters.Add(new SqlParameter("@MACV", tk.MACV));
                comm.Parameters.Add(new SqlParameter("@TAIKHOAN", tk.TAIKHOAN));
                comm.Parameters.Add(new SqlParameter("@MATKHAU", tk.MATKHAU));
                comm.ExecuteNonQuery();
                CloseConnection();
            }
            catch (Exception ex)
            {
                bl = false;
                throw ex;
            }
            return bl;
        }
    }
}
