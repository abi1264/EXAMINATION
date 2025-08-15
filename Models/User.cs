using EXAMINATION.Models.Entities;
using System.Data;

namespace EXAMINATION.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? PhotoUrl { get; set; }
        //public Role Role { get; set; } = Role.Student;
        public StudentProfile? StudentProfile { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }


}
