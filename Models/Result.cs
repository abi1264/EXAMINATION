using EXAMINATION.Models.Entities;

namespace EXAMINATION.Models
{
    public class Result
    {
        public int Id { get; set; }

        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public double MarksObtained { get; set; }
        public string Grade { get; set; } = null!;
       // public ResultStatus Status { get; set; } = ResultStatus.Pending;

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    }
}
