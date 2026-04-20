using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IntroJavaScript.Models;

namespace IntroJavaScript.Controllers;

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

    public IActionResult JavaScript1() {
        return View();
    }

    public IActionResult JavaScript2() {
        return View();
    }

    public IActionResult UsingJavaScript() {
        return View();
    }

    public IActionResult ModuleDemo() {
        return View();
    }

    public IActionResult ClassDemo() {
        return View();
    }

    public IActionResult ShapeDemo() {
        return View();
    }

    public IActionResult JobApplicationForm() {
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
}
