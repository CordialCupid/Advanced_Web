using Lab5MKBookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab5MKBookAuthorApp.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _bookRepo;

    public BookController(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Modals()
    {
        return View();
    }
}