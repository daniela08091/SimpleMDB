
namespace Smdb.Core.ActorMovies;

public interface IActorMovieRepository
{
    Task<List<ActorMovie>> GetAll();
    Task<ActorMovie?> GetById(int id);

    Task<ActorMovie> Create(ActorMovie relation);
    Task<ActorMovie?> Update(int id, ActorMovie relation);
    Task<bool> Delete(int id);
}