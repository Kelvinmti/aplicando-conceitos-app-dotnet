using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        IQueryable<TEntity> ObterTodos(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null);
        Task<IEnumerable<TEntity>> ObterTodosAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null);
        IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> exp = null, 
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null);
        void Inserir(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(int id);
    }
}
