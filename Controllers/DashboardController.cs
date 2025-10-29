using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Data;
using EXAMINATION.Models.Enum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EXAMINATION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public DashboardController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("total-users")]
        public async Task<IActionResult> GetTotalUsers()
        {
            var totalUser = await _dbcontext.Users.CountAsync();
            return Ok(new { totalUsers = totalUser });
        }

        [HttpGet("total-programs")]
        public async Task<IActionResult> GetTotalPrograms()
        {
            var totalProgram = await _dbcontext.Programs.CountAsync();
            return Ok(new { totalPrograms = totalProgram });
        }

        [HttpGet("total-courses")]
        public async Task<IActionResult> GetTotalCourses()
        {
            var totalCourses = await _dbcontext.Courses.CountAsync();
            return Ok(new { totalCourses = totalCourses });
        }

        [HttpGet("students-by-program")]
        public async Task<IActionResult> GetStudentsByProgram()
        {
            var studentsByProgram = await _dbcontext.Users
                .Where(u => u.Role == Role.Student)
                .GroupBy(u => u.StudentProfile.Program.Name)
                .Select(g => new { Program = g.Key, Count = g.Count() })
                .ToListAsync();

            var response = studentsByProgram
                .Select(p => new Dictionary<string, int> { { p.Program, p.Count } });

            return Ok(response);
        }

        [HttpGet("application-status")]
        public async Task<IActionResult> GetApplicationStatusDistribution()
        {
            var statusCounts = await _dbcontext.Applications
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToListAsync();

            var allStatuses = Enum.GetValues(typeof(ApplicationStatus))
                .Cast<ApplicationStatus>()
                .Select(s => new
                {
                    Status = s.ToString(),
                    Count = statusCounts.FirstOrDefault(x => x.Status == s)?.Count ?? 0
                })
                .Select(s => new Dictionary<string, int> { { s.Status, s.Count } });

            return Ok(allStatuses);
        }
    }
}
