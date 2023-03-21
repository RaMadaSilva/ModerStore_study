using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command
{
    public class RegisterOrderItemCommnad : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
