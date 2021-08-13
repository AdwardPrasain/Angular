using DapperCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository studentRepository;
        public StudentController()
        {
            studentRepository = new StudentRepository();
        }

        //GET All
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentRepository.GetAll();
        }

        //GET By ID
        [HttpGet]
        [Route("{id}")]

        public Student Get(int id)
        {
            return studentRepository.GetById(id);
        }

        //Insertt
        [HttpPost]

        public void Post([FromBody] Student student)
        {
            studentRepository.Add(student);
        }

        //Update
        [HttpPost]
        [Route("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            student.StudentId = id;
            if (ModelState.IsValid)
                studentRepository.Update(student);
        }

        //Delete
        [HttpDelete]
        public void Delete(int id)
        {
            studentRepository.Delete(id);
        }
    }
}
