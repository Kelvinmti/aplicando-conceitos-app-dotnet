using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Salvar();
        Task SalvarAsync();
    }
}
