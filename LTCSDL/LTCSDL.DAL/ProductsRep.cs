using LTCSDL.Common.DAL;
using System.Linq;

namespace LTCSDL.DAL
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
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
        public Products InsertProductADO(Products prod)
        {
            Products x = new Products();
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
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        x = new Products
                        {
                            ProductId = Int16.Parse(row["ProductID"].ToString()),
                            ProductName = row["ProductName"].ToString(),
                            SupplierId =Int16.Parse( row["SupplierID"].ToString()),
                            CategoryId = Int16.Parse(row["CategoryID"].ToString()),
                            QuantityPerUnit = row["QuantityPerUnit"].ToString(),
                            UnitPrice = Int16.Parse( row["UnitPrice"].ToString()),
                            UnitsInStock = Int16.Parse(row["UnitsInStock"].ToString()),
                            UnitsOnOrder = Int16.Parse(row["UnitsOnOrder"].ToString()),
                            ReorderLevel = Int16.Parse(row["ReorderLevel"].ToString()),
                            Discontinued = Int16.Parse(row["Discontinued"].ToString()),
                        };
                        return x;
                    }
                }
            }
            catch (Exception e)
            {
                x = null;
            }
            return x;
        }

        // Câu 4 đề 5 nhập ngày xuất ra danh sách đơn hàng và tên khách hàng cần giao trong ngày
        public object getDSDonHangDe5_Linq(DateTime date)
        {
            var res = Context.Orders
                .Where(x => x.OrderDate.HasValue
                   && x.OrderDate.Value.Date == date.Date)
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
            return data;

        }

    }
}
