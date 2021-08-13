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
   
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var rslt = DapperORM.ReturnList<Student>("studentviewall");
            return Request.CreateResponse(HttpStatusCode.OK, rslt);
        }
    }
}
