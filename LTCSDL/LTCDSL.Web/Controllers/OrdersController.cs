using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.BLL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LTCSDL.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            _svc = new OrdersSvc();
        }
        private readonly OrdersSvc _svc;

      
        //câu 2 a đề 2
        [HttpPost("danh-sach-don-hang-trong-khoan-thoi-gian")]
        public IActionResult XuatDSDonHang([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSDonHang(req.dateBegin, req.dateEnd);
            return Ok(res);
        }
        //Câu 2 b đề 2
        [HttpPost("chi-tiet-don-hang")]
        public IActionResult ChiTietDonHang([FromBody] IntReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetChiTietDonHang(req.maDonHang);
            return Ok(res);
        }
        //Câu 3 a đề 2
        [HttpPost("danh-sach-don-hang-LINQ")]
        public IActionResult XuatDSDonHang_Linq([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSDonHang_Linq(req.dateBegin, req.dateEnd);
            return Ok(res);
        }

        //Câu 3 b đề 2
        [HttpPost("chi-tiet-don-hang-LINQ")]
        public IActionResult ChiTietDonHang_Linq([FromBody] IntReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetChiTietDonHang_Linq(req.maDonHang);
            return Ok(res);
        }
        // Câu 2 a đề 3
        [HttpPost("danh-sach-don-hang-theo-ten-nhan-vien")]
        public IActionResult DanhSachDonHang([FromBody] TenNhanVienReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetDanhSachDonHang(req.tenNhanVien, req.dateBegin, req.dateEnd, req.page, req.size);
            res.Data = hist;
            return Ok(res);
        }
        // Câu 2 b đề 3
        [HttpPost("danh-sach-mat-hang-ban-chay")]
        public IActionResult MatHangBanChay([FromBody] MatHangReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetMatHangBanChay(req.thang, req.nam, req.page, req.size, req.isQuanity);
            res.Data = hist;
            return Ok(res);
        }
        //Câu 3 đề 3
        [HttpPost("them-record-shiper")]
        public IActionResult InsertShippADO([FromBody] ShipperInsertReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.InsertShippADO(req);
            res.Data = hist;
            return Ok(res);
        }


        //Câu 4a đề 3
        [HttpPost("danh-sach-don-hang-theo-ten-nhan-vien-LINQ")]
        public IActionResult DanhSachDonHang_LINQ([FromBody] TenNhanVienReq req)
        {
            var res = new SingleRsp();
            res = _svc.DanhSachDonHang_LINQ(req.tenNhanVien, req.dateBegin, req.dateEnd, req.page, req.size);
            return Ok(res);
        }


        //Câu 4b đề 3
        [HttpPost("danh-thu-theo-quoc-gia-LINQ")]
        public IActionResult DoanhThuTheoQuocGia_LINQ([FromBody] MonthYearReq req)
        {
            var res = new SingleRsp();
            res = _svc.DoanhThuTheoQuocGia_LINQ(req.month, req.year);
            return Ok(res);
        }

    }
}
 