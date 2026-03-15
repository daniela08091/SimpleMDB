namespace Smdb.Core.ActorMovie;

public class ActorMovie
{
    public int Id { get; set; }
    public int ActorId { get; set; }
    public int MovieId { get; set; }
    public string Character { get; set; }

    public ActorMovie(int id, int actorId, int movieId, string character)
    {
        Id = id;
        ActorId = actorId;
        MovieId = movieId;
        Character = character;
    }

    public override string ToString()
    {
        return $"ActorMovie[Id={Id}, ActorId={ActorId}, MovieId={MovieId}, Character ={Character}]";
    }
}