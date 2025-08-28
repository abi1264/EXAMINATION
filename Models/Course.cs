using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public CourseType Type { get; set; }
        public int Credit { get; set; }

        public int SemesterId { get; set; }
        public Semester? Semester { get; set; } = null!;
        public ICollection<Result> Results { get; set; } = new List<Result>();

    }

}
