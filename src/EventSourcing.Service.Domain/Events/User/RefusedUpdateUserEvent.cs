using EventSourcing.Service.Domain.Events.Base;
using MediatR;

namespace EventSourcing.Service.Domain.Events.User
{
    public class RefusedUpdateUserEvent : Event, INotification
    {
        public RefusedUpdateUserEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
