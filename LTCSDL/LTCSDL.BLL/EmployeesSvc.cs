using Newtonsoft.Json;

using LTCSDL.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTCSDL.BLL
{

    using DAL;
    using DAL.Models;
    using LTCSDL.Common.Req;
    public class EmployeesSvc : GenericSvc<EmployeesRep, Employees>
    {

        //Câu 2 a đề 1
        public object GetDoanhThuNhanVien(DateTime date)
        {
            return _rep.DoanhThuNhanVien(date);
        }

        //Câu 2 b đề 1
        public List<object> GetDoanhThuNhanVienTrongKhoangThoiGian(DateTime dateBegin, DateTime dateEnd)
        {
            return _rep.DoanhThuNhanVienTrongThoiGian(dateBegin, dateEnd);
        }
        // Câu 3 a đề 1
        public object GetDoanhThuNhanVien_linq(DateTime date)
        {
            return _rep.getDTNVTrongNgay_Linq(date);
        }

        //câu 3 b đề 1
        public object GetDoanhThuNhanVienTrongThoiGian_LINQ(DateTime dateBegin, DateTime dateEnd)
        {
            return _rep.DoanhThuNhanVienTrongThoiGian_LINQ(dateBegin, dateEnd);
        }

    }
}
