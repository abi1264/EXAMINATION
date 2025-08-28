using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } 
        public string Signature { get; set; }

        public string FatherName { get; set; } = null!;
        public string MotherName { get; set; } = null!;
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CollegeName { get; set; } = null!;
        public string CollegeAddress { get; set; } = null!;

        public int ProgramId { get; set; }
        public AcademicProgram Program { get; set; } = null!;

        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
        public ICollection<ElectiveSubject> ElectiveSubjects { get; set; } = new List<ElectiveSubject>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Result> Results { get; set; } = new List<Result>();


    }
}
