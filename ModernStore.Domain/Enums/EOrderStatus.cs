﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Enums
{
    public enum EOrderStatus
    {
        Created =1, 
        InProgress =2, 
        OutForDelivery = 3, 
        Deliveried =4,
        Canceled =5
    }
}
