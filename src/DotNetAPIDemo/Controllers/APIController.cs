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

    [HttpPost("sample")]
    public ActionResult<string> PostSample(string message, int responseCode = 200)
    {
        return StatusCode(responseCode, "Hello, World! - POST. Message: " + message);
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