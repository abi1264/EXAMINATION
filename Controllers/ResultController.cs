using EXAMINATION.Data;
using Microsoft.AspNetCore.Mvc;
using EXAMINATION.Models;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Enum;
using EXAMINATION.Mappers;
using EXAMINATION.Models.DTO;


namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ResultController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetResultData()
        {
            var resultData = dbContext.Results.ToList();
            return Ok(resultData);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetResultById(int id)
        {
            var resultData = dbContext.Results.Find(id);
            if (resultData is null)
            {
                return NotFound();
            }
            return Ok(resultData);
        }

        [HttpPost]
        public IActionResult AddResultData(Result addResultData)
        {

            dbContext.Results.Add(addResultData);
            dbContext.SaveChanges();
            return Ok(addResultData);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult UpdateResult(int id,ResultDto updateResultData)
        {
            var result = dbContext.Results.Find(id);
            if(result is null)
            {
                return NotFound();
            }

            ResultMapper.ApplyPatch(updateResultData, result);
            dbContext.SaveChanges();
            return Ok(result);


        }


        [HttpDelete]
        public IActionResult DeleteResult(int id)
        {
            var result = dbContext.Results.Find(id);
            if(result is null)
            {
                return NotFound();
            }
            dbContext.Results.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
