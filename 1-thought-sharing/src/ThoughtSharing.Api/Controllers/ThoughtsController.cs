using Microsoft.AspNetCore.Mvc;
using ThoughtSharing.Model;

namespace ThoughtSharing.Controllers;

[ApiController]
[Route("/")]
public class ThoughtsController(ThoughtsDbContext dbContext) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetThought(long id)
    {
        return await dbContext.Thoughts.FindAsync(id) is { } thought ? Ok(thought) : NotFound();
    }
    
    
}