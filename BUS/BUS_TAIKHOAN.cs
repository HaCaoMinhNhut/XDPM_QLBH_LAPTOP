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
    public class BUS_TAIKHOAN
    {
        DAL_TAIKHOAN dal = new DAL_TAIKHOAN();
        public DataTable ListofTAIKHOAN()
        {
            return dal.ListofTAIKHOAN();
        }
        public bool InsertTAIKHOAN(DTO_TAIKHOAN dto)
        {
            return dal.InsertTAIKHOAN(dto);
        }
        public DataTable LoginTAIKHOAN(string taikhoan,string matkhau)
        {
            return dal.LoginTAIKHOAN(taikhoan,matkhau);
        }
        public DataTable CheckTAIKHOAN(string manv)
        {
            return dal.CheckTAIKHOAN(manv);
        }
        public bool UpdateTAIKHOAN(DTO_TAIKHOAN dto)
        {
            return dal.UpdateTAIKHOAN(dto);
        }
        
    }
}
