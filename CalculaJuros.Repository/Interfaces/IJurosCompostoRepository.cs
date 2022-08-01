using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository.Interfaces
{
    public interface IJurosCompostoRepository
    {
        Task<bool> InserirAsync(CalculoJurosResultado resultado);

        Task<HistoricoCalculosResponse> ExcluirConsultaPorIdAsync(int id);

        IList<HistoricoCalculosResponse> ObtemHistoricoCalculosPorDataAsync(DateTime dataInicio, DateTime dataFim);
        Task<HistoricoCalculosResponse> ObtemHistoricoCalculoPorIdAsync(int id);

    }
}
