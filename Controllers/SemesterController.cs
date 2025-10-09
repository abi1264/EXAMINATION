using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;
using System.Runtime.InteropServices;


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
            var semesterdata = await dbContext.Semesters.Include(semster => semster.Courses).ToListAsync();
            return Ok(semesterdata);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSemesterDataBySemesterId(int id)
        {
            var semesterData = await dbContext.Semesters
                .Include(semester => semester.Courses)
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

            var exists = await dbContext.Semesters
                      .AnyAsync(s => s.Name == addSemesterData.Name && s.ProgramId == addSemesterData.ProgramId);

            if (exists)
                return BadRequest(new { message = $"Semester with name '{addSemesterData.Name}' already exists. for the selected Program" });
            await dbContext.Semesters.AddAsync(addSemesterData);
            dbContext.SaveChanges();
            return Ok(addSemesterData);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateSemester(int id, [FromBody] SemesterDto updateSemester)
        {
            var semester = await dbContext.Semesters.FindAsync(id);
            if (semester is null)
                return NotFound();

            // Check if new name already exists
            if (!string.IsNullOrWhiteSpace(updateSemester.Name) &&
                await dbContext.Semesters.AnyAsync(s => s.Name == updateSemester.Name && s.Id != id && s.ProgramId == updateSemester.ProgramId))
            {
                return BadRequest(new { message = $"Semester with name '{updateSemester.Name}' already exists. for the selected Program" });
            }

            SemesterMapper.ApplyPatch(updateSemester, semester);
            await dbContext.SaveChangesAsync();

            return Ok(semester);
        }


        [HttpDelete("{id:int}")]

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











