using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.Repositories.Interfaces;
using GerFin.Infrastructure.Repositories;
using GerFinDomainTest;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerFinTest
{
    public class ReceitaTest
    {
        ///private DependencyResolverHelpercs _serviceProvider;
        //private Mock<IReceitaRepository> _mockReceitaRepo;
        private IReceitaRepository receitaRepo;
        private GerFinContext context;

        public ReceitaTest()
        {
            context = new GerFinContext();
            //_mockReceitaRepo = new Mock<IReceitaRepository>();
            //var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>
        }

        [Fact]
        public void TestObterNomeRepositorio()
        {
            Receita receita;
            receitaRepo = new ReceitaRepository(context);
            receita = receitaRepo.ObterPorId(1);

            //_mockReceitaRepo.Setup(repo => repo.ObterPorId(1)).Returns(new Receita() { ReceitaId=1 });
            Assert.Equal("Freelancer New York", receita.Descricao);
        }
    }
}
