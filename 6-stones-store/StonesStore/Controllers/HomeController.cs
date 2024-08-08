using Microsoft.AspNetCore.Mvc;
using StonesStore.Model;

namespace StonesStore.Controllers;

[Route("/")]
public class HomeController(IStoneRepository stoneRepository) : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View(stoneRepository.GetStones());
    }
}