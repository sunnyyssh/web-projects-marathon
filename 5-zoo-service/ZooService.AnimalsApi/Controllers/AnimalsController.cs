using Microsoft.AspNetCore.Mvc;
using ZooService.Model.Animals;

namespace ZooService.AnimalsApi;

[ApiController]
[Route("/api/animals")]
public class AnimalsController(IAnimalsRepository animalsRepository) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IEnumerable<AnimalInfo>> GetAllAsync()
    {
        return await animalsRepository.GetAllAsync(false);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return await animalsRepository.GetByIdAsync(id) is { } animal ? Ok(animal) : NotFound();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(AnimalInfo animal) 
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await animalsRepository.CreateAsync(animal);

        return Created();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AnimalInfo animal)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }

        bool success = await animalsRepository.UpdateAsync(animal);

        return success ? Ok() : BadRequest();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        bool success = await animalsRepository.DeleteAsync(id);
        
        return success ? Ok() : BadRequest();
    }
}
