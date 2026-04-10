using Shared.Http;
using System.Net;

namespace Smdb.Core.Actors;

public class DefaultActorService : IActorService
{
    private IActorRepository repository;

    public DefaultActorService(IActorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Result<PagedResult<Actor>>> ReadActors(int page, int size)
    {
        if (page < 1 || size < 1)
            return new Result<PagedResult<Actor>>(new Exception("Invalid pagination"), 400);

        var data = await repository.ReadActors(page, size);

        return data == null
            ? new Result<PagedResult<Actor>>(new Exception("Not found"), 404)
            : new Result<PagedResult<Actor>>(data, 200);
    }

    public async Task<Result<Actor>> CreateActor(Actor actor)
    {
        if (string.IsNullOrWhiteSpace(actor.Name))
            return new Result<Actor>(new Exception("Name required"), 400);

        var result = await repository.CreateActor(actor);

        return result == null
            ? new Result<Actor>(new Exception("Error"), 404)
            : new Result<Actor>(result, 201);
    }

    public async Task<Result<Actor>> ReadActor(int id)
    {
        var result = await repository.ReadActor(id);

        return result == null
            ? new Result<Actor>(new Exception("Not found"), 404)
            : new Result<Actor>(result, 200);
    }

    public async Task<Result<Actor>> UpdateActor(int id, Actor newData)
    {
        var result = await repository.UpdateActor(id, newData);

        return result == null
            ? new Result<Actor>(new Exception("Not found"), 404)
            : new Result<Actor>(result, 200);
    }

    public async Task<Result<Actor>> DeleteActor(int id)
    {
        var result = await repository.DeleteActor(id);

        return result == null
            ? new Result<Actor>(new Exception("Not found"), 404)
            : new Result<Actor>(result, 200);
    }
}