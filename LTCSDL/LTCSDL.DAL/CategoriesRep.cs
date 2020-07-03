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

    public class CategoriesRep : GenericRep<NorthwindContext, Categories>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Categories Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m); //TODO
            return m.CategoryId;
        }

        // Câu 2 a đề 4
        public object AddNewSuplier(String companyName, String contactName, String contactTitle, String address, String city,
          String region, String postalCode, String country, String phone, String fax, String homePage)

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
                cmd.CommandText = "ThemRecord ";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyName", companyName);
                cmd.Parameters.AddWithValue("@contactName", contactName);
                cmd.Parameters.AddWithValue("@contactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@postalCode", postalCode);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@fax", fax);
                cmd.Parameters.AddWithValue("@homePage", homePage);
                da.SelectCommand = cmd;
                da.Fill(ds);
                
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            CompanyName = row["CompanyName"],
                            ContactName = row["ContactName"],
                            ContactTitle = row["ContactTitle"],
                            Address = row["Address"],
                            City = row["City"],
                            Region = row["Region"],
                            PostalCode = row["PostalCode"],
                            Country = row["Country"],
                            Phone = row["Phone"],
                            Fax = row["Fax"],
                            HomePage = row["HomePage"],
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

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        // Câu 2 b đề 4 
        public object UpdateSuplier(String companyName, String contactName, String contactTitle, String address, String city,
         String region, String postalCode, String country, String phone, String fax, String homePage)

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
                cmd.CommandText = "ThemRecord ";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyName", companyName);
                cmd.Parameters.AddWithValue("@contactName", contactName);
                cmd.Parameters.AddWithValue("@contactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@region", region);
                cmd.Parameters.AddWithValue("@postalCode", postalCode);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@fax", fax);
                cmd.Parameters.AddWithValue("@homePage", homePage);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            CompanyName = row["CompanyName"],
                            ContactName = row["ContactName"],
                            ContactTitle = row["ContactTitle"],
                            Address = row["Address"],
                            City = row["City"],
                            Region = row["Region"],
                            PostalCode = row["PostalCode"],
                            Country = row["Country"],
                            Phone = row["Phone"],
                            Fax = row["Fax"],
                            HomePage = row["HomePage"],
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
        // Câu 3 ADO đề 4
        public Shippers UpdateShippADO(Shippers ship)
        {
            Shippers x = new Shippers();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                String sql = "UPDATE [dbo].[Shippers] SET [CompanyName] = ('"+ship.CompanyName+"'), [Phone] = ('"+ship.Phone+ "') WHERE [ShipperID] = '"+ship.ShipperId+"'";
                DataSet ds = new DataSet();
                sql = sql + "Select * from Shippers where [ShipperID] = " + ship.ShipperId;
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

        // câu 3 Linq đề 4(chưa làm được)
        //câu 4 đề 4
        public object DSShipper_LINQ(int thang, int nam)
        {


            var res = Context.Shippers.Join(Context.Orders, a => a.ShipperId, b => b.ShipVia, (a, b) => new
            {
                a.ShipperId,
                a.CompanyName,
                a.Phone,
                b.ShippedDate,
                b.Freight,
                DT = b.Freight
            }).Where(x => x.ShippedDate.HasValue
                   && x.ShippedDate.Value.Month == thang && x.ShippedDate.Value.Year == nam).ToList();

            var data = res.GroupBy(x => x.ShipperId)
                         .Select(x => new
                         {
                             x.First().ShipperId,
                             x.First().CompanyName,
                             x.First().Phone,
                             x.First().ShippedDate,
                             //x.First().Freight,
                             Tien = x.Sum(t => t.DT),
                         }) ;

            return data;
        }


        #endregion
    }
}
