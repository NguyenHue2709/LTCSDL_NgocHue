using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
   public class CompanyNameReq
    {
        public String companyName { get; set; }
        public String employeeName { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
