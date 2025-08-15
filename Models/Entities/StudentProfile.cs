namespace EXAMINATION.Models.Entities
{
    public class StudentProfile
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
       // public required User User { get; set; } = null;
        public string? Signature { get; set; }

    }
}
