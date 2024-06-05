using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DotNetAPIDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;
[Route("api")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    public record PersonCreate
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public int JobID { get; init; }
        public string? JobName { get; init; }
        public string PubliclyVisible { get; init; } = "off";
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
        [FromBodyAttribute][SwaggerParameter("Person to Create", Required = true)] PersonCreate personCreate,
        [FromHeader][SwaggerParameter("Authorization Header (Bearer)", Required = true)] string Authorization
    )
    {
        if (Authorization == null || !UserController.VerifyJWT(Authorization))
        {
            return Unauthorized();
        }
        Person newPerson = new Person()
        {
            FirstName = personCreate.FirstName,
            LastName = personCreate.LastName,
            PhoneNumber = personCreate.PhoneNumber,
            JobID = personCreate.JobID
        };
        if (ModelState.IsValid)
        {
            if (personCreate.JobID == 0)
            {
                Job newJob = new Job() { Name = personCreate.JobName };
                _context.Jobs.Add(newJob);
                _context.SaveChanges();
                newPerson.JobID = newJob.ID;
            }
            if (personCreate.PubliclyVisible == "on")
            {
                newPerson.UserID = null;
            }
            _context.Add(newPerson);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            // Get the person from the GET action.
            //return CreatedAtAction("GetPerson", new { id = person.ID }, person);

            return Created("api/person/" + newPerson.ID, newPerson);
        }
        return BadRequest(ModelState);
    }
    [HttpGet("person")]
    [SwaggerOperation(
            Summary = "Get all People",
            Description = "Get all people from the database.",
            OperationId = "GetPeople",
            Tags = new[] { "API", "Person" }
        )]
    [SwaggerResponse(200, "Success", typeof(Person))]
    [SwaggerResponse(404, "Not Found", typeof(string))]

    public async Task<IActionResult> GetPerson([FromQuery] int? pageNum, [FromQuery] int? pageSize, [FromQuery] string? orderBy, [FromQuery] string? firstNameFilter)
    {

        List<Person> people = await _context.People.Include(person => person.Job).ToListAsync();
        if (firstNameFilter != null)
        {
            people = people.Where(p => Regex.IsMatch(p.FirstName, firstNameFilter)).ToList();
        }
        if (orderBy == "LastName")
        {
            people = people.OrderBy(p => p.LastName).ToList();
        }
        else if (orderBy == "Job")
        {
            people = people.OrderBy(p => p.Job.Name).ToList();
        }
        else
        {
            people = people.OrderBy(p => p.FirstName).ToList();
        }
        if (pageNum != null && pageSize != null)
        {
            people = people.Take(new Range((int)pageNum * (int)pageSize, ((int)pageNum + 1) * (int)pageSize)).ToList();
        }
        if (people.Count == 0)
        {
            return NotFound();
        }
        else
        {
            return Ok(people);
        }
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