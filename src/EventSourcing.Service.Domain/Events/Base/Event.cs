namespace EventSourcing.Service.Domain.Events.Base
{
    public class Event
    {
        public string Type { get => base.GetType().Name; private set { } }
    }
}
