using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using EXAMINATION.Models;
using EXAMINATION.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Enum;
using EXAMINATION.Mappers;


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
        public async Task<IActionResult> GetAllStudents()
        {
            var allStudents = await dbContext.Students.ToListAsync();
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
        public IActionResult AddStudent(StudentProfile addStudentDto)
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
               // Program = addStudentDto.Program,

                SemesterId = addStudentDto.SemesterId,
                //Semester = addStudentDto.Semester,
                ElectiveSubjects = addStudentDto.ElectiveSubjects,

                Applications = addStudentDto.Applications,
                Payments = addStudentDto.Payments,
                Results = addStudentDto.Results


            };
            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);

        }
        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateStudent(int id, StudentDto updateStudentDto)

        {
            var student = dbContext.Students.Find(id);
            if (student is null)
            {
                return NotFound();
            }
            StudentMapper.ApplyPatch(updateStudentDto, student); //using mapper class
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
