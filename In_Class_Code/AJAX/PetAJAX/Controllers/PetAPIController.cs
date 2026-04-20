using PetAJAX.Services;
using Microsoft.AspNetCore.Mvc;
using PetAJAX.Models.Entities;

namespace PetAJAX.Controllers;

[Route("api/pet")]
[ApiController]
public class PetAPIController : ControllerBase
{
    private readonly IPetRepository _petRepo;

    public PetAPIController(IPetRepository petRepo)
    {
        _petRepo = petRepo;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _petRepo.ReadAllAsync());
    }

    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pet = await _petRepo.ReadAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromForm] Pet pet)
    {
        await _petRepo.CreateAsync(pet);
        return CreatedAtAction("Get", new { id = pet.Id }, pet);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Put([FromForm] Pet pet)
    {
        await _petRepo.UpdateAsync(pet.Id, pet);
        return NoContent(); // 204 as per HTTP specification
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _petRepo.DeleteAsync(id);
        return NoContent(); // 204 as per HTTP specification
    }
}
