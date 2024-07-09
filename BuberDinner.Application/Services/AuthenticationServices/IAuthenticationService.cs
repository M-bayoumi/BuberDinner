using BuberDinner.Application.Common.OneOfErrors;
using OneOf;

namespace BuberDinner.Application.Services.AuthenticationServices;

public interface IAuthenticationService
{
    OneOf<AuthenticationResult, IError> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
