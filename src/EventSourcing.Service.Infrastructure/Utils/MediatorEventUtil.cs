using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Infrastructure.Context;
using MediatR;

namespace EventSourcing.Service.Infrastructure.Utils
{
    public static class MediatorEventUtil
    {
        public static void DispathEvents(this IMediator mediator, ApplicationContext context) 
        {
            var entities = context.ChangeTracker.Entries<Entity>();

            var eventsOfDomain = entities.Where(x => x.Entity.DomainEvents.Count > 0)
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            entities.ToList().ForEach(e =>
            {
                e.Entity.CleanDomainEvents();
            });

            eventsOfDomain.ToList().ForEach(e => { 
                mediator.Publish(e);
            });
        }
    }
}
