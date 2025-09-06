using MinimalApi.Dominio.Entidade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Entidades;

[TestClass]

public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //arrange
        var veiculo = new Veiculo();

        //act
        veiculo.Marca = "Goula";
        veiculo.Ano = "123";
        veiculo.Nome = "Teste";
        veiculo.Id = 1;

        //assert

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Goula", veiculo.Marca);
        Assert.AreEqual(2015, veiculo.Ano);
        Assert.AreEqual("Teste", veiculo.Nome);
    }
}
