﻿using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command
{
    public  class RegisterProductCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
