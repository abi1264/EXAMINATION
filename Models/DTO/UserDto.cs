using EXAMINATION.Models.Enum;

namespace EXAMINATION.Models.DTO
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; } 
        public string? LastName { get; set; }
        public string? Email { get; set; } 
        public string? Password { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? PhotoUrl { get; set; } 
        public Role? Role { get; set; } 

        public StudentDto? StudentProfile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }

    public class UserDtoCreate
    {

        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public Role Role { get; set; } = Role.Student;

        public StudentDtoCreate? StudentProfile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}
