using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Entities.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{

    [ApiController]
    [Route("api/juros")]
    [ExcludeFromCodeCoverage]
    public class JurosCompostoController : ControllerBase
    {
        private IJurosComposto _jurosComposto;

        public JurosCompostoController(IJurosComposto calculaJuros)
        {
            _jurosComposto = calculaJuros;
        }

        [HttpPost("composto/calcular")]
        public decimal CalculaJurosCompostos([FromBody]ParametrosCalculaJuros parametros)
        {
            return _jurosComposto.CalculaJurosCompostos(parametros);
        }

        [HttpGet("composto")]
        public ActionResult ConsultarHistoricoDeCalculosPorData([FromQuery] DateTime dataInicio, DateTime dataFim)
        {
            var resultadoConsulta = _jurosComposto.ObtemHistoricoCalculosPorDataAsync(dataInicio, dataFim);
            if (!resultadoConsulta.Any())
                return NoContent();
            return Ok(resultadoConsulta);
        }

        [HttpGet("composto/{id}")]
        public ActionResult ConsultarHistoricoDeCalculoPorID([FromRoute] int id)
        {
            var resultadoConsulta = _jurosComposto.ObtemHistoricoCalculoPorIdAsync(id);
            if (resultadoConsulta == default)
                return NoContent();
            return Ok(resultadoConsulta);
        }

        [HttpDelete("composto/{id}")]
        public async Task<ActionResult> ExcluirConsultaPorID([FromRoute]int id)
        {
            var result = await _jurosComposto.ExcluirConsultaPorIdAsync(id);
            if (result == default)
                return NoContent();
            return Ok(result);
        }
    }
}

