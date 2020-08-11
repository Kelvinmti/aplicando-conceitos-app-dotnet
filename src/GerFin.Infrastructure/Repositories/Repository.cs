using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected GerFinContext Ctx { get; }
        private DbSet<TEntity> DBSet { get; }

        private bool disposed = false;

        public Repository(GerFinContext context)
        {
            Ctx = context;
            DBSet = Ctx.Set<TEntity>();
        }

        public void Atualizar(TEntity entity)
        {
            DBSet.Update(entity);
        }

        public void Inserir(TEntity entity)
        {
           DBSet.Add(entity);
        }

        public TEntity ObterPorId(int id)
        {
            return DBSet.Find(id);
        }

        public IQueryable<TEntity> ObterTodos(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null)
        {
            IQueryable<TEntity> query = DBSet.AsNoTracking();

            if (orderby != null)
                return orderby(query);

            return query;
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null)
        {
            return await ObterTodos(orderby).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TEntity> Listar(Expression<Func<TEntity, bool>> exp = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null)
        {
            IQueryable<TEntity> query = DBSet.AsNoTracking();

            if (exp != null)
                query = query.Where(exp);

            if (orderby != null)
                return orderby(query).AsEnumerable();

            return query.AsEnumerable();
        }

        public void Remover(int id)
        {
            TEntity obj = ObterPorId(id);

            if (obj == null)
                throw new Exception("Dado não encontrado para remover!");

            DBSet.Remove(obj);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Ctx.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
