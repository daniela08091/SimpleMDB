using Shared.Http;

namespace Smdb.Core.ActorMovies;

public interface IActorMovieService
{
    Task<Result<List<ActorMovie>>> GetAll();
    Task<Result<ActorMovie>> Create(ActorMovie relation);
}