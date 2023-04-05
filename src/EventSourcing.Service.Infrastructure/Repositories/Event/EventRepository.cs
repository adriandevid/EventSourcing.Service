using EventSourcing.Service.Domain.Interfaces.Repositories.Event;
using EventSourcing.Service.Infrastructure.Context;
using EventSourcing.Service.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Service.Infrastructure.Repositories.Event
{
    public class EventRepository : BaseRepository<Domain.Entities.Event.Event>, IEventRepository
    {
        public EventRepository(ApplicationContext context) : base(context)
        {}

        public async Task<List<Domain.Entities.Event.Event>> GetByStreamIdAsync(int id)
            => await _dbsetEntity.Where(x => x.StreamId == id).ToListAsync();
    }
}
