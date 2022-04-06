using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;
using CalculaJuros;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CalculaJuros.Testes
{
    [TestClass]
    public class CalculaJurosTest
    {
        [TestMethod]
        public void DeveriaCalcularValorJuros()
        {
            var calculaJuros = new CalculaJuros();
            var parametrosCalculaJuros = new ParametrosCalculaJuros()
            {
                Tempo = 5,
                ValorInicial = 100.00
            };
            var valorFinal = calculaJuros.CalculaJurosCompostos(parametrosCalculaJuros);

            Assert.AreEqual(105.10, valorFinal);
        }
    }
}
