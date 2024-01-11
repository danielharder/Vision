using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vision.Server.DTO;
using Vision.Server.Models;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly VisionDbContext _context;

    public LoginController(IConfiguration configuration, VisionDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] LoginDTO userCredentials)
    {
        // Validate the user credentials here (e.g., against a database)
        bool isValidUser = await CheckUserCredentials(userCredentials);

        if (!isValidUser)
        {
            return Unauthorized();
        }

        var token = GenerateJSONWebToken(userCredentials);
        return Ok(new { token });
    }

    private string GenerateJSONWebToken(LoginDTO userCredentials)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            //new Claim(JwtRegisteredClaimNames.Sub, LoginDTO.Email),
            new Claim(JwtRegisteredClaimNames.Email, userCredentials.Email),
            // Add other claims as needed
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<bool> CheckUserCredentials(LoginDTO userCredentials)
    {
        //var user = await _context.Users.FindAsync();
        var user = await _context.Users.FirstOrDefaultAsync(userEntity => userEntity.Email.Equals(userCredentials.Email));
        //Where(userEntity => userEntity.Email.Equals(userCredentials.Email));
        if (user == null)
        {
            return false;
        }
        if (user.Password.Equals(userCredentials.Password))
        {
            return true;
        }
        return false;
    }
}