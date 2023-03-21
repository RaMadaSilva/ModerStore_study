using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command
{
    public class RegisterOrderCommnand: ICommand
    {
        public Guid Customer { get; set; }
        public double DeliveryFee { get; set; }
        public double Discount { get; set; }

        public IEnumerable<RegisterOrderItemCommnad> Items { get; set; }
    }
}
