using EventSourcing.Service.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventSourcing.Service.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("cd_user_pk");
            
            builder.Property(x => x.Name).HasColumnName("nm_user");
            builder.Property(x => x.Password).HasColumnName("nm_password");
            builder.Property(x => x.Status).HasColumnName("nm_status");
        }
    }
}
