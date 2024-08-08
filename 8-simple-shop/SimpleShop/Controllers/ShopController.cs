using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.Constants;

namespace SimpleShop.Controllers;

[Authorize(Roles = RolesConstants.AdminAndCustomer)]
[Route("/shop")]
public sealed class ShopController : Controller
{
    [HttpGet("list")]
    public IActionResult ProductsList()
    {
        return View("ProductsList");
    }
}