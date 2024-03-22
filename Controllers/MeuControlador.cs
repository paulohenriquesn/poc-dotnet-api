using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api")]
public class MeuControlador : ControllerBase
{
    [HttpGet("v1/hello")]
    public IActionResult HelloWorld() {
        return Ok("Hello World!");
    }
}
