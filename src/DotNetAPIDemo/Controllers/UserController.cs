using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetAPIDemo.Models;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.JsonPatch;

namespace DotNetAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        [SwaggerOperation(Summary = "Get all users")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all users", typeof(IEnumerable<User>))]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the user", typeof(User))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the user does not exist")]

        public async Task<ActionResult<User>> GetUser([SwaggerParameter("The id of the user to retrieve", Required = true)] int id)
        {
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated user", typeof(User))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "If the id does not match the user's id")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the user does not exist")]

        public async Task<IActionResult> PutUser([SwaggerParameter("The id of the user to update", Required = true)] int id, [FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(user).CurrentValues.SetValues(user);
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new user")]
        [SwaggerResponse(StatusCodes.Status201Created, "Returns the created user", typeof(User))]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a specific user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the deleted user", typeof(User))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the user does not exist")]

        public async Task<IActionResult> DeleteUser([SwaggerParameter("The id of the user to delete", Required = true)] int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("{id}/Post")]
        [SwaggerOperation(Summary = "Get all posts of a specific user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all posts of the user", typeof(IEnumerable<Post>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "If the user does not exist")]

        public async Task<ActionResult<IEnumerable<Post>>> GetPosts([SwaggerParameter("The id of the user to retrieve posts", Required = true)] int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            IEnumerable<Post> posts = await _context.Posts.Where(p => p.UserID == id).ToListAsync();
            return Ok(posts);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}