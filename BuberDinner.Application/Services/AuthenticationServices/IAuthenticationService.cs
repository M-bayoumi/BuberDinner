using BuberDinner.Application.Common.OneOfErrors;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.AuthenticationServices;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
