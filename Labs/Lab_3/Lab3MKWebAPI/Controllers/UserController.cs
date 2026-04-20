using Microsoft.AspNetCore.Mvc;
using Lab3MKWebAPI.Services;
using Lab3MKWebAPI.Models.Entities;

namespace Lab3MKWebAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly IUserRepository _userRepo;

    public UserController(IUserRepository userRepo) {
        _userRepo = userRepo;
    }

    // GET /api/user/all
    [HttpGet("all")]
    public async Task<IActionResult> Get() {
        return Ok(await _userRepo.ReadAllAsync());
    }

    // POST /api/user/create
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm]ApplicationUser newUser, [FromForm]string password) {
        await _userRepo.CreateAsync(newUser, password);
        return CreatedAtAction("Get", newUser);
    }

    // GET /api/user/one/{username}
    [HttpGet("one/{username}")]
    public async Task<IActionResult> Get(string username) {
        var user = await _userRepo.ReadByUsernameAsync(username);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    // PUT /api/user/update
    [HttpPut("update")]
    public async Task<IActionResult> Put([FromForm] ApplicationUser updatedUser) {
        await _userRepo.UpdateAsync(updatedUser.UserName!, updatedUser);
        return NoContent();
    }

    // DELETE /api/user/delete
    [HttpDelete("delete/{username}")]
    public async Task<IActionResult> Delete(string username) {
        await _userRepo.DeleteAsync(username);
        return NoContent();
    }
}