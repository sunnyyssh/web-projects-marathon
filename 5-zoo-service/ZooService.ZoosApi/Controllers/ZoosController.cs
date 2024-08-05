using Microsoft.AspNetCore.Mvc;
using ZooService.Model.Zoo;

namespace ZooService.ZoosApi;

[ApiController]
[Route("/api/zoos")]
public class ZoosController(IRepository<ZooInfo> zoosRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IEnumerable<ZooInfo>> GetAllAsync()
    {
        return await zoosRepository.GetAllAsync(false);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return await zoosRepository.GetByIdAsync(id) is { } zoo ? Ok(zoo) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(ZooInfo zoo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await zoosRepository.CreateAsync(zoo);

        return Created();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(ZooInfo zoo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bool success = await zoosRepository.UpdateAsync(zoo);

        return success ? Ok() : BadRequest();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        bool success = await zoosRepository.DeleteAsync(id);

        return success ? Ok() : BadRequest();
    }
}
