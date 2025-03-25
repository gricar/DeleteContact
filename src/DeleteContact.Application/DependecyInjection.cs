using DeleteContact.Application.Common.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DeleteContact.Application;

public static class DependecyInjection
{
    public static IServiceCollection ConfigureApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependecyInjection).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddSingleton<IEventBus>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<RabbitMQEventBus>>();
            var uri = configuration.GetConnectionString("RabbitMq")!;
            var connectionName = configuration["MessageBroker:ConnectionName"]!;
            return new RabbitMQEventBus(uri, connectionName, logger);
        });

        return services;
    }
}

