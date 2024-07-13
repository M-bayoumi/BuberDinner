using BuberDinner.Application.Features.Authentication.Commands.Register;
using BuberDinner.Application.Features.Authentication.Common;
using BuberDinner.Application.Features.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]  //to allow unAuthorized users to register
    public class AuthenticationController : ApiController
    {
        private ISender _sender;// interface segrigation
        private IMapper _mapper;
        public AuthenticationController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> registerResult = await _sender.Send(command);

            return registerResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
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
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> loginResult = await _sender.Send(query);

            if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InValidCredentials)
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: loginResult.FirstError.Description);

            return loginResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));

        }

    }
}
