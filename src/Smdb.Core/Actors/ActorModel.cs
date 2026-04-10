namespace Smdb.Core.Actors;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Actor(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Actor[Id={Id}, Name={Name}]";
    }
}