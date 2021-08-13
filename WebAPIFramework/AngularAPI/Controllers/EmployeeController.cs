using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AngularAPI.Models;

namespace AngularAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        //public object CommadType { get; private set; }
        public HttpResponseMessage Get()
        {
            //string query = @"select EmployeeId, EmployeeName, Department,
            //   convert(varchar(10), DateOfJoining,120) as DateOfJoining,
            //    PhotoFileName
            //    from
            //    dbo.Employee";

            DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("employeeget", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.Fill(table);
                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            
        }

        public string Post(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("employeepost", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@employeename", emp.EmployeeName);
                    cmd.Parameters.AddWithValue("@department", emp.Department);
                    cmd.Parameters.AddWithValue("@dateofjoining", emp.DateOfJoining);
                    cmd.Parameters.AddWithValue("@photofilename", emp.PhotoFileName);
                    da.Fill(table);
                }
                return "Inserted Sucessfully";
            }
            catch (Exception)
            {
                return "Data not Inserted";
            }
        }

            public string Put(Employee emp)
            {
            try
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand("employeeupdate", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@employeename", emp.EmployeeId);
                    cmd.Parameters.AddWithValue("@employeename", emp.EmployeeName);
                    cmd.Parameters.AddWithValue("@department", emp.Department);
                    cmd.Parameters.AddWithValue("@dateofjoining", emp.DateOfJoining);
                    cmd.Parameters.AddWithValue("@photofilename", emp.PhotoFileName);
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
                using ( var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                    using ( var cmd = new SqlCommand("employeedelete", con))
                    using ( var da = new SqlDataAdapter(cmd) )
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@employeeid", id);
                    da.Fill(table);
                }
                return "Data deleted";
            }
            catch (Exception)
            {
                return "Error while deleting data";
            }
        }

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"
            select DepartmentName from dbo.Department
            ";

            DataTable table = new DataTable();
            using ( var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using( var cmd =  new SqlCommand(query, con))
                using ( var da =  new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/Employee/SaveFile")]
           public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);
                return filename;
            }
            catch(Exception)
            {
                return "anonymous.png";
            }
        }
        
    }
}
