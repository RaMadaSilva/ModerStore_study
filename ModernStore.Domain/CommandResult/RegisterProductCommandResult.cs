using ModernStore.Shared.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandResult
{
    public class RegisterProductCommandResult :ICommandResult
    {
        public RegisterProductCommandResult() {  }

        public RegisterProductCommandResult(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
