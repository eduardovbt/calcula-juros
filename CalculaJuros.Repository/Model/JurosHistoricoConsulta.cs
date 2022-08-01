using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository.Model
{
    public class JurosHistoricoConsulta
    {
        public int Id { get; set; }
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public decimal Resultado { get; set; }
        public DateTime Data { get; set; }
    }
}
