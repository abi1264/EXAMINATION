using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using EXAMINATION.Models;
using EXAMINATION.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using EXAMINATION.Models.Entities;

namespace EXAMINATION.Controllers
{
    //localhost:xxxx/api/StudentProfile
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfileController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentProfileController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allStudents = dbContext.Students.ToList();
            return Ok(allStudents);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            
           var student= dbContext.Students.Find(id);
            if(student is null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            var studentEntity = new StudentProfile()
            {
                Id = addStudentDto.Id,
                UserId = addStudentDto.UserId,
                Signature=addStudentDto.Signature

            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);

        }

    }
}
