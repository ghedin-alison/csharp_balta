using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("v1/login")]
    public IActionResult Login()
    {
        var tokenService = new TokenService();
        var token = tokenService.GenerateToken(user: null);

        return Ok(token);

    }
}