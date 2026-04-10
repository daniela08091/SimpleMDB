namespace Smdb.Api;

using Shared.Http;
using Smdb.Api.Movies;
using Smdb.Api.Actors;
using Smdb.Api.Users;
using Smdb.Api.ActorMovies;

using Smdb.Core.Movies;
using Smdb.Core.Actors;
using Smdb.Core.Users;
using Smdb.Core.ActorMovies;
using Smdb.Core.Db;

public class App : HttpServer
{
    public override void Init()
    {
        var db = new MemoryDatabase();

        // MOVIES
        var movieRepo = new MemoryMovieRepository(db);
        var movieServ = new DefaultMovieService(movieRepo);
        var movieCtrl = new MoviesController(movieServ);
        var movieRouter = new MoviesRouter(movieCtrl);

        // ACTORS
        var actorRepo = new MemoryActorRepository(db);
        var actorServ = new DefaultActorService(actorRepo);
        var actorCtrl = new ActorsController(actorServ);
        var actorRouter = new ActorsRouter(actorCtrl);

        // USERS
        var userRepo = new MemoryUserRepository(db);
        var userServ = new DefaultUserService(userRepo);
        var userCtrl = new UsersController(userServ);
        var userRouter = new UsersRouter(userCtrl);

        // ACTOR MOVIE
        var amRepo = new MemoryActorMovieRepository(db);
        var amServ = new DefaultActorMovieService(amRepo, db);
        var amCtrl = new ActorMoviesController(amServ);
        var amRouter = new ActorMoviesRouter(amCtrl);

        var apiRouter = new HttpRouter();

        router.Use(HttpUtils.StructuredLogging);
        router.Use(HttpUtils.CentralizedErrorHandling);
        router.Use(HttpUtils.AddResponseCorsHeaders);
        router.Use(HttpUtils.DefaultResponse);
        router.Use(HttpUtils.ParseRequestUrl);
        router.Use(HttpUtils.ParseRequestQueryString);
        router.UseParametrizedRouteMatching();

        router.UseRouter("/api/v1", apiRouter);

        apiRouter.UseRouter("/movies", movieRouter);
        apiRouter.UseRouter("/actors", actorRouter);
        apiRouter.UseRouter("/users", userRouter);
        apiRouter.UseRouter("/actormovies", amRouter);
    }
}