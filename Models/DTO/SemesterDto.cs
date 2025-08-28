namespace EXAMINATION.Models.DTO
{
    public class SemesterDto
    {
        public string? Name { get; set; } = null!;
        public double? Fee { get; set; }

        public int? ProgramId { get; set; }
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
       
    }
}
