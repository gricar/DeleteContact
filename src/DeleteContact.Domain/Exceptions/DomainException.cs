using System.Net;

namespace DeleteContact.Domain.Exceptions;

public class DomainException : Exception
{
    public HttpStatusCode StatusCode { get; }

    protected DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    : base(message)
    {
        StatusCode = statusCode;
    }
}
