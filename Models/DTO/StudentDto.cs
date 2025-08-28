using EXAMINATION.Models.Enum;
namespace EXAMINATION.Models.DTO;
public class StudentDto
{
   
    public string? Signature { get; set; }
    public string? FatherName { get; set; } 
    public string? MotherName { get; set; } 
    public Gender? Gender { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string? CollegeName { get; set; } 
    public string? CollegeAddress { get; set; } 
    public int? ProgramId { get; set; }
   

    public int? SemesterId { get; set; }
   
    public ICollection<ElectiveSubject>ElectiveSubjects { get; set; } = new List<ElectiveSubject>();

     public ICollection<Application> Applications { get; set; } = new List<Application>();
     public ICollection<Payment> Payments { get; set; } = new List<Payment>();
     public ICollection<ResultDto> Results { get; set; } = new List<ResultDto>();

}
