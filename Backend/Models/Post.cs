using System.Text.Json.Serialization;

namespace API.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    [JsonIgnore]
    public int AuthorId { get; set; }
    public Author Author { get; set; }

}