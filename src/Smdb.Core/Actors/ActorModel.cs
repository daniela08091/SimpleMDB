namespace Smdb.Core.Actors;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int YearBirth { get; set; }
    public string Nationality { get; set; }

    public Actor(int id, string name, int yearbirth, string nationality)
    {
        Id = id;
        Name = name;
        YearBirth = yearbirth;
        Nationality = nationality;
    }

    public override string ToString()
    {
        return $"Actor[Id={Id}, Name={Name}, YearBirth={YearBirth}, Nationality ={ Nationality}]";
    }
}