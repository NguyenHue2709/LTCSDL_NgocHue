using System;
using System.Collections.Generic;
using System.Text;


namespace LTCSDL.Common.Req
{
   public class CategoriesReq
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
