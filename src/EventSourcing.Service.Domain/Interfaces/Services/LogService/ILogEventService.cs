using EventSourcing.Service.Domain.Entities.Event;

namespace EventSourcing.Service.Domain.Interfaces.Services.LogService
{
    public interface ILogEventService
    {
        Task RegisterLogService(Event @event);
    }
}
