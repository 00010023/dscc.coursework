using SSR.Service;
using Microsoft.AspNetCore.Mvc;

namespace SSR.Controllers;

public class PostController : Controller
{
    private readonly IApiService _apiService;

    public PostController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var posts = await _apiService.GetAllPosts();
        return View(posts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var post = await _apiService.GetPostById(id);
        return View(post);
    }
}