using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Service.Domain.Entities.Base
{
    public class Entity
    {
        public int Id { get; set; }

        private List<INotification> _domainEvents = new List<INotification>();
        public IReadOnlyList<INotification> DomainEvents => _domainEvents;

        protected void AppendDomainEvent(INotification notification) { 
            this._domainEvents.Add(notification);
        }

        public void CleanDomainEvents() { 
            _domainEvents.Clear();
        }
    }
}
