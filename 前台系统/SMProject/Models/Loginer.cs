using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Loginer
    {
        public int LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string LoginName { get; set; }

        //管理员账户
        public int AdminStatus { get; set; }
        public int RoleId { get; set; }           
    }
}
