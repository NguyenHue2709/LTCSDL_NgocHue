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

    public class CategoriesSvc : GenericSvc<CategoriesRep, Categories>
    {
        #region -- Overrides --
        
        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Categories m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.Description);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;               
            }

            return res;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        // Câu 2 a đề 4 Thêm Record vào bảng Suppliers (Bước 3)
        public object GetThemReCord(SuppliersReq req)
        {
            return _rep.AddNewSuplier(req.CompanyName, req.ContactName, req.ContactTitle, req.Address, req.City,
                req.Region, req.PostalCode, req.Country, req.Phone, req.Fax, req.HomePage);
        }

        // Câu 2 b đề 4 Update Record cho bảng Supliers
        #endregion
        public object GetUpdateSupplier(SuppliersReq req)
        {
            return _rep.UpdateSuplier(req.CompanyName, req.ContactName, req.ContactTitle, req.Address, req.City,
                req.Region, req.PostalCode, req.Country, req.Phone, req.Fax, req.HomePage);
        }
        //Câu 3 đề 4
        public Shippers UpdateShippADO(ShippersReq req)
        {
            Shippers ship = new Shippers();
            ship.ShipperId = req.Id;
            ship.CompanyName = req.CompanyName;
            ship.Phone = req.Phone;
            return _rep.UpdateShippADO(ship);
        }
        //Câu 3 LINQ đề 4
        public Shippers UpdateShip_LINQ(ShippersReq req)
        {
            Shippers ship = new Shippers();
            ship.ShipperId = req.Id;
            ship.CompanyName = req.CompanyName;
            ship.Phone = req.Phone;
            return _rep.UpdateShip_LINQ(ship);
        }
        //Câu 4 đề 4
        public object DSShipper_LINQ(int thang, int nam)
        {
            return _rep.DSShipper_LINQ(thang , nam);
        }
    }
}
