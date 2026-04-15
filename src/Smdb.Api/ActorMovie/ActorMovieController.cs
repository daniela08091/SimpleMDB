using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Text.Json;
using Shared.Http;
using Smdb.Core.ActorMovies;

namespace Smdb.Api.ActorMovies;

public class ActorMoviesController
{
    private IActorMovieService service;

    public ActorMoviesController(IActorMovieService service)
    {
        this.service = service;
    }

    public async Task GetAll(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var result = await service.ReadAll();
        await JsonUtils.SendResultResponse(req, res, props, new Result<object>(result, 200));
        await next();
    }

    public async Task Create(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var text = (string)props["req.text"]!;
        var data = JsonSerializer.Deserialize<ActorMovie>(text, JsonSerializerOptions.Web);

        var result = await service.Create(data!);
        await JsonUtils.SendResultResponse(req, res, props, new Result<object>(result!, 201));
        await next();
    }

    public async Task Delete(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var uParams = (NameValueCollection)props["req.params"]!;
        int id = int.TryParse(uParams["id"], out int i) ? i : -1;

        var result = await service.Delete(id);
        await JsonUtils.SendResultResponse(req, res, props, new Result<object>(result!, 200));
        await next();
    }

    // RELACIONES

    public async Task GetActorsByMovie(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var uParams = (NameValueCollection)props["req.params"]!;
        int movieId = int.TryParse(uParams["movieId"], out int i) ? i : -1;

        var result = await service.GetActorsByMovie(movieId);
        await JsonUtils.SendResultResponse(req, res, props, new Result<object>(result, 200));
        await next();
    }

    public async Task GetMoviesByActor(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var uParams = (NameValueCollection)props["req.params"]!;
        int actorId = int.TryParse(uParams["actorId"], out int i) ? i : -1;

        var result = await service.GetMoviesByActor(actorId);
        await JsonUtils.SendResultResponse(req, res, props, new Result<object>(result, 200));
        await next();
    }
}