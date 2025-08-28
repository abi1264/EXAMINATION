using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class CourseDto
    {
       
        public string? Name { get; set; } 
        public string? Code { get; set; }
        public CourseType? Type { get; set; }
        public int? Credit { get; set; }

        public int? SemesterId { get; set; }
       
        public ICollection<ResultDto> Results { get; set; } = new List<ResultDto>();
    }
}
