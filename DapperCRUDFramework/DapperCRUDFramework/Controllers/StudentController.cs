using DapperCRUDFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DapperCRUDFramework.Controllers
{
    public class StudentController : ApiController
    {
        public void Get()
        {
            return (DapperORM.ReturnList<Student>("studentviewall"));
        }
    }
}
