using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Domain.Interfaces.Repositories.Base;
using EventSourcing.Service.Domain.Interfaces.UnitOfWork;
using EventSourcing.Service.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Service.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: class
    {
        public readonly DbSet<TEntity> _dbsetEntity;
        private readonly ApplicationContext _applicationContext;
        public IUnitOfWork UnitOfWork => _applicationContext;

        public BaseRepository(ApplicationContext applicationContext)
        {
            _applicationContext= applicationContext;
            _dbsetEntity = applicationContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbsetEntity.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbsetEntity.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbsetEntity.Remove(entity);
        }
    }
}
