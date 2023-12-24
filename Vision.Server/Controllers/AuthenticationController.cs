using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vision.Server.DTO;
using Vision.Server.DTO.CreateDTOs;
using Vision.Server.Models;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthenticationController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationDTO model)
    {
        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email,
            Password = model.password,
            Description = model.Description            
        };

        var result = await _userManager.CreateAsync(user, model.password);

        if (result.Succeeded)
        {
            // Auto-sign in the user after registration
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(new { Message = "User registered and signed in successfully." });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(new { Message = "Login successful" });
        }

        return Unauthorized("Invalid login attempt");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Password reset successfully" });
            }
            return BadRequest(result.Errors);
        }

        return BadRequest("Invalid current password");
    }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Message = "Logged out successfully" });
    }
}
