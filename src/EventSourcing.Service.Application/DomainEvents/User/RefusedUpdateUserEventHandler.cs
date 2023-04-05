using EventSourcing.Service.Domain.Events.User;
using EventSourcing.Service.Domain.Interfaces.Services.LogService;
using EventSourcing.Service.Infrastructure.Interfaces;
using EventSourcing.Service.Infrastructure.Repositories;
using MediatR;
using Newtonsoft.Json;

namespace EventSourcing.Service.Application.DomainEvents.User
{
    public class RefusedUpdateUserEventHandler : INotificationHandler<RefusedUpdateUserEvent>
    {
        private readonly ILogEventService _logEventService;
        private readonly IUserRepository  _userRepository;

        public RefusedUpdateUserEventHandler(ILogEventService logEventService, IUserRepository userRepository)
        {
            _logEventService = logEventService;
            _userRepository = userRepository;
        }

        public async Task Handle(RefusedUpdateUserEvent notification, CancellationToken cancellationToken)
        {
            Domain.Entities.User.User user = await _userRepository.GetByIdAsync(notification.Id);
            user.Status = "Block";

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();
            
            await _logEventService.RegisterLogService(new Domain.Entities.Event.Event(notification.Id, JsonConvert.SerializeObject(notification), 1));

            await Task.Run(() => {
                Console.WriteLine("====> User refused persistence in database..");
                Console.WriteLine("====> {0}", JsonConvert.SerializeObject(notification));
            });
        }
    }
}
