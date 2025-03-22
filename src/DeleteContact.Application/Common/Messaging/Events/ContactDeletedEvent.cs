namespace DeleteContact.Application.Common.Messaging.Events;

public record ContactDeletedEvent(Guid ContactId) : IntegrationEvent;
