using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class APIController : ControllerBase
{
    [HttpGet("sample")]
    public ActionResult<string> GetSample()
    {
        return "Hello, World! - GET";
    }

    [HttpPost("sample")]
    public ActionResult<string> PostSample()
    {
        return "Hello, World! - POST";
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