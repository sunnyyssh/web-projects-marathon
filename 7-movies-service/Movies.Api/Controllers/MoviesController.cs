using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Movies.Api.OptionsSetup;

namespace Movies.Api.Controllers;

[Authorize]
[ApiController]
[Route("/api/movies")]
public class MoviesController(IOptions<JwtOptions> jwtOptions) : ControllerBase
{
    [HttpGet("ura")]
    public IActionResult Ura()
    {
        var opts = jwtOptions.Value;
        return Ok("ura");
    }
}