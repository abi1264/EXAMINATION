using EXAMINATION.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace EXAMINATION.Models
{
    public class AcademicProgram
    {
        [Key]
        public int Id { get; set; }
            [Required]
            public string Name { get; set; } = string.Empty;
        [Required]
        
        public double Fee { get; set; }

        public ICollection<Semester> Semesters { get; set; } = new List<Semester>();
        public ICollection<StudentProfile> Students { get; set; } = new List<StudentProfile>();

    }


}
