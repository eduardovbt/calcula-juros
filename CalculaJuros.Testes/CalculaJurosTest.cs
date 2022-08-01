using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;
using CalculaJuros;
using FluentAssertions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CalculaJuros.Entities.Entidades;
using CalculaJuros.Domain.Interfaces;

namespace CalculaJuros.Testes
{
 
    public class CalculaJurosTest
    {
        private IJurosComposto _calculaJurosService;

        public CalculaJurosTest(IJurosComposto calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [Fact]
        public void DeveriaCalcularValorJuros()
        {
            var parametrosCalculaJuros = new ParametrosCalculaJuros()
            {
                Tempo = 5,
                ValorInicial = 100.00
            };
            var valorFinal = _calculaJurosService.CalculaJurosCompostos(parametrosCalculaJuros);
            valorFinal.Should().Be(105.10M);
           
        }
    }
}
