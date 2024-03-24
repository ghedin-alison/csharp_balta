using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebBlog.Models;

namespace WebBlog.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        var localTockenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.Name, "alisonjg"), // User.Identity.Name
                new Claim(ClaimTypes.Role, "admin"), // User.IsInRole
                new Claim(ClaimTypes.Role, "user"), // User.IsInRole
            }),
            Expires = DateTime.UtcNow.AddDays(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            
        };
        var token = localTockenHandler.CreateToken(tokenDescriptor);
        return localTockenHandler.WriteToken(token);
    }
}