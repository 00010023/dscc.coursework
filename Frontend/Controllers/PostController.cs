using SSR.Service;
using SSR.Models;
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
    
    [HttpPost]
    public async Task<IActionResult> Create(string title, string author, string body)
    {
        // Create a new post object
        var post = new PostCreationDto
        {
            Title = title,
            AuthorName = author,
            Content = body
        };

        // Call your API to create the post
        await _apiService.CreatePost(post);

        // Redirect back to the Index page
        return RedirectToAction(nameof(Index));
    }
    
    // Action method to display the edit form
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _apiService.GetPostById(id);
        if (post == null)
        {
            return NotFound();
        }
        
        var postUpdateDto = new PostUpdateDto
        {
            Id = id,
            Title = post.Title,
            Content = post.Content,
            AuthorName = post.Author.Name
        };
        
        return View(postUpdateDto);
    }

    // Action method to handle the submission of the edit form
    [HttpPost]
    public async Task<IActionResult> Edit(PostUpdateDto postUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return View(postUpdateDto);
        }

        // Call your API to update the post
        await _apiService.UpdatePost(postUpdateDto.Id, postUpdateDto);

        // Redirect back to the list of posts or details page
        return RedirectToAction(nameof(Index)); // or Details page
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _apiService.GetPostById(id);
        if (post == null)
        {
            return NotFound();
        }

        // Call your API to delete the post
        await _apiService.DeletePostById(id);

        // Redirect back to the list of posts
        return RedirectToAction(nameof(Index));
    }
}