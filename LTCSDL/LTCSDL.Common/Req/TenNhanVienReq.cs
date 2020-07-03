using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class TenNhanVienReq
    {
        public String tenNhanVien { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public int page { get; set;}
        public int size { get; set; }
    }
}
