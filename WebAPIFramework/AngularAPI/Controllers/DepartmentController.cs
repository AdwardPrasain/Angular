
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularAPI.Models;

namespace AngularAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public object CommadType { get; private set; }

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using(var cmd = new SqlCommand("departmentget", con))
                using ( var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            { 
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("departmentpost", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@department_name", dep.DepartmentName);
                    da.Fill(table);  
                }
                return "Inserted Sucessfully";
            }
            catch (Exception)
            {
                return "Data not Inserted";
            }
        }

        //public string Put(Department dep)
        //{
        //    try
        //    {
        //        string query = @"update dbo.Department set DepartmentName = 
        //                    '" + dep.DepartmentName + @"'
        //                      where DepartmentId = "+dep.DepartmentId+@"";

        //        DataTable table = new DataTable();

        //        using (var con = new SqlConnection(ConfigurationManager.
        //            ConnectionStrings["EmployeeAppDB"].ConnectionString))
        //        using (var cmd = new SqlCommand(query, con))
        //        using (var da = new SqlDataAdapter(cmd))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            da.Fill(table);
        //        }
        //        return "updated successfully";

        //    }
        //    catch (Exception)
        //    {
        //        return "Failed to update data";
        //    }
        //}

        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("departmentupdate", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@department_id", dep.DepartmentId);
                    cmd.Parameters.AddWithValue("@department_name", dep.DepartmentName);
                    da.Fill(table);
                }
                return "Updated Sucessfully";
            }
            catch (Exception)
            {
                return "Data not Updated";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("departmentdelete", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@department_id", id);
                    da.Fill(table);
                }
                return "Deleted Sucessfully";
            }
            catch (Exception)
            {
                return "Data not Deleted";
            }
        }


    }
}
