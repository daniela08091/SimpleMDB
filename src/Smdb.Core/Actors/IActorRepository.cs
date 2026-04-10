using Shared.Http;

namespace Smdb.Core.Actors;

public interface IActorRepository
{
    Task<PagedResult<Actor>?> ReadActors(int page, int size);
    Task<Actor?> CreateActor(Actor actor);
    Task<Actor?> ReadActor(int id);
    Task<Actor?> UpdateActor(int id, Actor newData);
    Task<Actor?> DeleteActor(int id);
}