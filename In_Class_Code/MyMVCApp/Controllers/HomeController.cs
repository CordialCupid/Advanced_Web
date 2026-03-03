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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult MyMethod() {
        //passing data to the view from the controller; 
        // viewbag is older method, and slightly slower; they reference same internal data structure though
        ViewData["SomeValue1"] = "Used ViewData in the controller";
        ViewBag.SomeValue2 = "Used ViewBag in the Controller";
        return View();
    }

    public IActionResult IdCheck(string? id) {
        var model = "No ID";

        // id parameter MUST match the parameter found in the url found in program.cs where you define the map controller route ({controller=Home}/{action=Index}/{id?})
        // In the url, you can put '?myid=1234' to get around this (if you change the parameter name for this method from 'id' to 'myid')
        if (id != null) {
            model = $"Id: {id}";
        }

        // Content = just returning a raw data type
        // normally, in this case you might pass this model into a view but we are just returning Content(model) for demonstrative purposes
        return Content(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
