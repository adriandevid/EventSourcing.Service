using EventSourcing.Service.Domain.Events.User;
using EventSourcing.Service.Domain.Interfaces.Services.LogService;
using MediatR;
using Newtonsoft.Json;

namespace EventSourcing.Service.Application.DomainEvents.User
{
    public class UpdateUserEventHandler : INotificationHandler<UpdateUserEvent>
    {
        private readonly ILogEventService _logEventService;
        public UpdateUserEventHandler(ILogEventService logEventService)
        {
            _logEventService = logEventService;
        }
        public async Task Handle(UpdateUserEvent notification, CancellationToken cancellationToken)
        {
            await _logEventService.RegisterLogService(new Domain.Entities.Event.Event(notification.Id, JsonConvert.SerializeObject(notification), 1));

            await Task.Run(() => {
                Console.WriteLine("====> User refused persistence in database..");
                Console.WriteLine("====> {0}", JsonConvert.SerializeObject(notification));
            });
        }
    }
}
