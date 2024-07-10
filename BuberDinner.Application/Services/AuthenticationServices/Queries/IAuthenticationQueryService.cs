using BuberDinner.Application.Common.OneOfErrors;
using BuberDinner.Application.Services.AuthenticationServices.Common;
using ErrorOr;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.AuthenticationServices.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
