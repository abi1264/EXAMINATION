using EXAMINATION.Models.DTO;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace EXAMINATION.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Fee { get; set; }
        [Required]
        public int ProgramId { get; set; }
        public AcademicProgram? Program { get; set; } 

       public ICollection<Course>?Courses { get; set; } = new List<Course>();
       public ICollection<StudentProfile> ?Students { get; set; } = new List<StudentProfile>();
       public ICollection<Application> ?Applications { get; set; } = new List<Application>();
    }

}
