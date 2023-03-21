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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product"); 
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(1024);
            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("MONEY");
            builder.Property(x => x.QuantityOnHand)
                .IsRequired();
        }
    }
}
