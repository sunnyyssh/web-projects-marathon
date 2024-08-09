using MagicTwins.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MagicTwins.Auth.Controllers;

[Route("/api/account")]
[RequireHttps]
[ApiController]
public sealed class AccountController : ControllerBase
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(
        IJwtProvider jwtProvider,
        UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager)
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetTokenAsync(SignInDto signInDto)
    {
        var user = await _userManager.FindByNameAsync(signInDto.UserName);

        if (user is null)
        {
            return BadRequest("User does not exist. Try to sign up.");
        }
        
        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, signInDto.Password, false);

        if (!signInResult.Succeeded)
        {
            return BadRequest("Signing in failed due to some reasons.");
        }

        var token = _jwtProvider.Create(user);
        return Ok(token);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> CreateUserAsync(SignUpDto signUpDto)
    {
        var user = new IdentityUser(signUpDto.UserName);
        var createResult = await _userManager.CreateAsync(user, signUpDto.Password);

        if (!createResult.Succeeded)
        {
            return BadRequest(createResult.Errors);
        }

        var token = _jwtProvider.Create(user);
        return Ok(token);
    }
}