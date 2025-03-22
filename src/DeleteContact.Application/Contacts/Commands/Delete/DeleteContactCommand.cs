using MediatR;

namespace DeleteContact.Application.Contacts.Commands.Delete;

public sealed record DeleteContactCommand(Guid Id) : IRequest<DeleteContactCommandResponse>;
