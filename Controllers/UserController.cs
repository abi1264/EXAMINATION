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
        dbContext.Users.Add(addUserDto);
            dbContext.SaveChanges();
            return Ok(addUserDto);

    }

    [HttpPatch]
    [Route("{id:int}")]
    public async Task<IActionResult>UpdateUser(int id, UserDto updateUserDto)

    {
        var user =await dbContext.Users.Include(u => u.StudentProfile).FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
        {
            return NotFound();
        }
        UserMapper.ApplyPatch(updateUserDto,user);
        dbContext.SaveChanges();
        return Ok(user);


    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id)

    {
        var user =await dbContext.Users.FindAsync(id);
        if (user is null)
        {
            return NotFound();
        }
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
        return Ok();
    }

}

