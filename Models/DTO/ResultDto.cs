using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class ResultDto
    {
        public int? StudentProfileId { get; set; }
        public int? CourseId { get; set; }
        public double? MarksObtained { get; set; }
        public string? Grade { get; set; } = null!;
        public ResultStatus? Status { get; set; } = ResultStatus.Pending;

        public DateTime? PublishedAt { get; set; } = DateTime.UtcNow;
    }
}
