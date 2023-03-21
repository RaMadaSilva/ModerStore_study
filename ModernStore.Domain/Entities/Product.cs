using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Product: Entity
    {
        protected Product() { }
        public Product(string name, string image, double price, int quantityOnHand)
        {
            Name = name;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public double Price { get; private set; }
        public int QuantityOnHand { get; private set; }

        public void DecriseQuantity(int quantity)
            =>QuantityOnHand -= quantity;
    }
}
