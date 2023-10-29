using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthorController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
          if (_context.Authors == null)
          {
              return NotFound();
          }
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
          if (_context.Authors == null)
          {
              return Problem("Entity set 'AuthorContext.Authors'  is null.");
          }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            // Retrieve all posts related to the author
            var posts = await _context.Posts.Where(p => p.AuthorId == id).ToListAsync();

            // Delete all posts related to the author
            if (posts != null && posts.Count > 0)
            {
                _context.Posts.RemoveRange(posts);
            }
            
            // Now delete the author itself
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/Posts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAuthorPosts(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts.Where(p => p.AuthorId == id).ToListAsync();

            return posts;
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
