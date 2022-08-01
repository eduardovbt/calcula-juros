using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Entities.Entidades
{
    public class HistoricoCalculosResponse : CalculoJurosResultado
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
    }
}
