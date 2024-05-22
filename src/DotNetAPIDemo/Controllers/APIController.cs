using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
[Route("api")]
[ApiController]
public class APIController : ControllerBase
{
    [HttpGet("sample")]
    [SwaggerOperation(
        Summary = "Sample GET request",
        Description = "This is a sample GET request.",
        OperationId = "GetSample",
        Tags = new[] { "API", "Sample" }
    )]
    public ActionResult<string> GetSample()
    {
        return "Hello, World! - GET";
    }


    [HttpPost("sample/{routeParam}")] // Route parameters are defined in the route itself
    [SwaggerOperation(
        Summary = "Sample POST request",
        Description = "This is a sample POST request.",
        OperationId = "PostSample",
        Tags = new[] { "API", "Sample" }
    )]

    [SwaggerResponse(200, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]
    [SwaggerResponse(401, "Unauthorized", typeof(string))]
    [SwaggerResponse(403, "Forbidden", typeof(string))]
    [SwaggerResponse(404, "Not Found", typeof(string))]
    [SwaggerResponse(500, "Internal Server Error", typeof(string))]
    [SwaggerResponse(418, "I'm a Teapot", typeof(string))]
    public ActionResult<string> PostSample(
        [FromBody][SwaggerParameter("Message to Send Back", Required = false)]/* FromBody represents the ENTIRE body, not just one parameter therein */ string body,
        [FromQuery][SwaggerParameter("Status Code to Send Back", Required = false)] int responseCode = 200,
        [FromRoute][SwaggerParameter("To Whom to Say Hello", Required = false)] string routeParam = "World",
        [FromHeader][SwaggerParameter("Authorization Header", Required = false)] string Authorization = null
    //[FromForm] string[] formParams = null,
    //[FromServices] IServiceProvider serviceProvider = null
    )
    {
        return StatusCode(responseCode, "Hello, " + routeParam + "! - POST. Authorization: " + Authorization + " Message: " + body);
    }

    [HttpPut("sample")]
    public ActionResult<string> PutSample()
    {
        return "Hello, World! - PUT";
    }

    [HttpPatch("sample")]
    public ActionResult<string> PatchSample()
    {
        return "Hello, World! - PATCH";
    }

    [HttpDelete("sample")]
    public ActionResult<string> DeleteSample()
    {
        return "Hello, World! - DELETE";
    }
}