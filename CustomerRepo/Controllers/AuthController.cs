using CustomerRepo.Data;
using CustomerRepo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CustomerRepo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // Hash the input password for comparison
            var hashedPassword = HashPassword(request.Password);

            // Check if user exists and password matches
            var user = await _dbContext.BCO_Users
                .FirstOrDefaultAsync(u => u.UserName == request.Username && u.UserPass == hashedPassword);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate a token (simplified for example purposes)
            var token = GenerateToken(user);

            return Ok(new LoginResponse
            {
                UserId = user.UserID,
                Username = user.UserName,
                Token = token
            });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private string GenerateToken(BCO_User user)
        {
            // Replace this with proper JWT or other token generation
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user.UserName}:{DateTime.UtcNow}"));
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
