using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models.Entities;
using RecipeApp.Services;

namespace RecipeApp.Controllers;

public class RecipeController : Controller
{
    private readonly IRecipeRepository _recipeRepo;

    public RecipeController(IRecipeRepository recipeRepo)
    {
        _recipeRepo = recipeRepo;
    }

    public async Task<IActionResult> Index()
    {
        var recipes = await _recipeRepo.ReadAllASync();
        return View(recipes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var recipeToEdit = await _recipeRepo.ReadAsync(id);
        if (recipeToEdit == null)
        {
            return RedirectToAction("Index");
        }
        return View(recipeToEdit);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RecipeApp newRecipe)
    {
        if (ModelState.IsValid)
        {
            await _reciopeRepo.CreateAsync(newRecipe);
            return RedirectToAction("Index");
        }
        return View(newRecipe);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var recipe = await _recipeRepo.ReadAsync(id);
        if (recipe == null)
        {
            return RedirectToAction("Index");
        }
        return View(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RecipeApp editedRecipe)
    {
        if (ModelState.IsValid)
        {
            await _recipeRepo.UpdateAsync(editedRecipe.id, editedRecipe);
            return RedirectToAction("Index");
        }
        return View(editedRecipe);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var recipe = await _reciepRepo.ReadAsync(id);
        if (recipe == null)
        {
            return RedirectToAction("Index");
        }
        return View(recipe);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _recipeRepo.DeleteAsync(id);

        reutrn RedirectToAction("Index");
    }
}