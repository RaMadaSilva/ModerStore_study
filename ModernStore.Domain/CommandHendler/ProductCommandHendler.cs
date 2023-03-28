using Flunt.Notifications;
using ModernStore.Domain.Command;
using ModernStore.Domain.CommandResult;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Shared.Command;

namespace ModernStore.Domain.CommandHendler
{
    public class ProductCommandHendler : Notifiable<Notification>, ICommandHendler<RegisterProductCommand>
    {
        private readonly IproductRepository _productRepository;

        public ProductCommandHendler(IproductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICommandResult Handler(RegisterProductCommand Command)
        {
            //Receber um produto do banco de dados

            var product = _productRepository.Get(Command.Id);

            //verificar se um produto existe no banco de dados 
            if (product != null)
            {
                AddNotification("product", "Este produto já existe"); 
                return new RegisterProductCommandResult();
            }

            //criar o produto e salva no banco de dados
            product = new Product(Command.Name, 
                    Command.Image, 
                    Command.Price, 
                    Command.QuantityOnHand);
            _productRepository.Save(product); 

            return new RegisterProductCommandResult(product.Id, product.Name);
        }
    }
}
