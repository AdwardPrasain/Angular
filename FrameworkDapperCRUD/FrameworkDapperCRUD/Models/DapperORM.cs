using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperCRUDFramework.Models
{
    public static class DapperORM
    {
        private static string connectionString = @"Data Source=.; Initial Catalog=EmployeeDB; Integrated Security = True";

        public static void ExecuteWithoutReturn(String procedureName, DynamicParameters param)
        {
            using (SqlConnection con  =  new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        //DapperORM.ExecuteReturnScaler<int>(...,..)
        public static T ExecuteReturnScaler<T>(String procedureName, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                 return (T) Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        //DapperORM.ReturnList<EmployeeModel> <=IEnumerable<EmployeeModel>
        public static IEnumerable<T>ReturnList<T>(String procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);

            }
        }


    }
}