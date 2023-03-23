using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name)
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Name)
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasMaxLength(50);
            builder.Property(x => x.BirthDate);

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Adress)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(x => x.Document)
                .Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasOne(x => x.User).WithOne(); 
        }
    }
}
