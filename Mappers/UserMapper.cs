using EXAMINATION.Models.DTO;
using EXAMINATION.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace EXAMINATION.Mappers
{
    static public class UserMapper
    {
        static public void ApplyPatch(UserDto updateUserDto, User user)
        {
            if (updateUserDto.FirstName != null)
                user.FirstName = updateUserDto.FirstName;

            if (updateUserDto.MiddleName != null)
                user.MiddleName = updateUserDto.MiddleName;

            if (updateUserDto.LastName != null)
                user.LastName = updateUserDto.LastName;

            if (updateUserDto.Email != null)
                user.Email = updateUserDto.Email;

            if (updateUserDto.Password != null)
                user.Password = updateUserDto.Password;

            if (updateUserDto.PhoneNumber != null)
                user.PhoneNumber = updateUserDto.PhoneNumber;

            if (updateUserDto.PhotoUrl != null)
                user.PhotoUrl = updateUserDto.PhotoUrl;

            if (updateUserDto.Role != null)
                user.Role = updateUserDto.Role.Value;

            user.UpdatedAt = DateTime.UtcNow;

            if (user.StudentProfile != null && updateUserDto.StudentProfile != null)
            {
                var spDto = updateUserDto.StudentProfile;
                var sp = user.StudentProfile;

                if (spDto.Signature != null)
                    sp.Signature = spDto.Signature;

                if (spDto.FatherName != null)
                    sp.FatherName = spDto.FatherName;

                if (spDto.MotherName != null)
                    sp.MotherName = spDto.MotherName;

                if (spDto.Gender != null)
                    sp.Gender = spDto.Gender.Value;

                if (spDto.MaritalStatus != null)
                    sp.MaritalStatus = spDto.MaritalStatus.Value;

                if (spDto.DateOfBirth != null)
                {
                    // Ensure UTC before saving
                    sp.DateOfBirth = DateTime.SpecifyKind(spDto.DateOfBirth.Value, DateTimeKind.Utc);
                }

                if (spDto.CollegeName != null)
                    sp.CollegeName = spDto.CollegeName;

                if (spDto.CollegeAddress != null)
                    sp.CollegeAddress = spDto.CollegeAddress;

                if (spDto.ProgramId != null)
                    sp.ProgramId = spDto.ProgramId.Value;

                if (spDto.SemesterId != null)
                    sp.SemesterId = spDto.SemesterId.Value;

                if (spDto.ElectiveSubjects != null)
                    sp.ElectiveSubjects = spDto.ElectiveSubjects;

                if (spDto.Applications != null)
                    sp.Applications = spDto.Applications;

                if (spDto.Payments != null)
                    sp.Payments = spDto.Payments;
            }
        }

    }

}
