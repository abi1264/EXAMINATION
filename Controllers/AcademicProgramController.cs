using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EXAMINATION.Data;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetProgramData()
        {
            var programData = await dbContext.Programs.Include(program => program.Semesters).ToListAsync();
            return Ok(programData);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var programData = await dbContext.Programs.Include(program => program.Semesters).FirstOrDefaultAsync(program => program.Id == id);
            if (programData is null)
            {
                return NotFound();

            }
            return Ok(programData);
        }

        [HttpPost]
        public async Task<IActionResult> AddProgramData(AcademicProgram addProgramData)
        {
            var exists = await dbContext.Programs.AnyAsync(s => s.Name == addProgramData.Name);
            if (exists)
            {
                return BadRequest(new { message = $"Program with name '{addProgramData.Name}' already exists." });
            }

            await dbContext.Programs.AddAsync(addProgramData);
            dbContext.SaveChanges();
            return Ok(addProgramData);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePrograms(int id, AcademicProgramDto updateProgramData)
        {
            var program = dbContext.Programs.Find(id);
            if (program is null)
            {
                return NotFound();
            }
            if (!string.IsNullOrWhiteSpace(updateProgramData.Name) && await dbContext.Programs.AnyAsync(p => p.Name == updateProgramData.Name && p.Id != id))
            {
                return BadRequest(new { message = $"Program with name '{updateProgramData.Name}' already exists." });
            }
            AcademicProgramMapper.ApplyPatch(updateProgramData, program);
            dbContext.Programs.Update(program);
            return Ok(program);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProgram(int id)
        {
            var program = dbContext.Programs.Find(id);
            if (program is null)
            {
                return NotFound();
            }
            dbContext.Programs.Remove(program);
            dbContext.SaveChanges();
            return Ok();
        }


    }



}
