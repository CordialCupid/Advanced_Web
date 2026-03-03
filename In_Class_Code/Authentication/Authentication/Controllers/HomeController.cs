using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Authentication.Models;

namespace Authentication.Controllers;

[Authorize] // must be logged in to get to home controller; 
            // forces user to log in before being able to touch on controller (can also put this on individual endpoints)
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

    public IActionResult GetUserName() {
        if (User.Identity!.IsAuthenticated) { // '!' is used to override possiblity of null
            string username = User.Identity.Name ?? "";
            return Content(username);
        }
        return Content("No username");
    }

    [AllowAnonymous] // Allows access to this endpoint even though homecontroller requires authorization
    public IActionResult About() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
