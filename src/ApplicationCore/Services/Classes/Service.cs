using AutoMapper;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerFin.ApplicationCore.Services.Classes
{
    public abstract class Service<TEntity, ViewModel> : IService<TEntity, ViewModel> 
        where TEntity : class 
        where ViewModel : class
    {

        private readonly IRepository<TEntity> Repo;
        protected readonly IUnitOfWork Uow;
        protected readonly IMapper Mapper;

        public Service(IRepository<TEntity> repository, IUnitOfWork uow, IMapper mapper)
        
        {
            Repo = repository;
            Uow = uow;
            Mapper = mapper;
        }

        public void Editar(ViewModel dto)
        {
            TEntity obj = Mapper.Map<TEntity>(dto);
            Repo.Atualizar(obj);
            Uow.Salvar();
        }

        public ViewModel Inserir(ViewModel dto)
        {
            TEntity obj = Mapper.Map<TEntity>(dto);
            Repo.Inserir(obj);
            Uow.Salvar();
            return Mapper.Map<ViewModel>(obj);
        }

        public async Task<ViewModel> InserirAsync(ViewModel dto)
        {
            TEntity obj = Mapper.Map<TEntity>(dto);
            Repo.Inserir(obj);
            await Uow.SalvarAsync();
            return Mapper.Map<ViewModel>(obj);
        }

        public ViewModel ObterPorId(int id)
        {
            TEntity obj = Repo.ObterPorId(id);

            return Mapper.Map<ViewModel>(obj);
        }

        public IEnumerable<ViewModel> ObterTodos()
        {
            IEnumerable<TEntity> obj = Repo.ObterTodos();

            return Mapper.Map<IEnumerable<ViewModel>>(obj);
        }

        public async Task<IEnumerable<ViewModel>> ObterTodosAsync()
        {
            var dados = await Repo.ObterTodosAsync();

            return Mapper.Map<IEnumerable<ViewModel>>(dados);
        }

        public void Remover(int id)
        {
            Repo.Remover(id);
            Uow.Salvar();
        }

        public void Dispose()
        {
            Repo.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
