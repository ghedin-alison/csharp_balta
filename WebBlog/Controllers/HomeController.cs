using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers;

[ApiController]
[Route("")]
public class HomeController: ControllerBase
{
    [HttpGet("health-check")]
    public IActionResult Get()
        => Ok();
}