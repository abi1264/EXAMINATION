using EXAMINATION.Models.DTO;
using EXAMINATION.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace EXAMINATION.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentProfileId { get; set; }
        public StudentProfile? StudentProfile { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        public double MarksObtained { get; set; }
        public string? Grade { get; set; } = string.Empty;
        public ResultStatus Status { get; set; } = ResultStatus.Pending;

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    }
}
