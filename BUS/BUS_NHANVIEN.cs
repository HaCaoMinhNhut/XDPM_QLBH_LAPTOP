using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_NHANVIEN
    {
        DAL_NHANVIEN DAL = new DAL_NHANVIEN();
        public DataTable ListOfNHANVIEN()
        {
            return DAL.ListOfSql();
        }
        public DataTable CheckNHANVIENfromTK(DTO_NHANVIEN dto)
        {
            return DAL.CheckNHANVIENfromTK(dto);
        }
        public DataTable ListOfcvTonv()
        {
            return DAL.ListOfcb();
        }
        public bool InsertNHANVIEN(DTO_NHANVIEN dto)
        {
            return DAL.InsertNHANVIEN(dto);
        }
        public bool DeleteNHANVIEN(DTO_NHANVIEN dto)
        {
            return DAL.DeleteNHANVIEN(dto);
        }
        public bool UpdateNHANVIEN(DTO_NHANVIEN dto)
        {
            return DAL.UpdateNHANVIEN(dto);
        }
        public DataTable SearchNHANVIEN(DTO_NHANVIEN dto)
        {
            return DAL.SearchNHANVIEN(dto);
        }
        public bool CheckNHANVIEN(string manv)
        {
            return DAL.CheckNHANVIEN(manv);
        }  
        public DataTable LoginNHANVIEN(string manv)
        {
            return DAL.LoginNHANVIEN(manv);
        }
        public DataTable LoadNHANVIEN(DTO_NHANVIEN dto)
        {
            return DAL.LoadNHANVIEN(dto);
        }

        
    }
}
