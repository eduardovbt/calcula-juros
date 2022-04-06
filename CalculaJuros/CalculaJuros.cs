using CalculaJuros.Interfaces;
using System;

namespace CalculaJuros
{
    public class CalculaJuros : ICalculaJuros
    {

        public double CalculaJurosCompostos(ParametrosCalculaJuros parametros)
        {
            var resultado =  Math.Pow(parametros.ValorInicial * (1 + 0.01), parametros.Tempo);

            return resultado;
        }
        
    }
}
