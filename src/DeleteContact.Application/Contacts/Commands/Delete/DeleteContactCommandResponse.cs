namespace DeleteContact.Application.Contacts.Commands.Delete;

public sealed record DeleteContactCommandResponse(string message, string status = "Pending");

