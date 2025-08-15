using EXAMINATION.Models.Entities;

namespace EXAMINATION.Models
{
    public class ElectiveSubject
    {
        public int Id { get; set; }

        public int StudentProfileId { get; set; }
        public StudentProfile StudentProfile { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime ChosenAt { get; set; } = DateTime.UtcNow;
    }


}
