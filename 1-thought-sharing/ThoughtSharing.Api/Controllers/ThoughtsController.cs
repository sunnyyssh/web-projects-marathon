using Microsoft.AspNetCore.Mvc;
using ThoughtSharing.Model;

namespace ThoughtSharing.Controllers;

[ApiController]
[Route("/api/thoughts")]
public class ThoughtsController(ThoughtsDbContext dbContext) : ControllerBase
{
    [HttpGet("")]
    public IEnumerable<Thought> GetThoughts()
    {
        return dbContext.Thoughts;
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetThought(long id)
    {
        return await dbContext.Thoughts.FindAsync(id) is { } thought ? Ok(thought) : NotFound();
    }

    [HttpPost("create")]
    public async Task CreateThought(Thought thought)
    {
        thought.Id = 0;  // Setting Id to default to give database an opportunity to set it itself. 
        dbContext.Thoughts.Add(thought);
        await dbContext.SaveChangesAsync();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateThought(Thought thought)
    {
        if (await dbContext.Thoughts.FindAsync(thought.Id) is not { } foundThought)
        {
            return BadRequest("No such Id");
        }

        foundThought.Thesis = thought.Thesis;
        foundThought.Description = thought.Description;
        
        dbContext.Thoughts.Update(foundThought);
        await dbContext.SaveChangesAsync();
        
        return Ok();
    }
}