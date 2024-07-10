using BuberDinner.Application.Common.FluentErrors;
using BuberDinner.Application.Features.Authentication.Commands.Register;
using BuberDinner.Application.Features.Authentication.Common;
using BuberDinner.Application.Features.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private ISender _sender;// interface segrigation

        public AuthenticationController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
            ErrorOr<AuthenticationResult> registerResult = await _sender.Send(command);

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
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            ErrorOr<AuthenticationResult> loginResult = await _sender.Send(query);

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
