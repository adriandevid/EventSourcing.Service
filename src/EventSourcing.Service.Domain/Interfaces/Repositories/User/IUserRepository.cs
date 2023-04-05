using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Domain.Entities.User;
using EventSourcing.Service.Domain.Interfaces.Repositories.Base;

namespace EventSourcing.Service.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByIdAsync(int id);
    }
}
