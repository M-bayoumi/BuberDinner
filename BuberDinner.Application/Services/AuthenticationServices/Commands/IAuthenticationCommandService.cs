using BuberDinner.Application.Common.OneOfErrors;
using BuberDinner.Application.Services.AuthenticationServices.Common;
using ErrorOr;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.AuthenticationServices.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
