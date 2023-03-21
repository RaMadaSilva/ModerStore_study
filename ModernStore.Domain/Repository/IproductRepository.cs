using ModernStore.Domain.Entities;
using ModernStore.Shared.Command;

namespace ModernStore.Domain.Repository
{
    public interface IproductRepository
    {
        Product Get(Guid id); 
        void Save(Product product);
        IEnumerable<ICommandResult> GetProducts(); 
    }
}
