namespace EXAMINATION.Models
{
    public class AddStudentDto
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public string? Signature { get; set; }
    }
}
