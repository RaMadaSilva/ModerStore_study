using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserName)
                .IsRequired();
            builder.Property(x => x.Passeword)
                .IsRequired()
                .HasMaxLength(50); 
            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
