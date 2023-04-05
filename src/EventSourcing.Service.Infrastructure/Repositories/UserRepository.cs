using EventSourcing.Service.Domain.Entities.User;
using EventSourcing.Service.Infrastructure.Context;
using EventSourcing.Service.Infrastructure.Interfaces;
using EventSourcing.Service.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Service.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context): base(context)
        {
        }

        public async Task<User> GetByIdAsync(int id)
            => await _dbsetEntity.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
