namespace Smdb.Core.Users;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int Year_Birth { get; set; }
    public string Email { get; set; }

    public Movie(int id, string UserName, int year, string Email)
    {
        Id = id;
        UserName = username;
        Year_Birth = year_birth;
        Email = email;
    }

    public override string ToString()
    {
        return $"User[Id={Id}, UserName={UserName}, Year_Birth={Year_Birth}, Email ={Email}]";
    }
}