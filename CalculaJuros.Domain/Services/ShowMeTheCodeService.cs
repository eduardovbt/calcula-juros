using CalculaJuros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Domain.Services
{
    public class ShowMeTheCodeService : IShowMeTheCode
    {
        public string ShowMeTheCode()
        {
           return "https://github.com/eduardovbt/calcula-juros";
        }
    }
}
