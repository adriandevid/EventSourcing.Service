using EventSourcing.Service.Domain.Events.Base;
using MediatR;

namespace EventSourcing.Service.Domain.Events.User
{
    public class CreateUserStartedEvent : Event, INotification
    {
        public CreateUserStartedEvent()
        {
        }

        public CreateUserStartedEvent(string name, string password, int id)
        {
            Name= name;
            Password= password;
            Id= id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
