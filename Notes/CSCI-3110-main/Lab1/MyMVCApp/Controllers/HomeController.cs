using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMVCApp.Models;

namespace MyMVCApp.Controllers;

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

    public IActionResult MyMethod()
    {
        ViewData["SomeValue1"] = "Used ViewData in the Controller";
        ViewBag.SomeValue2 = "Used ViewBag in the Controller";
        return View();
    }

    public IActionResult IdCheck(string? Id) // ?string is a nullable string, we're passing in what is included in IdCheck/Id], this has to match what you have in Program.cs or you have to pass it/treat it as a query string
    {
        var model = "No ID";
        if (Id != null)
        {
            model = $"Id: {Id}";
        }
        return Content(model);
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
