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

    // =========================
    // GET ALL
    // =========================
    public async Task GetAll(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var result = await service.GetAll();
        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }

    // =========================
    // GET BY ID
    // =========================
    public async Task GetById(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        int id = int.Parse((string)props["id"]);

        var result = await service.GetById(id);

        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }

    // =========================
    // CREATE
    // =========================
    public async Task Create(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        var text = (string)props["req.text"]!;
        var relation = JsonSerializer.Deserialize<ActorMovie>(text, JsonSerializerOptions.Web);

        var result = await service.Create(relation!);

        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }

    // =========================
    // UPDATE
    // =========================
    public async Task Update(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        int id = int.Parse((string)props["id"]);
        var text = (string)props["req.text"]!;

        var relation = JsonSerializer.Deserialize<ActorMovie>(text, JsonSerializerOptions.Web);

        var result = await service.Update(id, relation!);

        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }

    // =========================
    // DELETE
    // =========================
    public async Task Delete(HttpListenerRequest req, HttpListenerResponse res, Hashtable props, Func<Task> next)
    {
        int id = int.Parse((string)props["id"]);

        var result = await service.Delete(id);

        await JsonUtils.SendResultResponse(req, res, props, result);
        await next();
    }
}