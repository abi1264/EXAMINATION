using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models
   
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int SemesterId { get; set; }
        public Semester? Semester { get; set; } 
       public ExamType ExamType { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
