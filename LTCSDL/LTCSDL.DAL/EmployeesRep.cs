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
    public class EmployeesRep : GenericRep<NorthwindContext, Employees>
    {
        //Câu 2 a đề 1
        public object DoanhThuNhanVien(DateTime date)

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
                cmd.CommandText = "DsNhanVienTrongNgay" ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);
               
                da.SelectCommand = cmd;
                da.Fill(ds);
                
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeId = row["EmployeeId"],
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            DoanhThuTrongNgay = row["DoanhThuTrongNgay"],
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

        //Câu 2 b đề 1
        public List<object> DoanhThuNhanVienTrongThoiGian(DateTime dateBegin, DateTime dateEnd)

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
                cmd.CommandText = "DoanhThuTrongKhoangThoiGian";
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
                            EmployeeId = row["EmployeeId"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            doanhThu = row["doanhThu"],
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

        // Câu 3 a đề 1 Viết bằng Linq
        public object getDTNVTrongNgay_Linq(DateTime date)
        {
            var res = Context.Orders
                .Where(x => x.OrderDate.HasValue
                   && x.OrderDate.Value.Date == date.Date)
                .Join(Context.Employees, Orders => Orders.EmployeeId, Employees => Employees.EmployeeId, (Orders, Employees) => new
                {
                    Orders.OrderId,
                    Orders.OrderDate,
                    Orders.EmployeeId,
                    Employees.LastName,
                    Employees.FirstName

                })
                .Join(Context.OrderDetails, Orders => Orders.OrderId, Employees => Employees.OrderId, (Orders, Employees) => new
                {
                    Orders.OrderId,
                    Orders.OrderDate,
                    Orders.EmployeeId,
                    Orders.LastName,
                    Orders.FirstName,
                    DT = Employees.UnitPrice * Employees.Quantity * (1 - (decimal)Employees.Discount)
                })
                .ToList();
            var data = res.GroupBy(x => x.EmployeeId)
                          .Select(x => new
                          {
                              x.First().EmployeeId,
                              x.First().FirstName,
                              x.First().LastName,
                              DoanhThuTrongNgay = x.Sum(t => t.DT)
                          });
            return data;

        }

        // Câu 3 b đề 1
        public object DoanhThuNhanVienTrongThoiGian_LINQ(DateTime dateBegin, DateTime dateEnd)
        {


            var res = Context.Employees.Join(Context.Orders, a=>a.EmployeeId,b=>b.EmployeeId,(a,b)=>new
            {
                a.EmployeeId,
                a.LastName,
                a.FirstName,
                b.OrderId,
                b.OrderDate,
            }).Join(Context.OrderDetails, x =>x.OrderId, y=>y.OrderId, (x,y)=>new { 
                x.LastName,
                x.FirstName,
                x.EmployeeId,
                x.OrderDate,
                DT = y.UnitPrice * y.Quantity * (1 - (decimal)y.Discount)
            }).Where(x => x.OrderDate.HasValue
                   && x.OrderDate.Value.Date >= dateBegin.Date && x.OrderDate.Value.Date <= dateEnd.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId)
                         .Select(x => new
                         {
                             x.First().EmployeeId,
                             x.First().FirstName,
                             x.First().LastName,
                             doanhThu = x.Sum(t => t.DT)
                         });

            return data;
        }

        


    }
}
