using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetAPIDemo.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.RegularExpressions;
using DotNetAPIDemo.Data;
namespace DotNetAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        [SwaggerOperation(Summary = "Get all posts")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all posts", typeof(IEnumerable<Post>))]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(
            [FromQuery] int? pageNum,
            [FromQuery] int? pageSize,
            [FromQuery] string? sortBy,
            [FromQuery] string? searchTitle,
            [FromQuery] string? searchContent
        )
        {
            IEnumerable<Post> posts = await _context.Posts.ToListAsync();
            if (!string.IsNullOrEmpty(searchTitle))
            {
                posts = posts.Where(p => Regex.IsMatch(p.Title, searchTitle, RegexOptions.IgnoreCase));
            }
            if (!string.IsNullOrEmpty(searchContent))
            {
                posts = posts.Where(p => Regex.IsMatch(p.Content, searchContent, RegexOptions.IgnoreCase));
            }
            if (pageNum != null && pageSize != null)
            {
                posts = posts.Skip(((int)pageNum - 1) * (int)pageSize).Take((int)pageSize);
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.Trim().ToLower() == "title")
                {
                    posts = posts.OrderBy(p => p.Title);
                }
                else if (sortBy.Trim().ToLower() == "content")
                {
                    posts = posts.OrderBy(p => p.Content);
                }
                else
                {
                    return BadRequest("Invalid sortBy parameter");
                }
            }
            return posts.ToList();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific post")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the post", typeof(Post))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the post does not exist")]

        public async Task<ActionResult<Post>> GetPost([SwaggerParameter("The id of the post", Required = true)] int id)
        {
            Post post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific post")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated post", typeof(Post))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "If the id does not match the post's id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the post does not exist")]

        public async Task<IActionResult> PutPost([SwaggerParameter("The id of the post", Required = true)] int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Entry(post).CurrentValues.SetValues(post);
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(post);
        }

        // POST: api/Post
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new post")]
        [SwaggerResponse(StatusCodes.Status201Created, "Returns the created post", typeof(Post))]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a specific post")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the deleted post", typeof(Post))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the post does not exist")]

        public async Task<IActionResult> DeletePost([SwaggerParameter("The id of the post", Required = true)] int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}