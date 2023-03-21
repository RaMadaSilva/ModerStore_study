using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Infra.Context;

namespace ModernStore.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ModernStoreDbContext _context;
        public OrderRepository(ModernStoreDbContext context)
        {
            _context = context;
        }
        public void Save(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges(); //passar para o unite of Work
        }
    }
}
