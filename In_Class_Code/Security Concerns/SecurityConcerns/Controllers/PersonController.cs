using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecurityConcerns.Models;
using SecurityConcerns.Models.ViewModels;

namespace SecurityConcerns.Controllers;

public class PersonController : Controller
{
    public IActionResult Index() {
        return Content("Pretend this is the index");
    }
    // GET /person/create
    public IActionResult Create() {
        return View();
    }

    // Mitigating CSRF attack
    [HttpPost, ValidateAntiForgeryToken] // used to validate the antiforgerytoken in POST requests. Token automatically generated
    public IActionResult Create(Person newPerson) {
        return Json(newPerson);
    }

    // Mitigating Over-Posting attack; Done via 1. Bind attribute 2. Using view model
    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreateWithBind([Bind("FirstName,LastName,DateOfBirth")]Person newPerson) { // only allowing these properties to be populated with data
        return Json(newPerson);
    }

    public IActionResult CreateVM() {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult CreateVM(CreatePersonVM personVM) {
        Person person = personVM.GetPersonInstance();
        return Json(person);
    }

    public IActionResult CreatePerson() {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]

    public IActionResult CreatePerson(PersonVM personVM) {
        // if (personVM.DateOfBirth > DateTime.Now) { // instead of doing this, you can create an attribute class to do validation and incldue as an attribute in the model class
        //     ModelState.AddModelError("", "Invalid Date of Birth!"); // method 1: puts error message at the top of the view
        //     ModelState.AddModelError("DateOfBirth", "The date of birth cannot be in the future!"); // method 2: puts error message under property
        // } this validation is no longer needed with "NotInFutureDate" attribute
        if (ModelState.IsValid) {
            // Not needed in this demonstration
            return RedirectToAction("Index");
        }
        return View(personVM);
    }
}