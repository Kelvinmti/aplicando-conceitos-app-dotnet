using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFin.Infrastructure.Repositories
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(GerFinContext context) : base(context)
        {
            
        }

        //public async Task<IEnumerable<Receita>> ObterTodosAsync() {
        //    return await ObterTodos().ToListAsync().ConfigureAwait(false);
        //}
    }
}
