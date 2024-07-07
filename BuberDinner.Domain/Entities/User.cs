namespace BuberDinner.Domain.Entities;

public class User
{
    public Guid ID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public User(string firstName, string lastName, string email, string password)
    {
        ID = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

}
