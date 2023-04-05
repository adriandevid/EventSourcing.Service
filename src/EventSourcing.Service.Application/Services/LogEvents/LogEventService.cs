
using EventSourcing.Service.Domain.Entities.Event;
using EventSourcing.Service.Domain.Interfaces.Repositories.Event;
using EventSourcing.Service.Domain.Interfaces.Services.LogService;
using MediatR;
using Newtonsoft.Json;

namespace EventSourcing.Service.Application.Services.LogEvents
{
    public class LogEventService : ILogEventService
    {
        private readonly IEventRepository _eventRepository;

        public LogEventService(IEventRepository eventRepository)
        {
            _eventRepository= eventRepository;
        }

        public async Task RegisterLogService(Event @event) {
            var eventTypeData = await _eventRepository.GetByStreamIdAsync(@event.StreamId);
            var lastEventData = eventTypeData.LastOrDefault();

            if (lastEventData != null)
            {
                @event.Version += lastEventData.Version;
            }

            await _eventRepository.Add(@event);
            await _eventRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}
