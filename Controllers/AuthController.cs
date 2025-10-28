using EXAMINATION.Data;
using EXAMINATION.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            // Extract user ID from custom claim
            var userIdClaim = User.FindFirst("userId")?.Value;
            if (userIdClaim == null)
                return Unauthorized("Invalid token.");

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID.");

            // Fetch user from database
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound("User not found.");

            return Ok(new
            {
                user.Id,
                user.FirstName,
                user.MiddleName,
                user.LastName,
                user.Email,
                user.Role
            });
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

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(1) // 1-hour expiry
            };

            Response.Cookies.Append("auth_token", token, cookieOptions);

            return Ok(new { message = "Login successful" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (Request.Cookies.ContainsKey("auth_token"))
            {
                Response.Cookies.Append("auth_token", string.Empty, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(-1) 
                });
            }

            return Ok(new { message = "Logout successful" });
        }

    }

    public class LoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
