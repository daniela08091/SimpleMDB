namespace Smdb.Api;

using Shared.Http;
using Smdb.Api.Users;
using Smdb.Core.Users;
using Smdb.Core.Db;


public class UsersApp : HttpServer
{
    public override void Init()
    {
        var db = new MemoryDatabase();
        var userRepo = new MemoryUserRepository(db);
        var userServ = new DefaultUserService(userRepo);
        var userCtrl = new UsersController(userServ);
        var userRouter = new UsersRouter(userCtrl);
        var apiRouter = new HttpRouter();

        router.Use(HttpUtils.StructuredLogging);
        router.Use(HttpUtils.CentralizedErrorHandling);
        router.Use(HttpUtils.AddResponseCorsHeaders);
        router.Use(HttpUtils.DefaultResponse);
        router.Use(HttpUtils.ParseRequestUrl);
        router.Use(HttpUtils.ParseRequestQueryString);
        router.UseParametrizedRouteMatching();

        router.UseRouter("/api/v1", apiRouter);
        apiRouter.UseRouter("/users", userRouter);
    }
}