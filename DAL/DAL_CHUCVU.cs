using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_CHUCVU
    {
        Connect my_conn = new Connect();
        public DataTable CheckCV(string macv)
        {
            string sql = "SELECT*FROM CHUCVU WHERE MACV='" + macv + "'";
            return my_conn.GetTable(sql);
        }
        public DataTable LoadCV()
        {
            string sql = "SELECT*FROM CHUCVU";
            return my_conn.GetTable(sql);
        }
    }
}
