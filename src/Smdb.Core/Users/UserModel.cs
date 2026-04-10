namespace Smdb.Core.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public override string ToString()
    {
        return $"User[Id={Id}, Name={Name}, Email={Email}]";
    }
}