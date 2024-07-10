using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.AuthenticationServices.Common;

public class AuthenticationResult
{
    public User User { get; set; }
    public string Token { get; set; }
    public AuthenticationResult(User user, string token)
    {
        User = user;
        Token = token;
    }
}
