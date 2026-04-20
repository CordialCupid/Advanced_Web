using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSCI3110Lab01WP.Models;

namespace CSCI3110Lab01WP.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult Data(string userName)
    {
        ViewData["UserName"] = userName;
        return View();
    }

    public IActionResult SimpleTypes()
    {
        return View();
    }

    public IActionResult MyBook()
    {
        return View();
    }

    public IActionResult EmployeeDetails()
    {
        return View();
    }

    public IActionResult EmployeeDepartments()
    {
        return View();
    }

    public IActionResult TimesTable()
    {
        return View();
    }
}
