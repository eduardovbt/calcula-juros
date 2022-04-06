using CalculaJuros.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{

    [ApiController]
    [Route("")]
    public class JurosController : ControllerBase
    {
        private ICalculaJuros _calculaJuros;

        public JurosController(ICalculaJuros calculaJuros)
        {
            _calculaJuros = calculaJuros;
        }

        [HttpGet("Calcular")]
        public double CalculaJurosCompostos([FromQuery]ParametrosCalculaJuros parametros)
        {
            return _calculaJuros.CalculaJurosCompostos(parametros);
        }
    }
}

