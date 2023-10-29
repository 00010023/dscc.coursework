using SSR.Models;

namespace SSR.Service;

public interface IApiService
{
    // For Authors
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetAuthorById(int id);
    Task<IEnumerable<Post>> GetPostsByAuthorId(int id);
    Task DeleteAuthorById(int id);

    // For Posts
    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(int id);
    Task CreatePost(PostCreationDto postDto);
    Task UpdateAuthor(Author author);
    Task UpdatePost(int postId, PostUpdateDto postUpdateDto);
    Task DeletePostById(int id);
}