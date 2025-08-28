using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;

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
           
            dbContext.Programs.Add(addProgramData);
            dbContext.SaveChanges();
            return Ok(addProgramData);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdatePrograms(int id, AcademicProgramDto updateProgramData)
        {
            var program = dbContext.Programs.Find(id);
            if(program is null)
            {
                return NotFound();
            }

            AcademicProgramMapper.ApplyPatch(updateProgramData, program);
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
