using Smdb.Core.Db;

namespace Smdb.Core.ActorMovies;

public class MemoryActorMovieRepository : IActorMovieRepository
{
    private MemoryDatabase db;

    public MemoryActorMovieRepository(MemoryDatabase db)
    {
        this.db = db;
    }

    public async Task<List<ActorMovie>> GetAll()
    {
        return await Task.FromResult(db.ActorMovies);
    }

    public async Task<ActorMovie> Create(ActorMovie relation)
    {
        db.ActorMovies.Add(relation);
        return await Task.FromResult(relation);
    }
}