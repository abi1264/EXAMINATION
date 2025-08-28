using EXAMINATION.Models.DTO;
using EXAMINATION.Models;
namespace EXAMINATION.Mappers
{
    static public class UserMapper
    {
        static public void ApplyPatch(UserDto updateUserDto,User user)
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
            if (updateUserDto.PhoneNumber!=null)
            {
            user.PhoneNumber = updateUserDto.PhoneNumber;     
            }
            if (updateUserDto.PhotoUrl != null)
            {

                user.PhotoUrl = updateUserDto.PhotoUrl;
            }
            if (updateUserDto.Role != null)
            {
                user.Role = updateUserDto.Role;
            }
           
            user.UpdatedAt = DateTime.UtcNow;
            
        }
    }
}
