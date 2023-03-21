using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandResult
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult() { }

        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
