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
    using BLL;
    using DAL.Models;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            _svc = new ProductsSvc();
        }
        private readonly ProductsSvc _svc;
        //Câu 2 a đề 5
        [HttpPost("xuat-danh-sach-san-pham-khong-co-trong-don-hang")]
        public IActionResult DSSanPhamKhongCoTrongNgay([FromBody] DatePaggeSizeReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSSanPhamKhongCoTrongNgay(req.date, req.page, req.size);
            return Ok(res);
        }
        // Câu 2 c đề 5
        [HttpPost("tim-kiem-don-hang")]
        public IActionResult TimKiemOrder([FromBody] CompanyNameReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetTimKiemOrder(req.companyName,req.employeeName, req.page, req.size);
            return Ok(res);
        }

        //Câu 3 đề 5 ADO thêm record cho bảng Products
        [HttpPost("them-record-product")]
        public IActionResult InsertProductADO([FromBody] ProdInsertReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.InsertProductADO(req);
            res.Data = hist;
            return Ok(res);
        }

        //Câu 3 đề 5 thêm record cho bảng Products bằng LINQ
        [HttpPost("them-record-product-LINQ")]
        public IActionResult InsertProductLINQ([FromBody] ProdInsertReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.InsertProductLINQ(req);
            res.Data = hist;
            return Ok(res);
        }

        // Câu 4 đè 5 Linq
        [HttpPost("danh-sach-don-hang-cau4-de5-LINQ")]
        public IActionResult getDSDonHangDe5_Linq([FromBody] DayMonthYearReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSDonHangDe5_Linq(req.day,req.month,req.year,req.page,req.size);
            return Ok(res);
        }


        // Câu 5 đề 5 Linq
        [HttpPost("so-luong-hang-hoa-can-giao-trong-ngay")]
        public IActionResult dsSoLuongHangHoaCanGiaoTrongNgay([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res = _svc.dsSoLuongHangHoaCanGiaoTrongNgay(req.dateBegin, req.dateEnd);
            return Ok(res);
        }


    }
}


