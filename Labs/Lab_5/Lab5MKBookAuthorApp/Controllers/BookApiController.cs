using Microsoft.AspNetCore.Mvc;
using Lab5MKBookAuthorApp.Models.Entities;
using Lab5MKBookAuthorApp.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab5MKBookAuthorApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookApiController : ControllerBase
{
    private readonly IBookRepository _bookRepo;
    private readonly IAuthorRepository _authorRepo;

    public BookApiController(IBookRepository bookRepo, IAuthorRepository authorRepo)
    {
        _bookRepo = bookRepo;
        _authorRepo = authorRepo;
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _bookRepo.ReadAllAsync());
    }

    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var book = await _bookRepo.ReadAsync(id);

        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost("author/add")]
    public async Task<IActionResult> Post([FromForm]int bookId, [FromForm] Author author)
    {
        await _authorRepo.CreateAsync(bookId, author);
        var newAuth = new {id = author.Id, firstName = author.FirstName, lastName = author.LastName, bookId = bookId};
        return CreatedAtAction("Get", newAuth);
    }
}