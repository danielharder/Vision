using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Vision.Server.Services
{
    public class Authentication
    {
    //    private string GenerateJwtToken(IdentityUser user)
    //    {
    //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
    //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    //        var claims = new[]
    //        {
    //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //    // Add more claims as required
    //};

    //        var token = new JwtSecurityToken(
    //            // issuer: "",  // Optional: Add if validating issuer
    //            // audience: "", // Optional: Add if validating audience
    //            claims: claims,
    //            expires: DateTime.Now.AddHours(3), // Token expiry time
    //            signingCredentials: credentials);

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }

    }
}
