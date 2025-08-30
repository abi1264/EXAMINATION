using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using EXAMINATION.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace EXAMINATION.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  int UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public string Signature { get; set; } = string.Empty;

        [Required]
        public string FatherName { get; set; } = string.Empty;
        [Required]
        public string MotherName { get; set; } = string.Empty;
        [Required]
        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]

        public string CollegeName { get; set; } = string.Empty;
        public string CollegeAddress { get; set; } = string.Empty;
        [Required]
        public int ProgramId { get; set; }
        public AcademicProgram? Program { get; set; }
        [Required]
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; } 
        public ICollection<ElectiveSubject> ElectiveSubjects { get; set; } = new List<ElectiveSubject>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Result> Results { get; set; } = new List<Result>();


    }
}
