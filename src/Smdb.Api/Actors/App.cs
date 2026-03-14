namespace Smdb.Api;

using Shared.Http;
using Smdb.Api.Actors;
using Smdb.Core.Actors;
using Smdb.Core.Db;


public class App : HttpServer
{
    public override void Init()
    {
        var db = new MemoryDatabase();
        var actorRepo = new MemoryActorRepository(db);
        var actorServ = new DefaultActorService(actorRepo);
        var actorCtrl = new ActorsController(actorServ);
        var actorRouter = new ActorsRouter(actorCtrl);
        var apiRouter = new HttpRouter();

        router.Use(HttpUtils.StructuredLogging);
        router.Use(HttpUtils.CentralizedErrorHandling);
        router.Use(HttpUtils.AddResponseCorsHeaders);
        router.Use(HttpUtils.DefaultResponse);
        router.Use(HttpUtils.ParseRequestUrl);
        router.Use(HttpUtils.ParseRequestQueryString);
        router.UseParametrizedRouteMatching();

        router.UseRouter("/api/v1", apiRouter);
        apiRouter.UseRouter("/actors", actorRouter);
    }
}