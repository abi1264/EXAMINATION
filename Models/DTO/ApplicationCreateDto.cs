
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models.DTO;
public class ApplicationCreateDto
{
    public int UserId { get; set; }
    public int SemesterId { get; set; }
    public ExamType ExamType { get; set; }
    public List<int> CourseIds { get; set; } = new();
}
