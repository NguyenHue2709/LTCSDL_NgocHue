using LTCSDL.Common.DAL;
using System.Linq;

namespace LTCSDL.DAL
{
    using LTCSDL.Common.Rsp;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Runtime.InteropServices.ComTypes;
    public class ProductsRep : GenericRep<NorthwindContext, Products>
    {
        // Câu 2 a đề 5
        public List<object> DSSanPhamKhongCoTrongNgay(DateTime date, int page, int size)

        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "DSSanPhamKhongCoTrongNgay";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);


                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            ProductID = row["ProductID"],
                            ProductName = row["ProductName"],
                            SupplierID = row["SupplierID"],
                            CategoryID = row["CategoryID"],
                            QuantityPerUnit = row["QuantityPerUnit"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            UnitsOnOrder = row["UnitsOnOrder"],
                            ReorderLevel = row["ReorderLevel"],
                            Discontinued = row["Discontinued"],
                        };
                        res.Add(x);
                    }
                }

            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }
        // Câu 2 c đề 5
        public List<object> TimKiemOrder(String companyName, String employeeName, int page, int size)

        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "TimKiemOrder";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyName", companyName);
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);


                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            LastName = row["LastName"],
                            CompanyName = row["CompanyName"],

                        };
                        res.Add(x);
                    }
                }

            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }
        //Câu 3 đề 5 thêm record cho bảng Products bằng ADO
        public object InsertProductADO(Products prod)
        {
            object res = new object();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                String sql = "INSERT INTO[dbo].[Products] ([ProductName] ,[SupplierID] ,[CategoryID] ,[QuantityPerUnit] ,[UnitPrice] ,[UnitsInStock] ,[UnitsOnOrder],[ReorderLevel] ,[Discontinued]) VALUES('" + prod.ProductName + "', '" + prod.SupplierId + "', '" + prod.CategoryId + "', '" + prod.QuantityPerUnit + "', '" + prod.UnitPrice + "', '" + prod.UnitsOnOrder + "', '" + prod.UnitsOnOrder + "', '" + prod.ReorderLevel + "', '" + prod.Discontinued + "')";

                DataSet ds = new DataSet();
                sql = sql + "Select * from Products where ProductID = @@IDENTITY";
                SqlDataAdapter da = new SqlDataAdapter();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {


                    DataRow row = ds.Tables[0].Rows[0];
                    var x = new
                    {
                        ProductId = row["ProductID"],
                        ProductName = row["ProductName"],
                        SupplierId = row["SupplierID"],
                        CategoryId = row["CategoryID"],
                        QuantityPerUnit = row["QuantityPerUnit"],
                        UnitPrice = row["UnitPrice"],
                        UnitsInStock = row["UnitsInStock"],
                        UnitsOnOrder = row["UnitsOnOrder"],
                        ReorderLevel = row["ReorderLevel"],
                        Discontinued = row["Discontinued"]
                    };
                    res = x;
                }
            }
            catch (Exception)
            {
                res = null;
            }
            return res;
        }

        //Câu 3 đề 5 thêm record cho bảng Products bằng LINQ
        public SingleRsp InsertProductLINQ(Products prod)
        {
            var res = new SingleRsp();

            using (var context = new NorthwindContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Products.Add(prod);
                        res.Data = prod;
                        context.SaveChanges();
                        tran.Commit();


                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        res.SetError(e.StackTrace);
                    }
                }

            }

            return res;
        }

        // Câu 4 đề 5 nhập ngày xuất ra danh sách đơn hàng và tên khách hàng cần giao trong ngày
        public object getDSDonHangDe5_Linq(int day, int month, int year, int page, int size)
        {
            var res = Context.Orders
                .Where(x => x.OrderDate.HasValue
                   && x.OrderDate.Value.Day == day && x.OrderDate.Value.Month == month && x.OrderDate.Value.Year == year)
                .Join(Context.Customers, Orders => Orders.CustomerId, Customers => Customers.CustomerId, (Orders, Customers) => new
                {
                    Orders.OrderId,
                    Orders.OrderDate,
                    Orders.CustomerId,
                    Orders.ShipAddress,


                }).ToList();
            var data = res.GroupBy(x => x.OrderId)
                          .Select(x => new
                          {
                              x.First().CustomerId,
                              x.First().OrderDate,
                              x.First().ShipAddress,

                          });

            var offset = (page - 1) * size;
            var total = data.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var dataRes = data.OrderBy(x => x.OrderDate).Skip(offset).Take(size).ToList();

            var finalRes = new
            {
                Data = dataRes,
                TotalRecord = total,
                TotalPage = totalPage,
                Page = page,
                Size = size,
            };
            return finalRes;

        }

        //Câu 5 đề 5
        public object dsSoLuongHangHoaCanGiaoTrongNgay(DateTime datef, DateTime datel)
        {
            var data = Context.OrderDetails.Join(Context.Orders, a => a.OrderId, b => b.OrderId, (a, b) => new
            {
                b.RequiredDate,
                a.Quantity
            }).Where(x=>x.RequiredDate.HasValue && x.RequiredDate.Value.Date >= datef.Date && x.RequiredDate.Value.Date <= datel.Date)
            .ToList();

            var res = data.GroupBy(x => x.RequiredDate)
                .OrderBy(x=>x.First().RequiredDate)
                .Select(x => new
                {
                    RequiredDate = x.First().RequiredDate,
                    SoLuongHangHoa = x.Sum(x => x.Quantity)
                });

            return res;
        }



    }
}
