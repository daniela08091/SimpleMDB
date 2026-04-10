namespace Smdb.Core.ActorMovies;

public class ActorMovie
{
    public int ActorId { get; set; }
    public int MovieId { get; set; }

    public ActorMovie(int actorId, int movieId)
    {
        ActorId = actorId;
        MovieId = movieId;
    }

    public override string ToString()
    {
        return $"ActorMovie[ActorId={ActorId}, MovieId={MovieId}]";
    }
}