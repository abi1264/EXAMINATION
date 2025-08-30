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
            {
                user.FirstName = updateUserDto.FirstName;
            }

            if (updateUserDto.MiddleName != null)
            {
                user.MiddleName = updateUserDto.MiddleName;
            }

            if (updateUserDto.LastName != null)
            {
                user.LastName = updateUserDto.LastName;
            }

            if (updateUserDto.Email != null)
            {
                user.Email = updateUserDto.Email;
            }
            if (updateUserDto.Password != null)
            {
                user.Password = updateUserDto.Password;
            }
            if (updateUserDto.PhoneNumber != null)
            {
                user.PhoneNumber = updateUserDto.PhoneNumber;
            }
            if (updateUserDto.PhotoUrl != null)
            {

                user.PhotoUrl = updateUserDto.PhotoUrl;
            }
            if (updateUserDto.Role != null)
            {
                user.Role = updateUserDto.Role.Value;
            }

            user.UpdatedAt = DateTime.UtcNow;

            //For navigeted studentDto
            if (user.StudentProfile != null)
            {


                if (updateUserDto.StudentProfile != null)
                {

                    if (updateUserDto.StudentProfile.Signature != null)
                    {
                        user.StudentProfile.Signature = updateUserDto.StudentProfile.Signature;
                    }

                    if (updateUserDto.StudentProfile.FatherName != null)
                    {
                        user.StudentProfile.FatherName = updateUserDto.StudentProfile.FatherName;
                    }
                    if (updateUserDto.StudentProfile.MotherName != null)
                    {

                        user.StudentProfile.MotherName = updateUserDto.StudentProfile.MotherName;//for reference type just use .Property_name
                    }


                    if (updateUserDto.StudentProfile.Gender != null)
                    {
                        user.StudentProfile.Gender = updateUserDto.StudentProfile.Gender.Value;

                    }
                    if (updateUserDto.StudentProfile.MaritalStatus != null)
                    {
                        user.StudentProfile.MaritalStatus = updateUserDto.StudentProfile.MaritalStatus.Value;
                    }

                    if (updateUserDto.StudentProfile.DateOfBirth != null)
                    {
                        user.StudentProfile.DateOfBirth = updateUserDto.StudentProfile.DateOfBirth.Value;
                    }

                    // Strings
                    if (updateUserDto.StudentProfile.CollegeName != null)
                    {
                        user.StudentProfile.CollegeName = updateUserDto.StudentProfile.CollegeName;
                    }

                    if (updateUserDto.StudentProfile.CollegeAddress != null)
                    {
                        user.StudentProfile.CollegeAddress = updateUserDto.StudentProfile.CollegeAddress;
                    }

                    // Nullable integers
                    if (updateUserDto.StudentProfile.ProgramId != null)
                    {
                        user.StudentProfile.ProgramId = updateUserDto.StudentProfile.ProgramId.Value;
                    }

                    if (updateUserDto.StudentProfile.SemesterId != null)
                    {
                        user.StudentProfile.SemesterId = updateUserDto.StudentProfile.SemesterId.Value;
                    }

                    // Collections
                    if (updateUserDto.StudentProfile.ElectiveSubjects != null)
                    {
                        user.StudentProfile.ElectiveSubjects = updateUserDto.StudentProfile.ElectiveSubjects;
                    }

                    if (updateUserDto.StudentProfile.Applications != null)
                    {
                        user.StudentProfile.Applications = updateUserDto.StudentProfile.Applications;
                    }

                    if (updateUserDto.StudentProfile.Payments != null)
                    {
                        user.StudentProfile.Payments = updateUserDto.StudentProfile.Payments;
                    }
                }
            }
        }
            
    }
        
}
