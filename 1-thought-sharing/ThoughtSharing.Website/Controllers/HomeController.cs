using Microsoft.AspNetCore.Mvc;
using ThoughtSharing.Website.Model;

namespace ThoughtSharing.Website.Controllers;

public class HomeController(ThoughtApiClient thoughtApiClient) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var thoughts = await thoughtApiClient.GetThoughtsAsync();
        return View(thoughts);
    }

    [HttpGet]
    public async Task<IActionResult> Thought(long id)
    {
        return await thoughtApiClient.GetThoughtAsync(id) is not { } thought 
            ? View("ThoughtNotFound") 
            : View("Thought", thought);
    }
}