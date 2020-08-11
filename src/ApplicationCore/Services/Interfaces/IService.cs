using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Services.Interfaces
{
    public interface IService<TEntity, ViewModel> : IDisposable where TEntity : class
    {
        ViewModel ObterPorId(int id);
        IEnumerable<ViewModel> ObterTodos();
        Task<IEnumerable<ViewModel>> ObterTodosAsync();
        ViewModel Inserir(ViewModel dto);
        Task<ViewModel> InserirAsync(ViewModel dto);
        void Editar(ViewModel dto);
        void Remover(int id);
    }
}
