using Shared.Http;
using System.Net;
using Smdb.Core.Db;

namespace Smdb.Core.ActorMovies;

public class DefaultActorMovieService : IActorMovieService
{
    private IActorMovieRepository repository;
    private MemoryDatabase db;

    public DefaultActorMovieService(IActorMovieRepository repository, MemoryDatabase db)
    {
        this.repository = repository;
        this.db = db;
    }

    // =========================
    // GET ALL
    // =========================
    public async Task<Result<List<ActorMovie>>> GetAll()
    {
        var relations = await repository.GetAll();

        return relations == null
            ? new Result<List<ActorMovie>>(
                new Exception("Could not retrieve actor-movie relations."),
                (int)HttpStatusCode.NotFound)
            : new Result<List<ActorMovie>>(relations, (int)HttpStatusCode.OK);
    }

    // =========================
    // GET BY ID
    // =========================
    public async Task<Result<ActorMovie>> GetById(int id)
    {
        var relation = await repository.GetById(id);

        return relation == null
            ? new Result<ActorMovie>(
                new Exception($"Relation {id} not found."),
                (int)HttpStatusCode.NotFound)
            : new Result<ActorMovie>(relation, (int)HttpStatusCode.OK);
    }

    // =========================
    // CREATE
    // =========================
    public async Task<Result<ActorMovie>> Create(ActorMovie relation)
    {
        var validationResult = ValidateRelation(relation);
        if (validationResult != null)
            return validationResult;

        var created = await repository.Create(relation);

        return created == null
            ? new Result<ActorMovie>(
                new Exception("Could not create relation."),
                (int)HttpStatusCode.BadRequest)
            : new Result<ActorMovie>(created, (int)HttpStatusCode.Created);
    }

    // =========================
    // UPDATE
    // =========================
    public async Task<Result<ActorMovie>> Update(int id, ActorMovie relation)
    {
        var existing = await repository.GetById(id);

        if (existing == null)
        {
            return new Result<ActorMovie>(
                new Exception($"Relation {id} not found."),
                (int)HttpStatusCode.NotFound);
        }

        var validationResult = ValidateRelation(relation);
        if (validationResult != null)
            return validationResult;

        relation.Id = id;

        var updated = await repository.Update(id, relation);

        return updated == null
            ? new Result<ActorMovie>(
                new Exception("Could not update relation."),
                (int)HttpStatusCode.BadRequest)
            : new Result<ActorMovie>(updated, (int)HttpStatusCode.OK);
    }

    // =========================
    // DELETE
    // =========================
    public async Task<Result<bool>> Delete(int id)
    {
        var existing = await repository.GetById(id);

        if (existing == null)
        {
            return new Result<bool>(
                new Exception($"Relation {id} not found."),
                (int)HttpStatusCode.NotFound);
        }

        var deleted = await repository.Delete(id);

        return new Result<bool>(deleted, (int)HttpStatusCode.OK);
    }

    // =========================
    // VALIDATION
    // =========================
    private Result<ActorMovie>? ValidateRelation(ActorMovie relation)
    {
        if (relation == null)
        {
            return new Result<ActorMovie>(
                new Exception("Relation payload is required."),
                (int)HttpStatusCode.BadRequest);
        }

        var actorExists = db.Actors.Any(a => a.Id == relation.ActorId);
        if (!actorExists)
        {
            return new Result<ActorMovie>(
                new Exception($"Actor {relation.ActorId} does not exist."),
                (int)HttpStatusCode.BadRequest);
        }

        var movieExists = db.Movies.Any(m => m.Id == relation.MovieId);
        if (!movieExists)
        {
            return new Result<ActorMovie>(
                new Exception($"Movie {relation.MovieId} does not exist."),
                (int)HttpStatusCode.BadRequest);
        }

        var alreadyExists = db.ActorMovies.Any(am =>
            am.ActorId == relation.ActorId &&
            am.MovieId == relation.MovieId);

        if (alreadyExists)
        {
            return new Result<ActorMovie>(
                new Exception("This relation already exists."),
                (int)HttpStatusCode.BadRequest);
        }

        return null;
    }
}