namespace EXAMINATION.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
       // public ExamType ExamType { get; set; }
        //public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }


}
