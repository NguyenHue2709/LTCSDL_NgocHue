using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.DAL
{
    using LTCSDL.Common.DAL;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    public class OrdersRep : GenericRep<NorthwindContext, Orders>
    {
        //câu 2 a đề 2
        public List<object> XuatDSDonHang(DateTime dateBegin, DateTime dateEnd)

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
                cmd.CommandText = "DSDonHang ";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dateBegin", dateBegin);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],
                            RequiredDate = row["RequiredDate"],
                            ShippedDate = row["ShippedDate"],
                            ShipVia = row["ShipVia"],
                            Freight = row["Freight"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"],
                            ShipCity = row["ShipCity"],
                            ShipRegion = row["ShipRegion"],
                            ShipPostalCode = row["ShipPostalCode"],
                            ShipCountry = row["ShipCountry"],
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
        //câu 2 b đề 2
        public object ChiTietDonHang(int maDonHang)

        {
            object res = new object();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "ChiTietDonHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],
                            RequiredDate = row["RequiredDate"],
                            ShippedDate = row["ShippedDate"],
                            ShipVia = row["ShipVia"],
                            Freight = row["Freight"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"],
                            ShipCity = row["ShipCity"],
                            ShipRegion = row["ShipRegion"],
                            ShipPostalCode = row["ShipPostalCode"],
                            ShipCountry = row["ShipCountry"],
                        };
                        res = (x);
                    }
                }

            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }

        //Câu 3 a đề 2
        public object XuatDSDonHang_Linq(DateTime dateBegin, DateTime dateEnd)
        {
            var res = All.Where(x => x.OrderDate >= dateBegin && x.OrderDate <= dateEnd);
            var data = res.OrderBy(x => x.OrderDate).ToList();
            return new
            {
                Data = data
            };
        }

        //Câu 3 b đề 2
        public object ChiTietDonHang_Linq(int maDonHang)
        {
            var res = All.Where(x => x.OrderId == maDonHang);
            var data = res.OrderBy(x => x.OrderId).ToList();
            return new
            {
                Data = data
            };
        }
        //Câu 2 a đề 3
        public List<object> DanhSachDonHang(String tenNhanVien, DateTime dateBegin, DateTime dateEnd, int page, int size)

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
                cmd.CommandText = "DSDonHangDe3";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenNhanVien", tenNhanVien);
                cmd.Parameters.AddWithValue("@dateBegin", dateBegin);
                cmd.Parameters.AddWithValue("@dateEnd", dateEnd);
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
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],

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
        // Câu 2 b đề 3
        public List<object> MatHangBanChay(int thang, int nam, int page, int size, int isQuanity)

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
                cmd.CommandText = "MatHangBanChay";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@thang", thang);
                cmd.Parameters.AddWithValue("@nam", nam);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@isQuanity", isQuanity);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && isQuanity == 1)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            ProductID = row["ProductID"],
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            Discount = row["Discount"],
                            SoLuong = row["SoLuong"],
                            //DoanhThu = row["DoanhThu"],

                        };
                        res.Add(x);
                    }
                }
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && isQuanity != 1)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            ProductID = row["ProductID"],
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            Discount = row["Discount"],
                            //SoLuong = row["SoLuong"],
                            DoanhThu = row["DoanhThu"],

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
        // Câu 3 Thêm record cho bảng Shippers ADO đề 3
        public Shippers InsertShippADO(Shippers ship)
        {
            Shippers x = new Shippers();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                String sql = "INSERT INTO[dbo].[Shippers]([CompanyName],[Phone]) VALUES('" + ship.CompanyName + "','" + ship.Phone + "')";
                DataSet ds = new DataSet();
                sql = sql + "Select * from Shippers where ShipperID = @@IDENTITY";
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
                        x = new Shippers
                        {
                            ShipperId = Int16.Parse(row["ShipperID"].ToString()),
                            CompanyName = row["CompanyName"].ToString(),
                            Phone = row["Phone"].ToString(),


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
        //Câu 4  đề 3
        
      
    }
}
