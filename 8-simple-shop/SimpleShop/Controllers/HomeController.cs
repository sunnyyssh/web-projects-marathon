using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Controllers;

[AllowAnonymous]
[Route("/")]
[Route("/home")]
public sealed class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}