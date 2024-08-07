using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("api/identity")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IJwtProvider _jwtProvider;

    public IdentityController(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenRegistrationRequest request)
    {
        string generatedJwtToken = _jwtProvider.Generate(request);

        return Ok(generatedJwtToken);
    }
}
