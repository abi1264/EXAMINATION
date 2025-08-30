namespace EXAMINATION.Models.DTO
{
    public class SemesterDto
    {
        public string? Name { get; set; } = string.Empty;
        public double? Fee { get; set; }

        public int? ProgramId { get; set; }
        public ICollection<Course>Courses { get; set; } = new List<Course>();
       
    }
}
