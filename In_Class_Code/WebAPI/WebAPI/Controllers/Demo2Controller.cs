using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]/[action]")] // uses name of controller and different action methods to define the route
public class Demo2Controller : Controller {
    [HttpGet]
    public IActionResult Index() {
        return Content("Another simple GET endpoint");
    }

    [HttpGet("{id}")] // even though action method takes in int, you can pass in string since the parameter is not explicitly typed (will just pass in 0 in that case)
    public IActionResult Details(int id) {
        return Content($"Details endpoint of {id}");
    }


}