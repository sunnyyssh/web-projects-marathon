using Microsoft.AspNetCore.Mvc;
using ZooService.Model.Zoo;

namespace ZooService.ZoosApi;

[ApiController]
[Route("/api/tickets")]
public class TicketsController(IRepository<Ticket> zoosRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        return await zoosRepository.GetAllAsync(false);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return await zoosRepository.GetByIdAsync(id) is { } ticket ? Ok(ticket) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(Ticket ticket)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await zoosRepository.CreateAsync(ticket);

        return Created();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(Ticket ticket)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bool success = await zoosRepository.UpdateAsync(ticket);

        return success ? Ok() : BadRequest();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        bool success = await zoosRepository.DeleteAsync(id);

        return success ? Ok() : BadRequest();
    }
}
