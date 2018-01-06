using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class ErrorLogManager
    {
        public void ErrorLog(ErrorLog objError)
        {
            new ErrorLogService().ErrorLog(objError);
        }
    }
}
