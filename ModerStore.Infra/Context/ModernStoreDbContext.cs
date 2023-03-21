using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Mapping;

namespace ModernStore.Infra.Context
{
    public class ModernStoreDbContext : DbContext 
    {
        public ModernStoreDbContext()
            : base(GetOptions())
        {  
            
        }
        private static DbContextOptions GetOptions()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(@"Server=RMATEIA-SILVA, 1433;Database=ModernStore;User Id=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True;");
            return builder.Options;
        }

        //colocar aqui os DBSets

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder); 
            
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderItemsMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
