using EventSourcing.Service.Domain.Events.Base;
using MediatR;

namespace EventSourcing.Service.Domain.Events.User
{
    public class UpdateUserEvent : Event, INotification
    {
        public UpdateUserEvent(string name, int id)
        {
            Name= name;
            Id= id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
