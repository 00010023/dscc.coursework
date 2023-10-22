using SSR.Models;

namespace SSR.Service;

public interface IApiService
{
    // For Authors
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthorById(int id);
    Task<IEnumerable<Post>> GetPostsByAuthorId(int id);
    
    // For Posts
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(int id);
}