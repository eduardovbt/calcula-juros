using CalculaJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CalculaJuros.Controllers
{
    [ApiController]
    [Route("")]
    [ExcludeFromCodeCoverage]
    public class ShowMeTheCodeController : ControllerBase
    {
        private IShowMeTheCode _showMeTheCode;

        public ShowMeTheCodeController(IShowMeTheCode showMeTheCode)
        {
            _showMeTheCode = showMeTheCode;
        }

        [HttpGet("ShowMeTheCode")]
        public string ShowMeTheCode()
        {
            return _showMeTheCode.ShowMeTheCode();
        }
    }
}
