using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LoginLogPageQuery
    {        
        public DateTime  BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int RecordCount { get; set; }

        public int PageCount { get; set; }
    }
}
