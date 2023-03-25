using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.CommandResult;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Infra.Context;
using ModernStore.Shared.Command;

namespace ModernStore.Infra.Repository
{

    public class ProdutoRepository: IproductRepository
    {
        private readonly ModernStoreDbContext _context;

        public ProdutoRepository(ModernStoreDbContext context)
        {
            _context = context;
        }

        public Product Get(Guid id) 
            =>_context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id); 

        public IEnumerable<ICommandResult> GetProducts()
        {
            var products = new List<GetListProductCommandResult>();
            products.AddRange(_context.Products
                .AsNoTracking()
                .Select(x => new GetListProductCommandResult(x.Id, x.Name, x.Image, x.Price, x.QuantityOnHand)));
            return products; 
        }

        public void Save(Product product)
            => _context.Products.Add(product);
    }
}
