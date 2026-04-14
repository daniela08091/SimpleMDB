using Smdb.Core.Db;

namespace Smdb.Core.ActorMovies;

public class MemoryActorMovieRepository : IActorMovieRepository
{
    private MemoryDatabase db;

    public MemoryActorMovieRepository(MemoryDatabase db)
    {
        this.db = db;
    }

    // =====================
    // GET ALL
    // =====================
    public async Task<List<ActorMovie>> GetAll()
    {
        return await Task.FromResult(db.ActorMovies);
    }

    // =====================
    // GET BY ID
    // =====================
    public async Task<ActorMovie?> GetById(int id)
    {
        var item = db.ActorMovies.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(item);
    }

    // =====================
    // CREATE
    // =====================
    public async Task<ActorMovie> Create(ActorMovie relation)
    {
        db.ActorMovies.Add(relation);
        return await Task.FromResult(relation);
    }

    // =====================
    // UPDATE
    // =====================
    public async Task<ActorMovie?> Update(int id, ActorMovie relation)
    {
        var item = db.ActorMovies.FirstOrDefault(x => x.Id == id);
        if (item == null) return null;

        item.ActorId = relation.ActorId;
        item.MovieId = relation.MovieId;

        return await Task.FromResult(item);
    }

    // =====================
    // DELETE
    // =====================
    public async Task<bool> Delete(int id)
    {
        var item = db.ActorMovies.FirstOrDefault(x => x.Id == id);
        if (item == null) return false;

        db.ActorMovies.Remove(item);
        return await Task.FromResult(true);
    }
}