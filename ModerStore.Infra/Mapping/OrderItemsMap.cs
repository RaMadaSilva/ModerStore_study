using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mapping
{
    public class OrderItemsMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem"); 
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.HasOne(x => x.Product); 
        }
    }
}
