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
    public class BUS_SANPHAM
    {
      DAL_SANPHAM DAL=new DAL_SANPHAM();
        public DataTable ListOfSANPHAM()
        {
            return DAL.ListOfSql();
        }
        public bool InsertSANPHAM(DTO_SANPHAM dto)
        {
            return DAL.InsertSANPHAM(dto);
        }
        public bool DeleteSANPHAM(DTO_SANPHAM dto)
        {
            return DAL.DeleteSANPHAM(dto);
        }
        public bool UpdateSANPHAM(DTO_SANPHAM dto)
        {
            return DAL.UpdateSANPHAM(dto);
        }
        public DataTable SearchSANPHAM(DTO_SANPHAM dto)
        {
            return DAL.SearchSANPHAM(dto);
        }
        public bool CheckSANPHAM(string masp)
        {
            return DAL.CheckSANPHAM(masp);
        }
    }
}
