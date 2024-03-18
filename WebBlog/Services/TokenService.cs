using System.IdentityModel.Tokens.Jwt;
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
        var tokenDescriptor = new SecurityTokenDescriptor();
        var token = localTockenHandler.CreateToken(tokenDescriptor);
        return localTockenHandler.WriteToken(token);
    }
}