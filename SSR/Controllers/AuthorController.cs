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
}