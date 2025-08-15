using EXAMINATION.Data;
using EXAMINATION.Models;
using EXAMINATION.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
    public IActionResult GetAllUsers()
    {
        var allUsers = dbContext.Users.ToList();
        return Ok(allUsers);
    }
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetUserById(int id)
    {

        var user = dbContext.Users.Find(id);
        if (user is null)
        {
            return NotFound();
        }
        return Ok(user);

    }

    [HttpPost]
    public IActionResult AddUser(User addUserDto)
    {
        var userEntity = new User()
        {
            Id = addUserDto.Id,
            FirstName = addUserDto.FirstName,
            MiddleName = addUserDto.MiddleName,
            LastName = addUserDto.LastName,
            Email = addUserDto.Email,
            Password = addUserDto.Password,
            PhoneNumber = addUserDto.PhoneNumber,
            PhotoUrl = addUserDto.PhotoUrl,
            // Role =addUserDto.Role,
            StudentProfile = addUserDto.StudentProfile,
            CreatedAt = addUserDto.CreatedAt,
            UpdatedAt = addUserDto.CreatedAt,
        };
            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);

    }

    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateUser(int id,User updateUserDto)

    {
        var user = dbContext.Users.Find(id);
        if (user is null)
        {
            return NotFound();
        }
        //student.Id = updateStudentDto.Id;
        user.Id = updateUserDto.Id;
        user.FirstName = updateUserDto.FirstName;
        user.MiddleName = updateUserDto.MiddleName;
        user.LastName = updateUserDto.LastName;
        user.Email = updateUserDto.Email;
        user.Password = updateUserDto.Password;
        user.PhoneNumber = updateUserDto.PhoneNumber;
        user.PhotoUrl = updateUserDto.PhotoUrl;
        // user.Role =updateUserDto.Role;
        user.StudentProfile = updateUserDto.StudentProfile;
        user.CreatedAt = updateUserDto.CreatedAt;
        user.UpdatedAt = updateUserDto.CreatedAt;
        dbContext.SaveChanges();
        return Ok(user);


    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)

    {
        var user = dbContext.Users.Find(id);
        if (user is null)
        {
            return NotFound();
        }
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
        return Ok();
    }

}

