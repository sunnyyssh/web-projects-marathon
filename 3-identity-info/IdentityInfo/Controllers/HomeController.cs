using Microsoft.AspNetCore.Mvc;

namespace IdentityInfo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}