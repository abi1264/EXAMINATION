using EXAMINATION.Models.Enum;
using System.ComponentModel.DataAnnotations;
namespace EXAMINATION.Models
   
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }
        [Required]
        public ExamType ExamType { get; set; }

        [Required]
        public int ProgramId { get; set; }

       public AcademicProgram? Program { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

        [Required]
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
