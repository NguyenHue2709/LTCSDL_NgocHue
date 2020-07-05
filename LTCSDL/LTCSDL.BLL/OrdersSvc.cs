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

    public class OrdersSvc : GenericSvc<OrdersRep, Orders>
    {
        //câu 2 a đề 2
        public List<object> GetDSDonHang(DateTime dateBegin, DateTime dateEnd)
        {
            return _rep.XuatDSDonHang(dateBegin, dateEnd);
        }

        //Câu 2 b đề 2
        public object GetChiTietDonHang(int maDonHang)
        {
            return _rep.ChiTietDonHang(maDonHang);
        }
        // Câu 3 a đề 2
        public object GetDSDonHang_Linq(DateTime dateBegin, DateTime dateEnd)
        {
            return _rep.XuatDSDonHang_Linq(dateBegin, dateEnd);
        }

        //Câu 3 b đề 2
        public object GetChiTietDonHang_Linq(int maDonHang)
        {
            return _rep.ChiTietDonHang_Linq(maDonHang);
        }
        //Câu 2 a đề 3
        public List<object> GetDanhSachDonHang (String tenNhanVien, DateTime dateBegin, DateTime dateEnd, int page, int size)
        {
            return _rep.DanhSachDonHang(tenNhanVien, dateBegin, dateEnd, page, size);
        }
        //Câu 2 b đề 3
        public List<object> GetMatHangBanChay(int thang, int nam, int page, int size, int isQuanity)
        {
            return _rep.MatHangBanChay(thang, nam,  page, size, isQuanity);
        }
        //Câu 3 đề 3
        public Shippers InsertShippADO(ShipperInsertReq req)
        {
            Shippers ship = new Shippers();
            ship.CompanyName = req.CompanyName;
            ship.Phone = req.Phone;
            return _rep.InsertShippADO(ship);
        }

        //Câu 4a đề 3
        public SingleRsp DanhSachDonHang_LINQ(String tenNhanVien, DateTime dateBegin, DateTime dateEnd, int page, int size)
        {
            var res = new SingleRsp();
            var m = _rep.DanhSachDonHang_LINQ(tenNhanVien, dateBegin, dateEnd, page, size);
            res.Data = m;
            return res;
        }

        //Câu 4b đề 3
        public SingleRsp DoanhThuTheoQuocGia_LINQ(int thang, int nam)
        {
            var res = new SingleRsp();
            var m = _rep.DoanhThuTheoQuocGia_LINQ(thang, nam);
            res.Data = m;
            return res;
        }

    }
}
