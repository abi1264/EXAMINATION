using EXAMINATION.Data;
using Microsoft.AspNetCore.Mvc;
using EXAMINATION.Models;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;

namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectiveSubjectController: ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        public ElectiveSubjectController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetElectiveSubject()
        {
            var elective = dbContext.Electives.ToList();
            return Ok(elective);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetElectiveById(int id)
        {
            var elective = dbContext.Electives.Find(id);
            if (elective is null)
            {
                return NotFound();
            }
            return Ok(elective);
        }

        [HttpPost]
        public IActionResult AddElectiveData(ElectiveSubject addElectiveData)
        {
           
            dbContext.Electives.Add(addElectiveData);
            dbContext.SaveChanges();
            return Ok(addElectiveData);

        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateElectives(int id, ElectiveSubjectDto updateElectiveData)
        {
            var elective = dbContext.Electives.Find(id);
            if(elective is null)
            {
                return NotFound();
            }

          
            ElectiveSubjectMapper.ApplyPatch(updateElectiveData, elective);

            dbContext.SaveChanges();
            return Ok(elective);

        }

        [HttpDelete]
        public IActionResult DeleteElective(int id)
        {
            var elective = dbContext.Electives.Find(id);
            if(elective is null)
            {
                return NotFound();
            }
            dbContext.Electives.Remove(elective);
            dbContext.SaveChanges();
            return Ok();

        }
    }
}
