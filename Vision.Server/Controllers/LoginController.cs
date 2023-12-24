//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Vision.Server.DTO;
//using Vision.Server.DTO.CreateDTOs;
//using Vision.Server.Models;

//namespace Vision.Server.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class LoginController : Controller
//    {
//        private readonly VisionDbContext _context;

//        public LoginController(VisionDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("{password}", Name = "Login")]
//        public async Task<ActionResult<string>> Login(string password, LoginDTO loginDTO)
//        {
//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.email);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            PasswordHasher passwordHasher = new PasswordHasher();
//            if (passwordHasher.VerifyPassword(user.Password, password))
//            {
//                return Ok(new { Message = "Login successful." });
//            }

//            return Unauthorized(new { Message = "Login failed. Invalid username or password." });
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vision.Server.DTO;
using Vision.Server.Models;
using Microsoft.AspNetCore.Identity; // Include this for using Identity's PasswordHasher

namespace Vision.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly VisionDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginController(VisionDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("")] // Changed from [HttpGet] to [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO) // Removed the email route parameter
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDTO.password);
            if (result == PasswordVerificationResult.Success)
            {
                return Ok(new { Message = "Login successful." });
            }

            return Unauthorized(new { Message = "Login failed. Invalid username or password." });
        }
    }
}

