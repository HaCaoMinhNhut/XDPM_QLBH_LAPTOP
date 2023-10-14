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
    public class BUS_CHUCVU
    {
        DAL_CHUCVU dal= new DAL_CHUCVU();
        public DataTable CheckCV(string macv)
        {
            return dal.CheckCV(macv);
        }
        public DataTable LoadCV()
        {
            return dal.LoadCV();
        }
    }
}
