using EXAMINATION.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace EXAMINATION.Models
{
    public class ElectiveSubject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentProfileId { get; set; }
        public StudentProfile? StudentProfile { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public DateTime ChosenAt { get; set; } = DateTime.UtcNow;
    }


}
