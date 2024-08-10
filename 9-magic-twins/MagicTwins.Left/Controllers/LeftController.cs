using MagicTwins.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicTwins.Left.Controllers;

[Route("/api/left")]
[Authorize()]
[ApiController]
public sealed class LeftController : ControllerBase
{
    private readonly IToggleService _toggleService;

    public LeftController(IToggleService toggleService)
    {
        _toggleService = toggleService;
    }

    [HttpGet("isToggled")]
    public async Task<bool> IsToggled()
    {
        var user = User.Claims.ExtractUser();

        return await _toggleService.IsToggledAsync(user.Id);
    }

    [HttpPut("toggle")]
    public async Task<bool> Toggle()
    {
        var user = User.Claims.ExtractUser();

        return await _toggleService.ToggleAsync(user.Id);
    }
}