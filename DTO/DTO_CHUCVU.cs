using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CHUCVU
    {
        private string macv;
        private string tencv;
        public DTO_CHUCVU(string macv, string tencv)
        {
            this.macv = macv;
            this.tencv = tencv;
        }
        public string MACV { get=>macv; set=>macv = value; }
        public string TENCV { get => tencv; set => tencv = value; }
    }
}
