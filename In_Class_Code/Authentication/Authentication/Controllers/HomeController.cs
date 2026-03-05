using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Authentication.Models;
using Authentication.Models.Entities;
using Authentication.Services;

namespace Authentication.Controllers;

[Authorize] // must be logged in to get to home controller; 
            // forces user to log in before being able to touch on controller (can also put this on individual endpoints)
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepo;

    public HomeController(ILogger<HomeController> logger, IUserRepository userRepo)
    {
        _logger = logger;
        _userRepo = userRepo;
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
        if (User.Identity!.IsAuthenticated) { // '!' is used to override possiblity of null error
            string username = User.Identity.Name ?? "";
            return Content(username);
        }
        return Content("No username");
    }

    public async Task<IActionResult> GetUserId() {
        if (User.Identity!.IsAuthenticated) { // '!' is used to override possiblity of null error
            string username = User.Identity.Name ?? "";
            ApplicationUser? user = await _userRepo.ReadByUsernameAsync(username);
            if (user != null) {
                return Content(user.Id);
            }
        }
        return Content("No User");
    }

    public async Task<IActionResult> CreateTestUser() {
        int n = 100;
        string username = $"test{n}@test.com";
        var check = await _userRepo.ReadByUsernameAsync(username);
        if (check == null) {
            ApplicationUser user = new() {
                Email = username,
                UserName = username,
                FirstName = $"User{n}",
                LastName = $"Lastname{n}"
            };
            await _userRepo.CreateAsync(user, "Pass123!");
            return Content($"Created test user {username}");
        }
        return Content("The user already exists!");
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
