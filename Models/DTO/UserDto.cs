using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class UserDto
    {
        public string? FirstName { get; set; } = String.Empty;
        public string? MiddleName { get; set; } = String.Empty;
        public string? LastName { get; set; } = String.Empty;
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        public Role Role { get; set; } = Role.Student;
        public StudentProfile? StudentProfile { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        
    }

}
