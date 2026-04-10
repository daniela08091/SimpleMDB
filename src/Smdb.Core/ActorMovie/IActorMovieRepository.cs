using Shared.Http;

namespace Smdb.Core.ActorMovies;

public interface IActorMovieRepository
{
    Task<List<ActorMovie>> GetAll();
    Task<ActorMovie> Create(ActorMovie relation);
}