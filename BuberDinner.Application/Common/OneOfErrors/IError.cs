using System.Net;

namespace BuberDinner.Application.Common.OneOfErrors;

public interface IError
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
