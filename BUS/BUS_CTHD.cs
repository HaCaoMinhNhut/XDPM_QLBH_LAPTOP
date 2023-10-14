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
    public class BUS_CTHD
    {
        DAL_CTHD dal = new DAL_CTHD();
        public DataTable ListSP()
        {
            return dal.ListSP();
        }
        public DataTable SP(string masp)
        {
            return dal.SP(masp);
        }
        public DataTable ListCTHD(string mahd)
        {
            return dal.ListCTHD(mahd);
        }
        public bool InsertCTHD(DTO_CTHD cthd)
        {
            return dal.InsertCTHD(cthd);
        }
        public bool UpdateCTHD(DTO_CTHD cthd)
        {
            return dal.UpdateCTHD(cthd);
        }
        public bool DeleteCTHD(DTO_CTHD cthd)
        {
            return dal.DeleteCTHD(cthd);
        }
        public DataTable DeleteHDfromCTHD(string mahd) 
        {
            return dal.DeleteHDfromCTHD(mahd);
        }
        public bool UpdateHDfromCTHD(string mahd,float tongtien)
        {
            return dal.UpdateHDfromCTHD(mahd, tongtien);
        }


        
    }
}
