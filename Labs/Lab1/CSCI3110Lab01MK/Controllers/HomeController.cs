using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSCI3110Lab01MK.Models;

namespace CSCI3110Lab01MK.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPostAttribute]
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
