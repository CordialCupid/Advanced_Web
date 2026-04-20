using Microsoft.AspNetCore.Mvc;
using LecCRRUD.Models.Entities;
using LecCRRUD.Services;

namespace LecCRRUD.Controllers;

public class PersonController : Controller 
{
    public readonly IPersonRepository _personRepo;

    public PersonController(IPersonRepository personRepo) 
    {
        _personRepo = personRepo;
    }

    // "Read All"
    public async Task<IActionResult> Index() // person/index
    {
        var peopleModel = await _personRepo.ReadAllAsync();
        return View(peopleModel);
    }

    // "Create" requirement
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person newPerson) {
        if (ModelState.IsValid) {
            await _personRepo.CreateAsync(newPerson);
            return RedirectToAction("Index"); // always "end" on a GET request for security reasons
        }
        return View(newPerson);
    }

    // "Read"
    public async Task<IActionResult> Details(int id) {
        Person? person = await _personRepo.ReadAsync(id);
        if (person == null) {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    //Update
    public async Task<IActionResult> Edit(int id) {
       Person? person = await _personRepo.ReadAsync(id);
        if (person == null) {
            return RedirectToAction("Index");
        }
        return View(person); 
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Person newPerson) {
        if (ModelState.IsValid) {
            await _personRepo.UpdateAsync(newPerson.Id, newPerson);
            return RedirectToAction("Index"); // always "end" on a GET request for security reasons
        }
        return View(newPerson);
    }

    // Delete
    public async Task<IActionResult> Delete(int id) {
       Person? person = await _personRepo.ReadAsync(id);
        if (person == null) {
            return RedirectToAction("Index");
        }
        return View(person); 
    }

    [HttpPost, ActionName("Delete")] // since we had to change name of POST request to deleteconfirmed, we had to add this explcicit actionname because the view expects "Delete"
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _personRepo.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}