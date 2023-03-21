using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate)
                .IsRequired();
            builder.Property(x => x.Number)
                .IsRequired(); 
            builder.Property(x=>x.Status)
                .IsRequired();
            builder.Property(x => x.DeliveryFee)
                .IsRequired()
                .HasColumnType("Money");
            builder.Property(x => x.Discount)
                .IsRequired()
                .HasColumnType("Money");

            builder.HasOne(x => x.Customer); 

            builder.HasMany(x => x.Items);
        }
    }
}
