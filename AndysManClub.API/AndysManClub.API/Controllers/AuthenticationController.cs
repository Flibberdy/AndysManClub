using Microsoft.AspNetCore.Mvc;

namespace AndysManClub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    [HttpGet]
    public ActionResult Get(string name)
    {
        return Ok($"Hello {name}");
    }
}