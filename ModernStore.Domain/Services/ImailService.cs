using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Services
{
    public interface ImailService
    {
        void Send(string name, string email, string subject, string body);
    }
}
