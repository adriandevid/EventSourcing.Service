using EventSourcing.Service.Domain.Events.User;
using EventSourcing.Service.Domain.Interfaces.Repositories.Event;
using EventSourcing.Service.Domain.Interfaces.Services.LogService;
using MediatR;
using Newtonsoft.Json;

namespace EventSourcing.Service.Application.DomainEvents.User
{
    public class CreateUserStartedEventHandler : INotificationHandler<CreateUserStartedEvent>
    {
        private readonly ILogEventService _logEventService;
        public CreateUserStartedEventHandler(ILogEventService logEventService)
        {
            _logEventService = logEventService;
        }

        public async Task Handle(CreateUserStartedEvent notification, CancellationToken cancellationToken)
        {
            /// Register event in database;
            await _logEventService.RegisterLogService(new Domain.Entities.Event.Event(notification.Id, JsonConvert.SerializeObject(notification), 1));

            await Task.Run(() => {
                Console.WriteLine("====> User created in database sqlite..");
                Console.WriteLine("====> {0}", JsonConvert.SerializeObject(notification));
            });
        }
    }
}
