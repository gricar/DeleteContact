using DeleteContact.API.Middlewares;
using DeleteContact.Application;
using DeleteContact.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApplicationServices(builder.Configuration)
    .ConfigurePersistenceServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.MapGet("/", () => "Hello From Delete");

app.Run();
