using System.Net;

namespace BuberDinner.Application.Common.OneOfErrors;

public class DuplicateEmailError : IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";
}
