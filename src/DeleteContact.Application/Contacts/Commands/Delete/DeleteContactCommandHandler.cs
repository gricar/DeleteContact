using DeleteContact.Application.Common.Exceptions;
using DeleteContact.Application.Common.Messaging;
using DeleteContact.Application.Common.Messaging.Events;
using DeleteContact.Application.Persistence;
using MediatR;

namespace DeleteContact.Application.Contacts.Commands.Delete;

public class DeleteContactCommandHandler(
    IContactRepository contactRepository, IEventBus eventBus)
    : IRequestHandler<DeleteContactCommand, DeleteContactCommandResponse>
{
    public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        if (command.Id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(command.Id));
        }

        var contact = await contactRepository.GetAsync(command.Id);

        if (contact is null)
        {
            throw new ContactNotFoundException(command.Id);
        }

        var contactEvent = new ContactDeletedEvent(command.Id);

        await eventBus.PublishAsync(contactEvent, "contact-deleted");

        return new DeleteContactCommandResponse("Contact deletion request accepted and is being processed.");
    }
}
