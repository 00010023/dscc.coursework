using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data;

public class AuthorContext : DbContext
{
    public AuthorContext(DbContextOptions<AuthorContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }
}