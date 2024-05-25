using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DotNetAPIDemo.Models;
using Microsoft.EntityFrameworkCore;
[Route("api")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("person")]
    [SwaggerOperation(
        Summary = "Create a Person",
        Description = "Create a person in the database.",
        OperationId = "PostPerson",
        Tags = new[] { "API", "Person" }
    )]
    [SwaggerResponse(201, "Success", typeof(Person))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]
    public async Task<IActionResult> PostPerson(
        [FromBody][SwaggerParameter("Person to Create", Required = true)] Person person
    )
    {
        if (ModelState.IsValid)
        {
            /*
            if (person.JobID == 0)
            {
                Job newJob = new Job() { Name = JobName };
                _context.Jobs.Add(newJob);
                _context.SaveChanges();
                person.JobID = newJob.ID;
            }
            */
            /*
            if (PubliclyVisible == "on")
            {
                person.UserID = null;
            }
            */
            _context.Add(person);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            // Get the person from the GET action.
            //return CreatedAtAction("GetPerson", new { id = person.ID }, person);

            return Created("api/person/" + person.ID, person);
        }
        return BadRequest(ModelState);
    }
    [HttpGet("person/{id}")]
    [SwaggerOperation(
        Summary = "Get a Person",
        Description = "Get a person from the database.",
        OperationId = "GetPerson",
        Tags = new[] { "API", "Person" }
    )]
    [SwaggerResponse(200, "Success", typeof(Person))]
    [SwaggerResponse(404, "Not Found", typeof(string))]

    public async Task<IActionResult> GetPerson(
        [FromRoute][SwaggerParameter("ID of the Person to get", Required = true)] int id
    )
    {
        Person? person = await _context.People
            .FirstOrDefaultAsync(m => m.ID == id);
        if (person == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(person);
        }
    }

}