using System.Text;
using SSR.Models;
using System.Text.Json;

namespace SSR.Service;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiBaseUrl;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiBaseUrl = configuration["ApiBaseUrl"];
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    // Authors
    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Author>>(_apiBaseUrl + "Author");
    }

    public async Task<Author> GetAuthorById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Author>(_apiBaseUrl + $"Author/{id}");
    }

    public async Task<IEnumerable<Post>> GetPostsByAuthorId(int id)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Post>>(_apiBaseUrl + $"Author/{id}/Posts");
    }
    
    // Posts
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Post>>(_apiBaseUrl + $"Post");
    }

    public async Task<Post> GetPostById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Post>(_apiBaseUrl + $"Post/{id}");
    }
    
    public async Task CreatePost(PostCreationDto postDto)
    {
        var json = JsonSerializer.Serialize(postDto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_apiBaseUrl + "Post", content);
        response.EnsureSuccessStatusCode();
    }
    
    // Method to delete a post by ID
    public async Task DeletePostById(int id)
    {
        var response = await _httpClient.DeleteAsync(_apiBaseUrl + $"Post/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Method to delete an author by ID
    public async Task DeleteAuthorById(int id)
    {
        var response = await _httpClient.DeleteAsync(_apiBaseUrl + $"Author/{id}");
        response.EnsureSuccessStatusCode();
    }
}