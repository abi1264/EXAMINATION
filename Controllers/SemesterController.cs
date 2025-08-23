using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SemesterController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SemesterController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetSemesterData()
        {
            var semesterdata = dbContext.Semesters.ToList();
            return Ok(semesterdata);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSemesterDataBySemesterId(int id)
        {
            var semesterData = dbContext.Semesters.Find(id);
            if (semesterData is null)
            {
                return NotFound();

            }
            return Ok(semesterData);
        }

        [HttpPost]
        public IActionResult AddSemesterData(Semester addSemesterData)
        {
            var semester = new Semester()
            {
                Id = addSemesterData.Id,
                Name = addSemesterData.Name,
                Fee = addSemesterData.Fee,
                ProgramId = addSemesterData.ProgramId,
                //Program = addSemesterData.Program,
                //Courses = addSemesterData.Courses,
                //Students = addSemesterData.Students,
                //Applications = addSemesterData.Applications

            };
            dbContext.Semesters.Add(semester);
            dbContext.SaveChanges();
            return Ok(semester);
        }

        [HttpPatch]

        [Route("{id:int}")]
        public IActionResult UpdateSemester(int id, Semester updateSemester)
        {
        var semester = dbContext.Semesters.Find(id);
        if (semester is null)
        {
            return NotFound();
        }
            semester.Id = updateSemester.Id;
            semester.Name = updateSemester.Name;
            semester.Fee = updateSemester.Fee;
            semester.ProgramId = updateSemester.ProgramId;
            //semester.Program = updateSemester.Program;
           // semester.Courses = updateSemester.Courses;
            //semester.Students = updateSemester.Students;
            //semester.Applications = updateSemester.Applications;

            dbContext.SaveChanges();
            return Ok(semester);

         }


        [HttpDelete]
         
        public IActionResult DeleteSemester(int id)
        {
            var semester = dbContext.Semesters.Find(id);
            if(semester is null)
            {
                return NotFound();
            }
            dbContext.Semesters.Remove(semester);
            dbContext.SaveChanges();
            return Ok();

            }

    }
}



    
    

        


    

