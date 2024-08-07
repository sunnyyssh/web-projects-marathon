using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Movies.Api.OptionsSetup;

namespace Movies.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("/api/transparent")]
public class TransparentController : ControllerBase
{
    [HttpGet("jwt")]
    public string GetJwt([FromServices] IOptions<JwtOptions> jwtOptionsHolder, IOptions<JwtBearerOptions> jwtBearerOptionsHolder)
    {
        var jwtOptions = jwtOptionsHolder.Value;
        var jwtBearerOptions = jwtBearerOptionsHolder.Value;
        
        return "ok";
    }
}