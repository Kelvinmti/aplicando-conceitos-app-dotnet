using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.Infrastructure.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly GerFinContext _context;

        public UnitOfWork(GerFinContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
