using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class APIController : ControllerBase
{
    [HttpGet("sample")]
    public ActionResult<string> GetSample()
    {
        return "Hello, World!";
    }
}