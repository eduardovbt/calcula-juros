using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Model;

namespace CalculaJuros.Domain.Interfaces
{
    public interface IJurosComposto
    {
        decimal CalculaJurosCompostos(ParametrosCalculaJuros parametros);
        IList<HistoricoCalculosResponse> ObtemHistoricoCalculosPorDataAsync(DateTime dataInicio, DateTime dataFim);

        Task<HistoricoCalculosResponse> ObtemHistoricoCalculoPorIdAsync(int id);
        Task<HistoricoCalculosResponse> ExcluirConsultaPorIdAsync(int id);
    }
}
