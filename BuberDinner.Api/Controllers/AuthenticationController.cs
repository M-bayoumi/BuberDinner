using BuberDinner.Application.Common.FluentErrors;
using BuberDinner.Application.Services.AuthenticationServices;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return registerResult.Match(authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));


            /* // FluentResults
            if(registerResult.IsSuccess )
                return Ok(MapAuthResult(registerResult.Value));

            var firstError = registerResult.Errors[0];
            if(firstError is DuplicateEmailError)
                return Problem(statusCode:StatusCodes.Status409Conflict,title:firstError.Message);
            return Problem();
            */


            /* // OneOf
            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage));

            //if (registerResult.IsT0)
            //{
            //    var authResult = registerResult.AsT0;
            //    AuthenticationResponse response = MapAuthResult(authResult);

            //    return Ok(response);
            //}
            //return Problem(statusCode:StatusCodes.Status409Conflict,title:"Email already exists.");
            */
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            ErrorOr<AuthenticationResult> loginResult = _authenticationService.Login(
                request.Email,
                request.Password);

            if(loginResult.IsError && loginResult.FirstError == Errors.Authentication.InValidCredentials)
                return Problem(statusCode:StatusCodes.Status401Unauthorized,title:loginResult.FirstError.Description);

            return loginResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors=> Problem(errors));

        }


        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                                authResult.User.ID,
                                authResult.User.FirstName,
                                authResult.User.LastName,
                                authResult.User.Email,
                                authResult.Token);
        }
    }
}
