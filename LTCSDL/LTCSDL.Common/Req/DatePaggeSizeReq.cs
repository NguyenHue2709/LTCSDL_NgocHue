using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
   public class DatePaggeSizeReq
    {
        public DateTime date { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
