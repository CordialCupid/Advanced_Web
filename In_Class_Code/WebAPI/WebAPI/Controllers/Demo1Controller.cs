using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("lec/demoone")] // defines endpoint route for controller (Step 3)
public class Demo1Controller : Controller {
    [HttpGet]
    public IActionResult Index() {
        return Content("A plain GET endpoint");
    }

    [HttpGet("{id}")] // add parameter to endpoint (Step 4)
    public IActionResult InforWithId(string id) {
        return Content($"A GET endpoint with parameter id {id}");
    }

    [HttpGet("intdata/{id:int}")] // specification of data type for id parameter

    public IActionResult InfoWithIntId(int id) {
        return Content($"A GET endpoint with 3 segments and parameter that must be an int: {id}");
    }
}