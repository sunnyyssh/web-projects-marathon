using MagicTwins.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicTwins.Left.Controllers;

[Route("/api/left")]
[Authorize()]
[ApiController]
public sealed class LeftController : ControllerBase
{
    [HttpGet("index")]
    public IActionResult Index()
    {
        var user = User.Claims.ExtractUser();
        
        return Ok(user);
    }
}