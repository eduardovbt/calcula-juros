using AutoMapper;
using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Interfaces;
using CalculaJuros.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository.Repositorys
{
    public class JurosCompostoRepository : IJurosCompostoRepository
    {
        private readonly CalculaJurosContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<JurosHistoricoConsulta> dbset;

        public JurosCompostoRepository(CalculaJurosContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            
           dbset = _context.Set<JurosHistoricoConsulta>();
        }

        public async Task<bool> InserirAsync(CalculoJurosResultado resultado)
        {
            await dbset.AddAsync(_mapper.Map<JurosHistoricoConsulta>(resultado));
            _context.SaveChanges();

            return true;
        }

        public IList<HistoricoCalculosResponse> ObtemHistoricoCalculosPorDataAsync(DateTime dataInicio, DateTime dataFim)
        {
            var resultadoPesquisa = dbset.Where(c => c.Data >= dataInicio && c.Data <= dataFim).ToList();
            return _mapper.Map<List<HistoricoCalculosResponse>>(resultadoPesquisa);
        }
        public async Task<HistoricoCalculosResponse> ObtemHistoricoCalculoPorIdAsync(int id)
        {
            var resultadoPesquisa = await dbset.FirstOrDefaultAsync(c => c.Id == id);
            if(resultadoPesquisa == default)
                return default;
            
            return _mapper.Map<HistoricoCalculosResponse>(resultadoPesquisa);
        }

        public async Task<HistoricoCalculosResponse> ExcluirConsultaPorIdAsync(int id)
        {
            var resultadoCalculo = await dbset.FirstOrDefaultAsync(c => c.Id == id);
            if (resultadoCalculo != default)
            {
                _context.Entry(resultadoCalculo).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return _mapper.Map<HistoricoCalculosResponse>(resultadoCalculo);
            }
            return default;
        }
    }
}
