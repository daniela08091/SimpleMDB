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

    public async Task<Result<List<ActorMovie>>> GetAll()
    {
        var relations = await repository.GetAll();

        var result = relations == null
            ? new Result<List<ActorMovie>>(
                new Exception("Could not retrieve actor-movie relations."),
                (int)HttpStatusCode.NotFound)
            : new Result<List<ActorMovie>>(relations, (int)HttpStatusCode.OK);

        return result;
    }

    public async Task<Result<ActorMovie>> Create(ActorMovie relation)
    {
        var validationResult = ValidateRelation(relation);
        if (validationResult != null)
        {
            return validationResult;
        }

        var created = await repository.Create(relation);

        var result = created == null
            ? new Result<ActorMovie>(
                new Exception("Could not create relation."),
                (int)HttpStatusCode.NotFound)
            : new Result<ActorMovie>(created, (int)HttpStatusCode.Created);

        return result;
    }

    // 🔥 VALIDACIÓN IMPORTANTE
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
                new Exception($"Actor with id {relation.ActorId} does not exist."),
                (int)HttpStatusCode.BadRequest);
        }

        var movieExists = db.Movies.Any(m => m.Id == relation.MovieId);
        if (!movieExists)
        {
            return new Result<ActorMovie>(
                new Exception($"Movie with id {relation.MovieId} does not exist."),
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