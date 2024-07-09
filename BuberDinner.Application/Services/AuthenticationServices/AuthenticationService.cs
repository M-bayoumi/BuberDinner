using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.OneOfErrors;
using BuberDinner.Domain.Entities;
using OneOf;

namespace BuberDinner.Application.Services.AuthenticationServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public OneOf<AuthenticationResult,IError> Register(string firstName, string lastName, string email, string password)
    {
        // 1. validate the user doesn't exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return new DuplicateEmailError();
        }

        // 2. Create user (generate unique ID) & persist to db
        var user = new User(firstName, lastName, email, password);
        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
    public AuthenticationResult Login(string email, string password)
    {
        // 1. validate the user exist
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // 2. validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }
        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
