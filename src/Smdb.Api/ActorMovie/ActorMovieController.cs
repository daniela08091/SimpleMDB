namespace Smdb.Api.ActorMovies;
using System.Net;
using System.Collections;
using System.Text.Json;
using Shared.Http;
using Smdb.Core.ActorMovies;

public class ActorMoviesController
{
    private IActorMovieService service;

    public ActorMoviesController(IActorMovieService service)
    {
        this.service = service;
    }

    public async Task GetAll(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var result = await service.GetAll();
        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }

    public async Task Create(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var text = (string)props["req.text"]!;
        var relation = JsonSerializer.Deserialize<ActorMovie>(text, JsonSerializerOptions.Web);

        var result = await service.Create(relation!);
        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }
}