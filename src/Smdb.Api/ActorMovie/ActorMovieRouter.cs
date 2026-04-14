namespace Smdb.Api.ActorMovies;

using Shared.Http;

public class ActorMoviesRouter : HttpRouter
{
    public ActorMoviesRouter(ActorMoviesController controller)
    {
        UseParametrizedRouteMatching();

        // CRUD COMPLETO
        MapGet("/", controller.GetAll);
        MapGet("/{id}", controller.GetById);

        MapPost("/", HttpUtils.ReadRequestBodyAsText, controller.Create);
        MapPut("/{id}", HttpUtils.ReadRequestBodyAsText, controller.Update);

        MapDelete("/{id}", controller.Delete);
    }
}