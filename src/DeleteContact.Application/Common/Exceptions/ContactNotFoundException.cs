using System.Net;

namespace DeleteContact.Application.Common.Exceptions;

public class ContactNotFoundException : ApplicationException
{
    public ContactNotFoundException(Guid id)
        : base($"Contact with ID '{id}' not found.", HttpStatusCode.NotFound)
    { }
}
