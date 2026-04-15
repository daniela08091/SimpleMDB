using Smdb.Core.Db;

namespace Smdb.Core.ActorMovies;

public class MemoryActorMovieRepository : IActorMovieRepository
{
    private MemoryDatabase db;

    public MemoryActorMovieRepository(MemoryDatabase db)
    {
        this.db = db;
    }

    public async Task<List<ActorMovie>> ReadAll()
    {
        return await Task.FromResult(db.ActorMovies);
    }

    public async Task<ActorMovie?> Read(int id)
    {
        var result = db.ActorMovies.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(result);
    }

    public async Task<ActorMovie?> Create(ActorMovie actorMovie)
    {
        actorMovie.Id = db.NextActorMovieId();
        db.ActorMovies.Add(actorMovie);
        return await Task.FromResult(actorMovie);
    }

    public async Task<ActorMovie?> Update(int id, ActorMovie newData)
    {
        var existing = db.ActorMovies.FirstOrDefault(x => x.Id == id);

        if (existing != null)
        {
            existing.ActorId = newData.ActorId;
            existing.MovieId = newData.MovieId;
        }

        return await Task.FromResult(existing);
    }

    public async Task<ActorMovie?> Delete(int id)
    {
        var existing = db.ActorMovies.FirstOrDefault(x => x.Id == id);

        if (existing != null)
        {
            db.ActorMovies.Remove(existing);
        }

        return await Task.FromResult(existing);
    }
}