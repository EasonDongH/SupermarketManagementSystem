using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using System.Data;

namespace BLL
{
    public class LoginLogPageQueryManager
    {
        private DataPageQueryService objPageQuery = new DataPageQueryService();
        public DataSet GetLoginLogPageQueryDS(LoginLogPageQuery objLog)
        {
            return objPageQuery.GetLoginLogPageQuery(objLog); 
        }

        public int GetRecordCount(LoginLogPageQuery objLog)
        {
            return objPageQuery.GetRecordCount(objLog);
        }
    }
}
