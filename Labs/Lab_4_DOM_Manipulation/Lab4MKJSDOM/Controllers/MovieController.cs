using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab4MKJSDOM.Models;

namespace Lab4MKJSDOM.Controllers;

public class MovieController : Controller {
    public IActionResult Index()
    {
        return View();
    }
}