using EXAMINATION.Data;
using Microsoft.AspNetCore.Mvc;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using EXAMINATION.Models.DTO;
using EXAMINATION.Mappers;


namespace EXAMINATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task <IActionResult> GetCourseData()
        {
            var courseData = await dbContext.Courses.
                Include(course=>course.Semester)
                .ThenInclude(semester=>semester.Program).ToListAsync();
            return Ok(courseData);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult>GetCourseData(int id)
        {
            var courseData = await dbContext.Courses
                .Include(course => course.Semester)
                .ThenInclude(semester=>semester.Program)
                .FirstOrDefaultAsync(course => course.Id == id);
            if (courseData is null)
            {
                return NotFound();

            }
            return Ok(courseData);
        }

        [HttpPost]
        public IActionResult AddCourseData(Course addCourseData)
        {

            dbContext.Courses.Add(addCourseData);
            dbContext.SaveChanges();
            return Ok(addCourseData);

        }

        [HttpPatch]
        [Route("{id:int}")]

        public IActionResult UpdateCourseData(int id, CourseDto updateCourseData)
        {
            var course = dbContext.Courses.Find(id);
            if (course is null)
            {
                return NotFound();
            }
            CourseMapper.ApplyPatch(updateCourseData, course);
            dbContext.SaveChanges();
            return Ok(course);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCourseData(int id)
        {
            var course = dbContext.Courses.Find(id);
            if (course is null)
            {
                return NotFound();
            }
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
