using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Command;

namespace ModernStore.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id); 
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExists(string document);

        ICommandResult Get(string userName); 
    }
}
