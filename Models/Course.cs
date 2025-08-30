using EXAMINATION.Models.Enum;
using System.ComponentModel.DataAnnotations;
namespace EXAMINATION.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public CourseType Type { get; set; }
        [Required]
        public int Credit { get; set; }
        [Required]

        public int SemesterId { get; set; }
        public Semester? Semester { get; set; }
        public ICollection<Result> Results { get; set; } = new List<Result>();

    }

}
