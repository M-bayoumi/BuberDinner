using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        //if (errors.All(error => error.Type == ErrorType.Validation))
        //{
        //    return ValidationProblemMethod(errors);
        //}

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];
        return ProblemMethod(firstError);
    }

    private IActionResult ProblemMethod(Error firstError)
    {
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError

        };
        return Problem(statusCode: statusCode, title: firstError.Description);
    }

    private IActionResult ValidationProblemMethod(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem(modelStateDictionary);
    }
}
