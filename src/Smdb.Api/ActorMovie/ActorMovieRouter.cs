using Shared.Http;

namespace Smdb.Api.ActorMovies;

public class ActorMoviesRouter : HttpRouter
{
    public ActorMoviesRouter(ActorMoviesController controller)
    {
        UseParametrizedRouteMatching();

        MapGet("/", controller.GetAll);
        MapPost("/", HttpUtils.ReadRequestBodyAsText, controller.Create);
        MapDelete("/:id", controller.Delete);

        // RELACIONES
        MapGet("/movie/:movieId", controller.GetActorsByMovie);
        MapGet("/actor/:actorId", controller.GetMoviesByActor);
    }
}