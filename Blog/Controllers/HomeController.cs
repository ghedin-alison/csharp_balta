using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("health-check")]
    public IActionResult Get() => Ok(new {Apiversion = "1.0.0", Message= "Api online"});

}