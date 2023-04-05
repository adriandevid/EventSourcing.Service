

using EventSourcing.Service.Application.Requests.User;
using EventSourcing.Service.Application.Responses.Base;
using EventSourcing.Service.Application.Services.LogEvents;
using EventSourcing.Service.Domain.Interfaces.Repositories.Event;
using EventSourcing.Service.Domain.Interfaces.Services.LogService;
using EventSourcing.Service.Domain.Interfaces.UnitOfWork;
using EventSourcing.Service.Infrastructure.Context;
using EventSourcing.Service.Infrastructure.Interfaces;
using EventSourcing.Service.Infrastructure.Repositories;
using EventSourcing.Service.Infrastructure.Repositories.Base;
using EventSourcing.Service.Infrastructure.Repositories.Event;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR((mediatr) => mediatr.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("EventSourcing.Service.Application")));
builder.Services.AddSqlite<ApplicationContext>("Data Source=../EventSourcing.Service.Infrastructure/Database/Users.db", options => options.MigrationsAssembly("EventSourcing.Service.Infrastructure"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, ApplicationContext>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ILogEventService, LogEventService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Create user and register in event table
app.MapPost("create", async (CreateUserRequest create, IMediator mediator) =>
{
    return await mediator.Send<ApiResponse>(create);
});

// Update user name or send event of refused update
app.MapPut("update", async (UpdateUserRequest create, IMediator mediator) =>
{
    return await mediator.Send<ApiResponse>(create);
});


app.Run();
