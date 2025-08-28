namespace EXAMINATION.Models.DTO
{
    public class ElectiveSubjectDto
    {
        public int StudentProfileId { get; set; }
       
        public int CourseId { get; set; }
        public DateTime ChosenAt { get; set; } = DateTime.UtcNow;
    }
}
