using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.BLL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesController()
        {
            _svc = new EmployeesSvc();
        }
        private readonly EmployeesSvc _svc;

        //Câu 2 a đế 1
        [HttpPost("Doanh thu Nhân viên")]
        public IActionResult DoanhThuNhanVien([FromBody] DateReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDoanhThuNhanVien(req.date);
            return Ok(res);
        }

         //Câu 2 b đề 1
        [HttpPost("Doanh thu Nhân viên trong khoảng thời gian")]
        public IActionResult DoanhThuNhanVienTrongThoiGian([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDoanhThuNhanVienTrongKhoangThoiGian(req.dateBegin, req.dateEnd);
            return Ok(res);
        }
        //Câu 3 a đề 1
        [HttpPost("Doanh thu Nhân viên LINQ")]
        public IActionResult getDTNVTrongNgay_Linq([FromBody] DateReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDoanhThuNhanVien_linq(req.date);
            return Ok(res);
        }
        // câu 3 b đề 1
        [HttpPost("Doanh thu Nhân viên Trong khoảng thời gian LINQ")]
        public IActionResult DoanhThuNhanVienTrongThoiGian_LINQ([FromBody] DateBeginEndReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GetDoanhThuNhanVienTrongThoiGian_LINQ(req.dateBegin, req.dateEnd);
            return Ok(res);
        }
    }
}