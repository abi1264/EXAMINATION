
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.DTO;
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
        public DbSet<Course>Courses { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<ElectiveSubject> Electives { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }

}
