using MinimalApi.Dominio.Entidade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Entidades;

[TestClass]

public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //arrange
        var adm = new Administrador();

        //act
        adm.Email = "teste@teste.com";
        adm.Senha = "123";
        adm.Perfil = "Adm";
        adm.Id = 1;

        //assert

        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("123", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
    }
}
