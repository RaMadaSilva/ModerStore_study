using Flunt.Notifications;
using ModernStore.Domain.Command;
using ModernStore.Domain.CommandResult;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repository;
using ModernStore.Shared.Command;

namespace ModernStore.Domain.CommandHendler
{
    internal class OrderCommandHendler : Notifiable<Notification>,
        ICommandHendler<RegisterOrderCommnand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IproductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHendler(ICustomerRepository customerRepository, 
            IproductRepository productRepository, 
            IOrderRepository orderRepository
            )
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handler(RegisterOrderCommnand Command)
        {
            //pegar o cliente do repositorio de cliente

            var customer = _customerRepository.Get(Command.Customer);

            //Instanciar um pedido
            var order = new Order(customer, Command.DeliveryFee, Command.Discount); 

            // Adicionar item ao pedido

            foreach(var item in Command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity)); 
            }

            //adicionar as notificações do pedido
            AddNotifications(order.Notifications);

            //perssitir os dados no Banco
            if (IsValid)
                _orderRepository.Save(order);

            //retornar o numero do pedido

            return new RegisterOrderCommandResult(order.Number); 
        }
    }
}
