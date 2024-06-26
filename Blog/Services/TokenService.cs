using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Services;

//Gera um token
public class TokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // cria instancia do token do tipo jwt
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // encode da chave
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, "alisonjghedin"), //User.Identity.Name
                new (ClaimTypes.Role, "user"), //User.IsInRole
                new (ClaimTypes.Role, "admin"), //User.IsInRole
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        }; // configuracao do token
        var token = tokenHandler.CreateToken(tokenDescriptor); //adiciona configuração ao token
        return tokenHandler.WriteToken(token); //retorna o token criado

    }
}