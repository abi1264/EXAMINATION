
using Microsoft.EntityFrameworkCore;
using EXAMINATION.Models.DTO;
using EXAMINATION.Models;
namespace EXAMINATION.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<StudentProfile> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }

        public DbSet<Semester> Semesters { get; set; }
        public DbSet<AcademicProgram> Programs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<ElectiveSubject> Electives { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(c => c.Type)
                .HasConversion<string>();

            // --------- StudentProfile Relationships ---------
            modelBuilder.Entity<StudentProfile>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentProfile>()
                .HasOne(s => s.Program)
                .WithMany()
                .HasForeignKey(s => s.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentProfile>()
                .HasOne(s => s.Semester)
                .WithMany()
                .HasForeignKey(s => s.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            // --------- Application Relationships ---------
            modelBuilder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Program)
                .WithMany()
                .HasForeignKey(a => a.ProgramId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Semester)
                .WithMany()
                .HasForeignKey(a => a.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
