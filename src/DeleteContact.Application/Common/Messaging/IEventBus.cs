﻿namespace DeleteContact.Application.Common.Messaging;

public interface IEventBus
{
    Task PublishAsync<T>(T message, string queueName);
}

