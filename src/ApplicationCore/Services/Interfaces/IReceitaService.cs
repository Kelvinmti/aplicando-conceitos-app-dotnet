using GerFin.ApplicationCore.DTO;
using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Services.Interfaces
{
    public interface IReceitaService : IService<Receita, ReceitaDTO>
    {
        //IEnumerable<Receita> ObterPaginado(int page);
        IEnumerable<ReceitaDTO> ListarOrdenadoPorNome();
        //Task<IEnumerable<ReceitaDTO>> ObterTodosAsync();
    }
}
