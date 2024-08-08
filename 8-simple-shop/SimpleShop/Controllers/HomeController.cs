using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Controllers;

[Route("/")]
[Route("/home")]
public class HomeController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}