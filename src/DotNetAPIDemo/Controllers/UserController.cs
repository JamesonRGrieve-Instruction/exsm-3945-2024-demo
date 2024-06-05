using DotNetAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "Register a User",
        Description = "Register a new application user.",
        OperationId = "RegisterUser",
        Tags = new[] { "API", "Authentication" }
    )]
    [SwaggerResponse(201, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]

    public ActionResult<string> Register([FromHeader][SwaggerParameter("Authorization Header (Basic)", Required = true)] string Authorization)
    {
        string AuthorizationDecoded = Base64UrlEncoder.Decode(Authorization.Replace("Basic ", ""));
        string EMail = AuthorizationDecoded.Split(':')[0];
        byte[] Password = Encoding.Unicode.GetBytes(AuthorizationDecoded.Split(':')[1]);
        byte[] EncryptionSecret = Encoding.Unicode.GetBytes(Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "");
        byte[] HashedPassword = SHA256.HashData(EncryptionSecret.Concat(Password).ToArray());
        _context.Users.Add(new User() { Email = EMail, Password = Convert.ToBase64String(HashedPassword) });
        _context.SaveChanges();
        return StatusCode(201, "User Registered");
    }


    [HttpPost("authorize")] // Route parameters are defined in the route itself
    [SwaggerOperation(
        Summary = "Authorize a User",
        Description = "Provide a username and password and get a JWT.",
        OperationId = "AuthorizeUser",
        Tags = new[] { "API", "Authentication" }
    )]

    [SwaggerResponse(200, "Success", typeof(string))]
    [SwaggerResponse(400, "Bad Request", typeof(string))]
    [SwaggerResponse(401, "Unauthorized", typeof(string))]
    [SwaggerResponse(500, "Internal Server Error", typeof(string))]
    public ActionResult<string> PostSample(
        [FromHeader][SwaggerParameter("Authorization Header (Basic)", Required = true)] string Authorization
    )
    {
        string AuthorizationDecoded = Base64UrlEncoder.Decode(Authorization.Replace("Basic ", ""));
        string EMail = AuthorizationDecoded.Split(':')[0];
        byte[] Password = Encoding.Unicode.GetBytes(AuthorizationDecoded.Split(':')[1]);
        byte[] EncryptionSecret = Encoding.Unicode.GetBytes(Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "");
        string HashedPassword = Convert.ToBase64String(SHA256.HashData(EncryptionSecret.Concat(Password).ToArray()));
        User user = _context.Users.Where(u => u.Email == EMail).FirstOrDefault();

        if (user == null || user.Password != HashedPassword)
        {
            return StatusCode(401, "Unauthorized");
        }
        else
        {
            string JWTHeader = Base64UrlEncoder.Encode("{\"alg\": \"HS256\",\"typ\": \"JWT\"}");
            string JWTPayload = Base64UrlEncoder.Encode("{\"sub\": \"" + user.ID + "\", \"email\": \"" + user.Email + "\"}");
            string JWTSignature = Base64UrlEncoder.Encode(SHA256.HashData(Encoding.UTF8.GetBytes(JWTHeader + "." + JWTPayload + "." + Environment.GetEnvironmentVariable("ENCRYPTION_SECRET") ?? "")).ToString());
            string JWT = JWTHeader + "." + JWTPayload + "." + JWTSignature;
            return StatusCode(200, JWT);
        }

    }
}