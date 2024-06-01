using DotNetAPIDemo.Controllers;
using DotNetAPIDemo.Data;
using DotNetAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.Json;
namespace DotNetAPIDemo.Tests.BackEnd;

public class UserPostTests
{

    [Test]
    public async Task Test_CreateUser()
    {
        using (ApplicationDbContext dbContext = BackEndTestsConfiguration.GetApplicationDbContext())
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
            int id = userResult.Id;

            ActionResult<User> foundResult = await userController.GetUser(id);
            User foundUser = foundResult.Value;
            Assert.That(id, Is.EqualTo(foundUser.Id));
            Assert.That(user.Username, Is.EqualTo(foundUser.Username));
            Assert.That(user.EMail, Is.EqualTo(foundUser.EMail));
        }
    }
}