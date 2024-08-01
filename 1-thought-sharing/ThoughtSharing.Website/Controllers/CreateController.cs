using Microsoft.AspNetCore.Mvc;
using ThoughtSharing.Model;
using ThoughtSharing.Website.Model;

namespace ThoughtSharing.Website.Controllers;

[Route("create")]
public class CreateController(ThoughtApiClient thoughtApiClient) : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Thought {Thesis = string.Empty});
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Thought thought)
    {
        if (!ModelState.IsValid)
        {
            return View(thought);
        }

        await thoughtApiClient.CreateThoughtAsync(thought);
        
        return View("Summary", thought);
    }
}