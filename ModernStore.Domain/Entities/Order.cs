using Flunt.Validations;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public  class Order: Entity
    {
        private readonly IList<OrderItem> _items;
        protected Order() { }
        public Order(Customer customer,  double deliveryFee, double discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8);
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;

            _items = new List<OrderItem>();

            AddNotifications(new Contract<Order>()
                .IsGreaterThan(deliveryFee, 0, "Valor náo pode ser menor que zero")
                .IsGreaterThan(deliveryFee, -1, "DeliveryFee"));
        }

        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items { get { return _items.ToArray();  } }
        public double DeliveryFee { get; private set; }
        public double Discount { get; private set; }
        public Customer Customer { get; private set; }

        public double SubTotal()
                => Items.Sum(x => x.Total());

        public double TotalPayment()
            =>SubTotal() + DeliveryFee - Discount;
        public void AddItem(OrderItem item)
        {
            if (item.IsValid)
                _items.Add(item); 
        }
    }
}
