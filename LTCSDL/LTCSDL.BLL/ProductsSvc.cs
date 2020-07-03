using LTCSDL.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using LTCSDL.Common.Rsp;
namespace LTCSDL.BLL
{
    using LTCSDL.Common.Req;
    using LTCSDL.DAL;
    using LTCSDL.DAL.Models;

    public class ProductsSvc:GenericSvc<ProductsRep, Products>
    {
        //Câu 2 a đề 5
        public object GetDSSanPhamKhongCoTrongNgay(DateTime date, int page, int size)
        {
            return _rep.DSSanPhamKhongCoTrongNgay(date, page, size);
        }
        //Câu 2 c đề 5
        public object GetTimKiemOrder(String companyName, String employeeName, int page, int size)

        {
            return _rep.TimKiemOrder(companyName,employeeName, page, size);
        }
        // Câu 3 đề 5 ADO thêm record cho bảng Products
        public Products InsertProductADO(ProdInsertReq req)
        {
            Products prod = new Products();
            prod.ProductName = req.ProductName;
            prod.SupplierId = req.SupplierId;
            prod.CategoryId = req.CategoryId;
            prod.QuantityPerUnit = req.QuantityPerUnit;
            prod.UnitPrice = req.UnitPrice;
            prod.UnitsInStock = req.UnitsInStock;
            prod.UnitsOnOrder = req.UnitsOnOrder;
            prod.ReorderLevel = req.ReorderLevel;
            prod.Discontinued = req.Discontinued;
            return _rep.InsertProductADO(prod);
        }

        //Câu 4 đề 5 linq
        public object GetDSDonHangDe5_Linq(DateTime date)
        {
            return _rep.getDSDonHangDe5_Linq(date);
        }
    }
}
