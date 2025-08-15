
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Entities;
namespace EXAMINATION.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StudentProfile> Students { get; set; }
    }
}
