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
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

      

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //câu 2 a đề 2
        [HttpPost("xuất danh sách đơn hàng")]
        public IActionResult XuatDSDonHang([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSDonHang(req.dateBegin, req.dateEnd);
            return Ok(res);
        }
        //Câu 2 b đề 2
        [HttpPost("xuất chi tiết đơn hàng")]
        public IActionResult ChiTietDonHang([FromBody] IntReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetChiTietDonHang(req.maDonHang);
            return Ok(res);
        }
        //Câu 3 a đề 2
        [HttpPost("Xuất danh sách đơn hàng LINQ")]
        public IActionResult XuatDSDonHang_Linq([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDSDonHang_Linq(req.dateBegin, req.dateEnd);
            return Ok(res);
        }

        //Câu 3 b đề 2
        [HttpPost("Xuất chi tiết đơn hàng LINQ")]
        public IActionResult ChiTietDonHang_Linq([FromBody] IntReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetChiTietDonHang_Linq(req.maDonHang);
            return Ok(res);
        }
        // Câu 2 a đề 3
        [HttpPost("xuất danh sách dơn hàng theo tên nhân viên")]
        public IActionResult DanhSachDonHang([FromBody] TenNhanVienReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetDanhSachDonHang(req.tenNhanVien, req.dateBegin, req.dateEnd, req.page, req.size);
            res.Data = hist;
            return Ok(res);
        }
        // Câu 2 b đề 3
        [HttpPost("xuất danh sách mặt hàng bán chạy")]
        public IActionResult MatHangBanChay([FromBody] MatHangReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.GetMatHangBanChay(req.thang, req.nam, req.page, req.size, req.isQuanity);
            res.Data = hist;
            return Ok(res);
        }
        //Câu 3 đề 3
        [HttpPost("Thêm record Shippers")]
        public IActionResult InsertShippADO([FromBody] ShipperInsertReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.InsertShippADO(req);
            res.Data = hist;
            return Ok(res);
        }
    }
}
 