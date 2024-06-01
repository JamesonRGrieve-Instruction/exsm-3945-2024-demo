using DotNetAPIDemo.Controllers;
using DotNetAPIDemo.Data;
using DotNetAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
namespace DotNetAPIDemo.Tests.BackEnd;

public class UserPutTests
{
    private ApplicationDbContext dbContext;
    private int id;
    [SetUp]
    public async Task Setup()
    {
        UserController userController = new UserController(dbContext);
        User user = new User
        {
            Username = "JohnDoe101",
            EMail = "johndoe101@test.com"
        };

        ActionResult<User> result = await userController.PostUser(user);
        CreatedAtActionResult createdResult = result.Result as CreatedAtActionResult;
        User userResult = createdResult.Value as User;
        id = userResult.Id;
    }

    [Test]
    public async Task Test_UpdateUser()
    {
        UserController userController = new UserController(dbContext);
        User user = new User
        {
            Username = "JohnDoe102",
            EMail = "johndoe102@test.com"
        };
        ActionResult<User> result = await userController.PutUser(id, user);
        OkObjectResult okResult = result.Result as OkObjectResult;
        User userResult = okResult.Value as User;
        Assert.That(id, Is.EqualTo(userResult.Id));
        Assert.That(user.Username, Is.EqualTo(userResult.Username));
        Assert.That(user.EMail, Is.EqualTo(userResult.EMail));
    }
}