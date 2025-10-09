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
        public async Task<IActionResult> GetSemesterData()
        {
            var semesterdata = await dbContext.Semesters
                .Include(semster => semster.Courses)
                .Include(course=>course.Program).ToListAsync();
            return Ok(semesterdata);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSemesterDataBySemesterId(int id)
        {
            var semesterData = await dbContext.Semesters
                .Include(semester => semester.Courses)
                .Include(course =>course.Program)
                .FirstOrDefaultAsync(semester => semester.Id == id);

            if (semesterData is null)
            {
                return NotFound();
            }

            return Ok(semesterData);
        }


        [HttpPost]
        public async Task<IActionResult> AddSemesterData(Semester addSemesterData)
        {

            await dbContext.Semesters.AddAsync(addSemesterData);
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
            if (semester is null)
            {
                return NotFound();
            }
            dbContext.Semesters.Remove(semester);
            dbContext.SaveChanges();
            return Ok();

        }

    }
}











