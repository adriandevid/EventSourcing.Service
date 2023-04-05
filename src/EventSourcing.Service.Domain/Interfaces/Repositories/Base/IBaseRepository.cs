using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Domain.Interfaces.UnitOfWork;

namespace EventSourcing.Service.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
