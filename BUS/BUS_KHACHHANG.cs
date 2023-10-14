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
    public class BUS_KHACHHANG
    {

        DAL_KHACHHANG DAL = new DAL_KHACHHANG();
        public DataTable ListOfKHACHHANG()
        {
            return DAL.ListOfSql();
        }
      
        public bool InsertKHACHHANG(DTO_KHACHHANG dto)
        {
            return DAL.InsertKHACHHANG(dto);
        }
        public bool DeleteKHACHHANG(DTO_KHACHHANG dto)
        {
            return DAL.DeleteKHACHHANG(dto);
        }
        public bool UpdateKHACHHANG(DTO_KHACHHANG dto)
        {
            return DAL.UpdateKHACHHANG(dto);
        }
        public DataTable SearchKHACHHANG(DTO_KHACHHANG dto)
        {
            return DAL.SearchKHACHHANG(dto);
        }
        public bool CheckKHACHHANG(string makh)
        {
            return DAL.CheckKHACHHANG(makh);
        }
    }
}

