using AutoMapper;
using GerFin.ApplicationCore.DTO;
using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.ApplicationCore.Services.Interfaces;
using GerFin.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Services.Classes
{
    public class ReceitaService : Service<Receita, ReceitaDTO>, IReceitaService
    {
        private readonly IReceitaRepository Repo;

        public ReceitaService(IReceitaRepository repo, 
                              IUnitOfWork uow, 
                              IMapper mapper) : base(repo, uow, mapper)
        {
            Repo = repo;
        }

        public IEnumerable<ReceitaDTO> ListarOrdenadoPorNome()
        {
            return Mapper.Map<IEnumerable<ReceitaDTO>>(Repo.Listar(orderby: r => r.OrderBy(f => f.Descricao)));
        }

        //public async Task<IEnumerable<ReceitaDTO>> ObterTodosAsync()
        //{
        //    IEnumerable<Receita> dados = await Repo.ObterTodosAsync();

        //    return Mapper.Map<IEnumerable<ReceitaDTO>>(dados);
        //}


    }
}
