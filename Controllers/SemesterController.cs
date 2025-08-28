using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;


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
           
            dbContext.Semesters.Add(addSemesterData);
            dbContext.SaveChanges();
            return Ok(addSemesterData);
        }

        [HttpPatch]

        [Route("{id:int}")]
        public IActionResult UpdateSemester(int id, SemesterDto updateSemester)
        {
        var semester = dbContext.Semesters.Find(id);
        if (semester is null)
        {
            return NotFound();
        }

            SemesterMapper.ApplyPatch(updateSemester, semester);
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



    
    

        


    

