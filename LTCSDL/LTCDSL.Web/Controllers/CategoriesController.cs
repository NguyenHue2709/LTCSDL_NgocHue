using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }

        // Câu 2 đề 4 Thêm Record cho bảng Suppliers (Bước 4)
        [HttpPost("insert-supplier")]
        public IActionResult AddNewSuplier([FromBody] SuppliersReq req)
        {

            var res = new SingleRsp();
            var m = _svc.GetThemReCord(req);
            res.Data = m;
            return Ok(res);

        }
        // Câu 2 đề 4 Update Record cho bảng Suppliers (Bước 4)
        [HttpPost("update-supplier")]
        public IActionResult UpdateSupiler([FromBody] SuppliersReq req)
        {

            var res = new SingleRsp();
            var m = _svc.GetUpdateSupplier(req);
            res.Data = m;
            return Ok(res);

        }
        // Câu 3 đề 4
        [HttpPost("cap-nhap-record-shipper")]
        public IActionResult UpdateShippADO([FromBody] ShippersReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.UpdateShippADO(req);
            res.Data = hist;
            return Ok(res);
        }

        // Câu 3 LINQ đề 4
        [HttpPost("cap-nhap-record-shipper-LINQ")]
        public IActionResult UpdateShip_LINQ([FromBody] ShippersReq req)
        {
            var res = new SingleRsp();
            var hist = _svc.UpdateShippADO(req);
            res.Data = hist;
            return Ok(res);
        }

        // Câu 4 đề 4
        [HttpPost("danh-sach-shipper-LINQ")]
        public IActionResult DSShipper_LINQ([FromBody] ThangNamReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.DSShipper_LINQ(req.thang, req.nam);
            return Ok(res);
        }
        private readonly CategoriesSvc _svc;
    }
}