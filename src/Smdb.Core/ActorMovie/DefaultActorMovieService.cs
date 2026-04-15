using Smdb.Core.Db;

namespace Smdb.Core.ActorMovies;

public class DefaultActorMovieService : IActorMovieService
{
    private IActorMovieRepository repo;
    private MemoryDatabase db;

    public DefaultActorMovieService(IActorMovieRepository repo, MemoryDatabase db)
    {
        this.repo = repo;
        this.db = db;
    }

    public async Task<List<object>> GetActorsByMovie(int movieId)
    {
        var result = db.ActorMovies
            .Where(am => am.MovieId == movieId)
            .Join(db.Actors,
                am => am.ActorId,
                a => a.Id,
                (am, a) => new { a.Id, a.Name });

        return await Task.FromResult(result.Cast<object>().ToList());
    }

    public async Task<List<object>> GetMoviesByActor(int actorId)
    {
        var result = db.ActorMovies
            .Where(am => am.ActorId == actorId)
            .Join(db.Movies,
                am => am.MovieId,
                m => m.Id,
                (am, m) => new { m.Id, m.Title, m.Year });

        return await Task.FromResult(result.Cast<object>().ToList());
    }

    public Task<List<ActorMovie>> ReadAll() => repo.ReadAll();

    public Task<ActorMovie?> Read(int id) => repo.Read(id);

    public Task<ActorMovie?> Create(ActorMovie actorMovie) => repo.Create(actorMovie);

    public Task<ActorMovie?> Update(int id, ActorMovie actorMovie) => repo.Update(id, actorMovie);

    public Task<ActorMovie?> Delete(int id) => repo.Delete(id);
}