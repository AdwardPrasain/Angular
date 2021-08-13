using DapperCrud;
using DapperCrud.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperCrud.Models
{
    public class StudentRepository
    {
        private string conStr;
        public StudentRepository()
        {
            conStr = @"Persist Security Info=False; Data Source=.;Initial Catalog=EmployeeDB; Integrated Security=true; Connection Timeout = 100000;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }

        //Insert Operation
        public void Add(Student student)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sql = @"insert into student (StudentName, Faculty)
                            values(@studentname, @faculty)";
                dbConnection.Open();
                dbConnection.Execute(sql, student);
                dbConnection.Close();
            }
        }

        //Get All
        public IEnumerable<Student> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sql = @"select * from student ";
                dbConnection.Open();
                return dbConnection.Query<Student>(sql);
            }
        }

        //Get By ID
        public Student GetById(int id)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sql = @"select * from student where StudentID = @id ";
                dbConnection.Open();
                return dbConnection.Query<Student>(sql, new { Id = id }).FirstOrDefault();
            }
        }

        //Update 
        public void Update(Student student)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sql = @"update student set StudentName = @studentname, Faculty= @faculty
                    where StudentId = @id";
                dbConnection.Open();
                dbConnection.Query(sql, student);
                dbConnection.Close();
            }
        }

        //Delete
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sql = @"delete from student
                    where StudentId = @id";
                dbConnection.Open();
                dbConnection.Query(sql, new { Id = id });
                dbConnection.Close();
            }
        }

    }
}