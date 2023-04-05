using EventSourcing.Service.Domain.Entities.Event;
using EventSourcing.Service.Domain.Entities.User;
using EventSourcing.Service.Domain.Interfaces.UnitOfWork;
using EventSourcing.Service.Infrastructure.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Service.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        private readonly IMediator  _mediator;
        public ApplicationContext()
        {

        }

        public ApplicationContext(IMediator mediator, DbContextOptions<ApplicationContext> options) : base(options)
        {
            _mediator = mediator;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public async Task<bool> SaveEntitiesAndDispathEvents(IUnitOfWork.ExecuteEvents executeEvents, CancellationToken cancellationToken = default)
        {
            var resultSaveEntitie = await base.SaveChangesAsync() > 0;

            executeEvents();

            _mediator.DispathEvents(this);

            return resultSaveEntitie;
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfigurationsFromAssembly(AppDomain.CurrentDomain.Load("EventSourcing.Service.Infrastructure"));

            base.OnModelCreating(builder);
        }
    }
}
