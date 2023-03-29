using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Mapping;

namespace ModernStore.Infra.Context
{
    public class ModernStoreDbContext : DbContext 
    {
        public ModernStoreDbContext(DbContextOptions<ModernStoreDbContext> options)
            : base(options)
        {  
            
        }


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
