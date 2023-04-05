
namespace EventSourcing.Service.Domain.Entities.Event
{
    public class Event
    {
        public Event()
        {

        }
        public Event(int streamId, string data, int version)
        {
            StreamId = streamId;
            Data = data;
            Version = version;
        }

        public int Id { get; set; }
        public int StreamId { get; set; }
        public string Data { get; set; }
        public int Version { get; set; }
    }
}
