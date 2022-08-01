using CalculaJuros.Entities.Entidades;
using CalculaJuros.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository
{
    public class CalculaJurosContext : DbContext
    {

        public CalculaJurosContext(DbContextOptions<CalculaJurosContext> options)
         : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
