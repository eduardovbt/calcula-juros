using AutoMapper;
using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository.Profiles
{

    public class JurosHistoricoConsultaProfile : Profile
    {
        public JurosHistoricoConsultaProfile()
        {
            CreateMap<JurosHistoricoConsulta, CalculoJurosResultado>();
            CreateMap<CalculoJurosResultado, JurosHistoricoConsulta>().ForMember(c => c.Data, d=>d.MapFrom(t=> DateTime.Now));

            CreateMap<HistoricoCalculosResponse, JurosHistoricoConsulta>();
            CreateMap<JurosHistoricoConsulta, HistoricoCalculosResponse>();
        }
    }
}
