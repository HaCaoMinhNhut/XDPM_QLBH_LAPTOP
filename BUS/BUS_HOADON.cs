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
    public class BUS_HOADON
    {
        DAL_CTHD DAL_CTHD = new DAL_CTHD();
        DAL_HOADON DAL = new DAL_HOADON();
        public DataTable ListOfHOADON()
        {
            return DAL.ListOfSql();
        }
        public DataTable ListOfNVtoHOADON() {
        
            return DAL.ListOfNV();
        }
        public DataTable ListOfKHtoHOADON()
        {

            return DAL.ListOfKH();
        }
        public bool InsertHOADON(DTO_HOADON dto)
        {
            return DAL.InsertHOADON(dto);
        }
        public bool DeleteHOADON(DTO_HOADON dto)
        {

            return DAL.DeleteHOADON(dto);
        }
        public bool UpdateHOADON(DTO_HOADON dto)
        {
            return DAL.UpdateHOADON(dto);
        }
        public DataTable SearchHOADON(string timebegin,string timeend)
        {
            return DAL.SearchHOADON(timebegin,timeend);
        }
    }
}
