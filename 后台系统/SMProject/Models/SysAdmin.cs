using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class SysAdmin
    {
        public int LoginId { get; set; }
        public string LoginPwd { get; set; }
        public string AdminName { get; set; }
        public int AdminStatus { get; set; }
        public int RoleId { get; set; }
        //扩展属性
        public string StatusName { get; set; }
        public string RoleName { get; set; }
        //登录录成功时返回的日志ID号，目的是为了退出的时候更新退出时间
        public int LogId { get; set; }
    }
}
