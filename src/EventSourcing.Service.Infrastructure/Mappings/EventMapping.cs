using EventSourcing.Service.Domain.Entities.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventSourcing.Service.Infrastructure.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("tb_events");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName("event_id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.StreamId).HasColumnName("stream_id").IsRequired();
            builder.Property(x => x.Data).HasColumnName("data_info").IsRequired();
            builder.Property(x => x.Version).HasColumnName("version").IsRequired();
        }
    }
}
