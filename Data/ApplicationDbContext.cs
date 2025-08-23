
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.Entities;
using EXAMINATION.Models;
namespace EXAMINATION.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<StudentProfile> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<AcademicProgram> Programs { get; set; }
    }

}
