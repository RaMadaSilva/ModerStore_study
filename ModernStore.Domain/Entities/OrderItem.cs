using Flunt.Validations;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem() { }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            Product.DecriseQuantity(quantity); 

         AddNotifications(new Contract<OrderItem>()
             .IsGreaterThan(Quantity, 0, "A quantidade deve ser mmaior que zero"));

        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; set; }

        public double Total()
                => Price * Quantity; 
    }
}
