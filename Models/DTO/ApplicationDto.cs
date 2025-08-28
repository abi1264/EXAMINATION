using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class ApplicationDto
    {
       
       
        public int? SemesterId { get; set; }
        
        public ExamType? ExamType { get; set; }
        public ApplicationStatus? Status { get; set; } = ApplicationStatus.Pending;
       
    }
}
