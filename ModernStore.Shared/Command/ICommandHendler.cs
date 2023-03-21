using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Shared.Command
{
    public interface ICommandHendler<T> where T: ICommand
    {
        ICommandResult Handler(T Command); 
    }
}
