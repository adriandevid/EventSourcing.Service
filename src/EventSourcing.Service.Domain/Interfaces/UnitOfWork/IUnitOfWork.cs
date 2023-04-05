

namespace EventSourcing.Service.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public delegate void ExecuteEvents();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAndDispathEvents(ExecuteEvents executeEvents, CancellationToken cancellationToken = default);
    }
}
