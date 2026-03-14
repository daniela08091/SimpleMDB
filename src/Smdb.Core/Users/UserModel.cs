namespace Smdb.Core.Users;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int YearBirth { get; set; }
    public string Email { get; set; }

    public User(int id, string userName, int yearBirth, string email)
    {
        this.Id = id;
        this.UserName = userName;
        YearBirth = yearBirth;
        Email = email;
    }

    public override string ToString()
    {
        return $"User[Id={Id}, UserName={UserName}, YearBirth={YearBirth}, Email ={Email}]";
    }
}
