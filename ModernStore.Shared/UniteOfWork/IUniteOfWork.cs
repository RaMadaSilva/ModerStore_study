using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Shared.UniteOfWork
{
    public interface IUniteOfWork
    {
        void Commit();

        void Rollback(); 
    }
}
