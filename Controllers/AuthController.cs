using EXAMINATION.Data;
using EXAMINATION.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net; // You must install the BCrypt.Net-Next NuGet package

namespace EXAMINATION.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtService;
        private readonly ApplicationDbContext _dbContext;

        public AuthController(JwtTokenService jwtService, ApplicationDbContext dbContext)
        {
            _jwtService = jwtService;
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                return BadRequest("Email and password are required.");

            // Find user by email
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            //  Verify password using BCrypt
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
            if (!isPasswordValid)
                return Unauthorized("Invalid email or password.");

            // Combine full name
            var fullName = string.Join(" ", new[] { user.FirstName, user.MiddleName, user.LastName }
                .Where(n => !string.IsNullOrWhiteSpace(n)));

            // Generate JWT
            var token = _jwtService.GenerateToken(user.Id, fullName, user.Role.ToString());

            return Ok(new { token });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
