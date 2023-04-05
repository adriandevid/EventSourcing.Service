using EventSourcing.Service.Domain.Entities.Event;
using EventSourcing.Service.Domain.Interfaces.Repositories.Base;

namespace EventSourcing.Service.Domain.Interfaces.Repositories.Event
{
    public interface IEventRepository : IBaseRepository<Domain.Entities.Event.Event>
    {
        Task<List<Domain.Entities.Event.Event>> GetByStreamIdAsync(int id);
    }
}
