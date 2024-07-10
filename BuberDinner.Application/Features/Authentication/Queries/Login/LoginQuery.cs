using BuberDinner.Application.Features.Authentication.Commands.Register;
using BuberDinner.Application.Features.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Features.Authentication.Queries.Login;

public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public LoginQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
