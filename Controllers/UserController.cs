using EXAMINATION.Data;
using EXAMINATION.Models;
using EXAMINATION.Models.Enum;
using EXAMINATION.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EXAMINATION.Mappers;
//localhost:xxxx/api/StudentProfile
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;

    public UserController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var allUsers = await dbContext.Users.Where(user => user.Role == Role.Student)
            .Include(Users => Users.StudentProfile)
            .ThenInclude(StudentProfile => StudentProfile.Program)
             .Include(Users => Users.StudentProfile)
        .ThenInclude(StudentProfile => StudentProfile.Semester).
        ToListAsync();
        return Ok(allUsers);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {

        var user = await dbContext.Users
            .Include(Users => Users.StudentProfile)
            .ThenInclude(StudentProfile => StudentProfile.Program)
             .Include(Users => Users.StudentProfile)
        .ThenInclude(StudentProfile => StudentProfile.Semester)
            .FirstOrDefaultAsync(Users => Users.Id == id);
        if (user is null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDtoCreate addUserDto)
    {
        //check if email already exists
        var exists = await dbContext.Users.AnyAsync(u => u.Email == addUserDto.Email);
        if (exists)
        {
            return BadRequest("Email already exists!");
        }
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password);

        StudentProfile? studentProfile = null;
        if (addUserDto.StudentProfile != null)
        {
            var dto = addUserDto.StudentProfile;
            studentProfile = new StudentProfile
            {
                Signature = dto.Signature,
                FatherName = dto.FatherName,
                MotherName = dto.MotherName,
                Gender = dto.Gender,
                MaritalStatus = dto.MaritalStatus,
                DateOfBirth = dto.DateOfBirth,
                CollegeName = dto.CollegeName,
                CollegeAddress = dto.CollegeAddress,
                ProgramId = dto.ProgramId,
                SemesterId = dto.SemesterId
            };
        }

        var user = new User
        {
            FirstName = addUserDto.FirstName,
            MiddleName = addUserDto.MiddleName,
            LastName = addUserDto.LastName,
            Email = addUserDto.Email,
            Password = hashedPassword,
            PhoneNumber = addUserDto.PhoneNumber,
            PhotoUrl = addUserDto.PhotoUrl,
            Role = addUserDto.Role, // default if null
            StudentProfile = studentProfile,
            CreatedAt = DateTime.UtcNow
        };

        await dbContext.Users.AddAsync(user);

        await dbContext.SaveChangesAsync();
        return Ok(
        new
        {
            user.Id,
            user.FirstName,
            user.Email,
            user.Role,
            user.CreatedAt
        }
        );

    }

    [HttpPatch]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateUser(int id, UserDto updateUserDto)

    {
        var user = await dbContext.Users.Include(u => u.StudentProfile).FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            return NotFound();
        }
        //prevent duplicate email
        if (!string.IsNullOrEmpty(updateUserDto.Email) &&
                await dbContext.Users.AnyAsync(u => u.Email == updateUserDto.Email && u.Id != id))
        {
            return BadRequest("Email already exists");
        }
        UserMapper.ApplyPatch(updateUserDto, user);
        await dbContext.SaveChangesAsync();
        return Ok(user);


    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)

    {
        var user = await dbContext.Users.FindAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return Ok();
    }

}

