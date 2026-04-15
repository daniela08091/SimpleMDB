namespace Smdb.Core.ActorMovies;

public interface IActorMovieRepository
{
    Task<List<ActorMovie>> ReadAll();
    Task<ActorMovie?> Read(int id);
    Task<ActorMovie?> Create(ActorMovie actorMovie);
    Task<ActorMovie?> Update(int id, ActorMovie newData);
    Task<ActorMovie?> Delete(int id);
}