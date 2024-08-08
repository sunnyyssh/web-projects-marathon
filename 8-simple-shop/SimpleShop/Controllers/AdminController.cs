using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Constants;

namespace SimpleShop.Controllers;

[Authorize(Roles = RolesConstants.Admin)]
[Route("/admin")]
public sealed class AdminController : Controller
{
    [HttpGet("hehe")]
    public string GetHeheMessage()
    {
        return "hehe";
    }
}