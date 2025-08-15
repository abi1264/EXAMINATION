using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using EXAMINATION.Models;
using EXAMINATION.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Enum;
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
                Signature = addStudentDto.Signature,

                FatherName = addStudentDto.FatherName,

                MotherName = addStudentDto.MotherName,
                Gender = addStudentDto.Gender,
                MaritalStatus = addStudentDto.MaritalStatus,
                DateOfBirth = addStudentDto.DateOfBirth,

                CollegeName = addStudentDto.CollegeName,
                CollegeAddress = addStudentDto.CollegeAddress,

                ProgramId = addStudentDto.ProgramId,
                Program = addStudentDto.Program,

                SemesterId = addStudentDto.SemesterId,
                Semester = addStudentDto.Semester,
                ElectiveSubjects = addStudentDto.ElectiveSubjects,

                Applications = addStudentDto.Applications,
                Payments = addStudentDto.Payments,
                Results = addStudentDto.Results


            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);

        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateStudent(int id,UpdateStudentDto updateStudentDto )

        {
            var student = dbContext.Students.Find(id);
            if(student is null)
            {
                return NotFound();
            }
           // student.Id = updateStudentDto.Id;
            student.UserId = updateStudentDto.UserId;
            student.Signature = updateStudentDto.Signature;
            student.FatherName = updateStudentDto.FatherName;
            student.MotherName = updateStudentDto.MotherName;
            student.Gender = updateStudentDto.Gender;
            student.MaritalStatus = updateStudentDto.MaritalStatus;
            student.DateOfBirth = updateStudentDto.DateOfBirth;
            student.CollegeName = updateStudentDto.CollegeName;
            student.CollegeAddress = updateStudentDto.CollegeAddress;
            student.ProgramId = updateStudentDto.ProgramId;
            student.SemesterId = updateStudentDto.SemesterId;
            student.Semester = updateStudentDto.Semester;
            student.ElectiveSubjects = updateStudentDto.ElectiveSubjects;
            student.Applications=updateStudentDto.Applications;
            student.Payments=updateStudentDto.Payments;
            student.Results=updateStudentDto.Results;


            dbContext.SaveChanges();
            return Ok(student);
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        
            {
            var student = dbContext.Students.Find(id);
            if(student is null)
            {
                return NotFound();
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok();
            }

    }
}
