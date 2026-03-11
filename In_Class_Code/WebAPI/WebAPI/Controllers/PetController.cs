using WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase{ //derives from controllerbase because it is an API controller, you can use "controller" for both views AND APIs, but controllerbase is for api only
    private readonly IPetRepository _petRepo;

    public PetController(IPetRepository petRepo){
        _petRepo = petRepo;
    }

    // GET api/pet/all
    [HttpGet("all")]
    public async Task<IActionResult> Get() {
        return Ok(await _petRepo.ReadAllAsync()); // returns Ok 200 status code object
    }

    // POST api/pet/create
    [HttpPost("create")]
    public async Task<IActionResult> Post([FromForm]Pet pet){ // FromForm tells this method that the data is comign from a form
        await _petRepo.CreateAsync(pet);
        return CreatedAtAction("Get", new { id = pet.Id}, pet); // "Get" parameter is referring to Get Action method, always best to do a GET after a POST
    } 

    // GET api/pet/one/{id}
    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id) {
        var pet = await _petRepo.ReadAsync(id);
        if (pet == null) {
            return NotFound(); // return error 404 
        }
        return Ok(pet);
    }

    // PUT api/pet/update
    [HttpPut("update")]
    public async Task<IActionResult> Put([FromForm]Pet pet) {
        await _petRepo.UpdateAsync(pet.Id, pet);
        return NoContent(); // 204 as per HTTP specification
    }

    // DELETE api/pet/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _petRepo.DeleteAsync(id);
        return NoContent(); // 204 as per HTTP specification
    }
}