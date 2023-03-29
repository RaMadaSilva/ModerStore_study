using ModernStore.Infra.Context;
using ModernStore.Shared.UniteOfWork;

namespace ModernStore.Infra.UniteOfWork
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ModernStoreDbContext _context;

        public UniteOfWork(ModernStoreDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {

        }
    }
}
