namespace BuberDinner.Application.Services.AuthenticationServices;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
