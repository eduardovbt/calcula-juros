using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Interfaces;
using CalculaJuros.Repository.Model;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalculaJuros
{
    public class JurosCompostoService : IJurosComposto
    {
        private readonly IJurosCompostoRepository _repositorio;
        private readonly IValidator<ParametrosCalculaJuros> _validator;

        public JurosCompostoService(IJurosCompostoRepository repositorio, IValidator<ParametrosCalculaJuros> validator)
       
        {
            _repositorio = repositorio;
            _validator = validator;
        }

        
        public decimal CalculaJurosCompostos(ParametrosCalculaJuros parametros)
        {
            var validatorResult = _validator.Validate(parametros);
            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult.Errors);

            var resultado = Convert.ToDecimal(String.Format("{0:N}", parametros.ValorInicial * Math.Pow((1 + 0.01D), parametros.Tempo)));
            SalvaResultado(parametros, resultado);
            return resultado;
        }

        private void SalvaResultado(ParametrosCalculaJuros parametros, decimal resultado)
        {
            var inserirResultado = new CalculoJurosResultado();
            inserirResultado.Resultado = resultado;
            inserirResultado.ValorInicial = parametros.ValorInicial;
            inserirResultado.Tempo = parametros.Tempo;
            _repositorio.InserirAsync(inserirResultado);
        }
        public Task<HistoricoCalculosResponse> ExcluirConsultaPorIdAsync(int id)
        {
            if (id == default)
                throw new ValidationException("Preenchimento do campo ID é obrigatorio!");
            return _repositorio.ExcluirConsultaPorIdAsync(id);
        }

        public IList<HistoricoCalculosResponse> ObtemHistoricoCalculosPorDataAsync(DateTime dataInicio, DateTime dataFim)
        {
            if (!(dataInicio != DateTime.MinValue && dataFim != DateTime.MinValue && dataInicio <= dataFim))
                throw new ValidationException("As datas devem ser prenchidas e inicio deve ser maior que fim!");

            return _repositorio.ObtemHistoricoCalculosPorDataAsync(dataInicio, dataFim);

        }
        public Task<HistoricoCalculosResponse> ObtemHistoricoCalculoPorIdAsync(int id)
        {
            if (id == default)
                throw new ValidationException("Preenchimento do campo ID é obrigatorio!");

            return _repositorio.ObtemHistoricoCalculoPorIdAsync(id);

        }


    }
}
