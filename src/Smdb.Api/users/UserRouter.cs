namespace Smdb.Api.Users;

using Shared.Http;

public class UsersRouter : HttpRouter
{
    public UsersRouter(UsersController usersController)
    {
        UseParametrizedRouteMatching();
        MapGet("/", usersController.ReadUsers);
        MapPost("/", HttpUtils.ReadRequestBodyAsText, usersController.CreateUser);
        MapGet("/:id", moviesController.ReadMovie);
        MapPut("/:id", HttpUtils.ReadRequestBodyAsText, usersController.UpdateUser);
        MapDelete("/:id", usersController.DeleteUser);
    }
}