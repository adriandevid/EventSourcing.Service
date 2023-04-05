using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Domain.Events.User;

namespace EventSourcing.Service.Domain.Entities.User
{
    public class User : Entity
    {
        public User()
        {

        }

        public User(string name, string password)
        {
            Name= name;
            Password= password;
            Status = "Created";
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public void CreateUserEventStart() {
            AppendDomainEvent(new CreateUserStartedEvent(Name, Password, Id));
        }

        public void UpdateUserEventStart() {
            AppendDomainEvent(new UpdateUserEvent(Name, Id));
        }

        public void RefusedUpdateEventStart()
        {
            AppendDomainEvent(new RefusedUpdateUserEvent(Id, Name));
        }

        public bool IsInvalidPassword(string password) { 
            return Password != password;
        }

        public void Update(string name, string status) { 
            Name = name;
            Status = status;
        }
    }
}
