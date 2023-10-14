using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_RESPORT
    {
        DAL_RESPORT dal= new DAL_RESPORT();
        public DataTable reportHOADON(string mahd)
        {
            return dal.reportHOADON(mahd);
        }
        public DataTable reportNHANVIEN(string manv)
        {
            return dal.reportNHANVIEN(manv);
        }
    }
}
