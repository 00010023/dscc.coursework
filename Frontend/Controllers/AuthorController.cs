using SSR.Service;
using Microsoft.AspNetCore.Mvc;

namespace SSR.Controllers;

public class AuthorController : Controller
{
    private readonly IApiService _apiService;

    public AuthorController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _apiService.GetAllAuthors();
        return View(authors);
    }

    public async Task<IActionResult> Details(int id)
    {
        var author = await _apiService.GetAuthorById(id);
        return View(author);
    }

    public async Task<IActionResult> Posts(int id)
    {
        var posts = await _apiService.GetPostsByAuthorId(id);
        return View(posts);
    }
    
    // Add this action method to handle author deletion
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var author = await _apiService.GetAuthorById(id);
        if (author == null)
        {
            return NotFound();
        }

        // Call your API to delete the author and related posts
        await _apiService.DeleteAuthorById(id);

        // Redirect back to the list of authors
        return RedirectToAction(nameof(Index));
    }
}