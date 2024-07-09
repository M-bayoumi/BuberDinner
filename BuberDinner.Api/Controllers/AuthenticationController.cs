﻿using BuberDinner.Application.Common.OneOfErrors;
using BuberDinner.Application.Services.AuthenticationServices;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

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

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.User.ID,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}
