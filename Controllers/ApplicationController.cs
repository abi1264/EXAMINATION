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
           
            dbContext.Applications.Add(addApplicationData);
            dbContext.SaveChanges();

            return Ok(addApplicationData);

        }
        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateApplication(int id, ApplicationDto updateApplicationData)
        {
            var application = dbContext.Applications.Find(id);

            if (application is null)

            {
                return NotFound();
            }
            ApplicationMapper.ApplyPatch(updateApplicationData, application);

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

