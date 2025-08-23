using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;


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
        public IActionResult GetApplicationData()
        {
            var applicationdata = dbContext.Applications.ToList();
            return Ok(applicationdata);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetApplicationDataById(int id)
        {
            var applicationdata = dbContext.Applications.Find(id);
            if (applicationdata is null)
            {
                return NotFound();

            }
            return Ok(applicationdata);
        }



        [HttpPost]
        public IActionResult AddApplicationData(Application addApplicationData)
        {
            var application = new Application()
            {

                Id = addApplicationData.Id,
                UserId = addApplicationData.UserId,
               // User = addApplicationData.User,
                SemesterId = addApplicationData.SemesterId,
               // Semester = addApplicationData.Semester,
                ExamType = addApplicationData.ExamType,
                Status = addApplicationData.Status,
               // CreatedAt = addApplicationData.CreatedAt


            };
            dbContext.Applications.Add(application);
            dbContext.SaveChanges();

            return Ok(application);

        }
        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateApplication(int id, Application updateApplicationData)
        {
            var application = dbContext.Applications.Find(id);

            if (application is null)

            {
                return NotFound();
            }

            application.Id = updateApplicationData.Id;
            application.UserId = updateApplicationData.UserId;
            application.User = updateApplicationData.User;
            application.SemesterId = updateApplicationData.SemesterId;
            application.Semester = updateApplicationData.Semester;
            application.ExamType = updateApplicationData.ExamType;
            application.Status = updateApplicationData.Status;
            application.CreatedAt = updateApplicationData.CreatedAt;

            dbContext.SaveChanges();
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

