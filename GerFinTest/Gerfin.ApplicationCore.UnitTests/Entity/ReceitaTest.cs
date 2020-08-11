using Xunit;
using GerFin.ApplicationCore.Entity;

namespace GerFinTest.Gerfin.ApplicationCore.UnitTests.Entity
{
    public class ReceitaTest
    {
        const string DESCRICAO = "Nova Receita";

        [Fact]
        public void ReceitaNaoEValida() {
            Receita receita = new Receita();
            receita.Descricao = "fjgfjfd";
            receita.Valor = 400;

            bool isValid = receita.IsValid();

            Assert.False(isValid);
        }
    }
}