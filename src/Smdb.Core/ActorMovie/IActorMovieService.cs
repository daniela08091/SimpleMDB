using Shared.Http;

namespace Smdb.Core.ActorMovies;

public interface IActorMovieService
{
    Task<Result<List<ActorMovie>>> GetAll();
    Task<Result<ActorMovie>> GetById(int id);

    Task<Result<ActorMovie>> Create(ActorMovie relation);
    Task<Result<ActorMovie>> Update(int id, ActorMovie relation);
    Task<Result<bool>> Delete(int id);
}