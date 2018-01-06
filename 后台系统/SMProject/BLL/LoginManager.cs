using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class LoginManager
    {
        private LoginService objLoginService = new LoginService();
        public SysAdmin LoginVerify(SysAdmin objSysAdmin)
        {
            return objLoginService.LoginVerify(objSysAdmin);
        }

        public void LoginLog(LoginLogs objLog)
        {
            objLoginService.LoginLog(objLog);
        }

        public void ExitLog(LoginLogs objLog)
        {
            objLoginService.ExitLog(objLog);
        }
    }
}
