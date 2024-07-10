using BuberDinner.Application.Features.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Features.Authentication.Commands.Register;

public class RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RegisterCommand(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}
