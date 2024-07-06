namespace BuberDinner.Application.Services.AuthenticationServices;

public class AuthenticationResult
{
    public Guid ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public AuthenticationResult(Guid iD, string firstName, string lastName, string email, string token)
    {
        ID = iD;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Token = token;
    }
}
