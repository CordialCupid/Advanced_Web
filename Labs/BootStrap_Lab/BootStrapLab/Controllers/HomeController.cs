using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BootStrapLab.Models;

namespace BootStrapLab.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Containers()
    {
        return View();
    }

    public IActionResult GridSystem() 
    {
        return View();
    }

    public IActionResult Forms()
    {
        return View();
    }

    public IActionResult Modals()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreatePet(Pet pet) 
    {
        if (ModelState.IsValid) {
            return Json(new {message = "success", pet});
        }
        return Json();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
