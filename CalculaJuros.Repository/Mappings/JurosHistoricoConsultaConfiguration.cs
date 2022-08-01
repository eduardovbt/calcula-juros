using CalculaJuros.Repository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Repository.Mappings
{
    public class JurosHistoricoConsultaConfiguration : IEntityTypeConfiguration<JurosHistoricoConsulta>
    {
        public void Configure(EntityTypeBuilder<JurosHistoricoConsulta> builder)
        {
            builder.ToTable("CALCULA_JUROS_HISTORICO");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .UseIdentityColumn();
           
            builder.Property(c => c.Data)
                   .IsRequired()
                   .HasColumnName("DATA_CONSULTA");

            builder.Property(c => c.ValorInicial)
                   .IsRequired()
                   .HasColumnName("VALOR_INICIAL");

            builder.Property(c => c.Tempo)
                   .HasColumnName("TEMPO");

            builder.Property(c => c.Resultado)
                   .HasColumnName("RESULTADO");
        }
    }
}
