namespace Smdb.Core.ActorMovies;

public interface IActorMovieService
{
    Task<List<ActorMovie>> ReadAll();
    Task<ActorMovie?> Read(int id);
    Task<ActorMovie?> Create(ActorMovie actorMovie);
    Task<ActorMovie?> Update(int id, ActorMovie actorMovie);
    Task<ActorMovie?> Delete(int id);

    Task<List<object>> GetActorsByMovie(int movieId);
    Task<List<object>> GetMoviesByActor(int actorId);
}