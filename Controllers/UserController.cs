using EXAMINATION.Data;
using EXAMINATION.Models;
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
        var allUsers = await dbContext.Users.ToListAsync();
        return Ok(allUsers);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {

        var user = await dbContext.Users
            .Include(Users => Users.StudentProfile)
            .FirstOrDefaultAsync(Users => Users.Id == id);
        if (user is null)
        {
            return NotFound();
        }
        return Ok(user);

    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User addUserDto)
    {
        //check if email already exists
        var exists = await dbContext.Users.AnyAsync(u => u.Email == addUserDto.Email);
        if (exists)
        {
            return BadRequest("Email already exists!");
        }
        await dbContext.Users.AddAsync(addUserDto);

        await dbContext.SaveChangesAsync();
        return Ok(addUserDto);

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
        var user =await dbContext.Users.FindAsync(id);
        if (user is null)
        {
            return NotFound();
        }
       dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return Ok();
    }

}

