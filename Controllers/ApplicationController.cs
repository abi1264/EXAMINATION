using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using EXAMINATION.Models.DTO;
using EXAMINATION.Mappers;


namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ApplicationController(ApplicationDbContext Dbcontext)
        {
            this.dbContext = Dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationData()
        {
            var applicationdata = await dbContext.Applications.
                Include(application => application.User)
                .ThenInclude(user => user.StudentProfile)
                .Include(application => application.Semester)
                .Include(application => application.Program)
                .Include(application => application.Courses)
                .ToListAsync();
            return Ok(applicationdata);
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetApplicationsByUserId(int userId)
        {
            var applications = await dbContext.Applications
                .Where(a => a.UserId == userId)
                .Include(a => a.User)
                    .ThenInclude(u => u.StudentProfile)
                .Include(a => a.Semester)
                .Include(a => a.Program)
                .Include(a => a.Courses)
                .ToListAsync();

            if (!applications.Any())
                return NotFound($"No applications found for user with ID {userId}.");

            return Ok(applications);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetApplicationDataById(int id)
        {
            var applicationdata = await dbContext.Applications
                 .Include(application => application.User)
                .ThenInclude(user => user.StudentProfile)
                .Include(application => application.Semester)
                .Include(application => application.Program)
                .Include(application => application.Courses)
                .FirstOrDefaultAsync(application => application.Id == id);


            if (applicationdata is null)
            {
                return NotFound();

            }
            return Ok(applicationdata);
        }



        [HttpPost]
        public async Task<IActionResult> AddApplicationData(ApplicationCreateDto dtoData)
        {

            var courses = await dbContext.Courses.
                 Where(c => dtoData.CourseIds.Contains(c.Id))
                 .ToListAsync();

            var programId = await dbContext.Semesters
             .Where(s => s.Id == dtoData.SemesterId)
             .Select(s => s.ProgramId)
             .FirstOrDefaultAsync();

            if (programId == 0)
                return BadRequest("Invalid Semester ID");
            // Check if the program actually exists
            var programExists = await dbContext.Programs.AnyAsync(p => p.Id == programId);
            if (!programExists)
                return BadRequest("The Semester's Program does not exist in the system.");

            var application = new Application
            {
                UserId = dtoData.UserId,
                SemesterId = dtoData.SemesterId,
                ExamType = dtoData.ExamType,
                ProgramId = programId,
                Courses = courses,
                Status = ApplicationStatus.Pending
            };

            dbContext.Applications.Add(application);
            await dbContext.SaveChangesAsync();
            return Ok(application);

        }
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateApplication(int id, ApplicationDto updateApplicationData)
        {
            var application = await dbContext.Applications.FindAsync(id);

            if (application == null)
                return NotFound();

            // Only SemesterId if provided in the request
            if (updateApplicationData.SemesterId.HasValue)
            {
                var programId = await dbContext.Semesters
                    .Where(s => s.Id == updateApplicationData.SemesterId.Value)
                    .Select(s => s.ProgramId)
                    .FirstOrDefaultAsync();

                if (programId == 0)
                    return BadRequest("Invalid Semester ID");

                application.SemesterId = updateApplicationData.SemesterId.Value;
                application.ProgramId = programId;
            }

            if (updateApplicationData.ExamType.HasValue)
                application.ExamType = updateApplicationData.ExamType.Value;

            if (updateApplicationData.Status.HasValue)
                application.Status = updateApplicationData.Status.Value;

            ApplicationMapper.ApplyPatch(updateApplicationData, application);

            await dbContext.SaveChangesAsync();

            return Ok(application);
        }


        [HttpDelete]
        public IActionResult DeleteApplication(int id)
        {
            var application = dbContext.Applications.Find(id);
            if (application is null)
            {
                return NotFound();
            }
            dbContext.Applications.Remove(application);
            dbContext.SaveChanges();
            return Ok();




        }
    }
}

