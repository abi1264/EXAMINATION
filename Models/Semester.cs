using EXAMINATION.Models.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace EXAMINATION.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Fee { get; set; }

        public int ProgramId { get; set; }
        public AcademicProgram? Program { get; set; } 

       public ICollection<Course>?Courses { get; set; } = new List<Course>();
       public ICollection<StudentProfile> ?Students { get; set; } = new List<StudentProfile>();
       public ICollection<Application> ?Applications { get; set; } = new List<Application>();
    }

}
