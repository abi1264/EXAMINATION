using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;

namespace EXAMINATION.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    
    public class AcademicProgramController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        
        public AcademicProgramController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public IActionResult GetProgramData()
        {
            var programData = dbContext.Programs.ToList();
            return Ok(programData);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProgramById(int id)
        {
            var programData = dbContext.Programs.Find(id);
            if(programData is null)
            {
                return NotFound();

            }
            return Ok(programData);
        }

        [HttpPost]
        public IActionResult AddProgramData(AcademicProgram addProgramData)
        {
            var program = new AcademicProgram()
            {
                //Id = addProgramData.Id,
                Name = addProgramData.Name,
                Fee = addProgramData.Fee,
                Semesters = addProgramData.Semesters,
                //Students = addProgramData.Students

            };
            dbContext.Programs.Add(program);
            dbContext.SaveChanges();
            return Ok(program);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdatePrograms(int id, AcademicProgram updateProgramData)
        {
            var program = dbContext.Programs.Find(id);
            if(program is null)
            {
                return NotFound();
            }
           // program.Id = updateProgramData.Id;
            program.Name = updateProgramData.Name;
            program.Fee = updateProgramData.Fee;
           // program.Students = updateProgramData.Students;

            dbContext.Programs.Update(program);
            return Ok(program);


        }

        [HttpDelete]
        public IActionResult DeleteProgram(int id)
        {
            var program = dbContext.Programs.Find(id);
            if(program is null)
            {
                return NotFound();
            }
            dbContext.Programs.Remove(program);
            dbContext.SaveChanges();
            return Ok();
        }


    }

 

}
