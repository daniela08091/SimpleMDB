namespace Smdb.Api.ActorMovies;

using Shared.Http;

public class ActorMoviesRouter : HttpRouter
{
    public ActorMoviesRouter(ActorMoviesController controller)
    {
        UseParametrizedRouteMatching();

        MapGet("/", controller.GetAll);
        MapPost("/", HttpUtils.ReadRequestBodyAsText, controller.Create);
    }
}