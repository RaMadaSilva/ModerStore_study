using Microsoft.EntityFrameworkCore;
using ModernStore.Infra.Context;
using ModernStore.Shared.UniteOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.UniteOfWork
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ModernStoreDbContext _context;

        public UniteOfWork(ModernStoreDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {

        }
    }
}
