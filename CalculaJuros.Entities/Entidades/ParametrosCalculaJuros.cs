using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CalculaJuros.Entities.Entidades
{
    public class ParametrosCalculaJuros
    {
        public double ValorInicial { get; set; }
        public int Tempo { get; set; }
    }
    public class ParametrosCalculaJurosValidator : AbstractValidator<ParametrosCalculaJuros>
    {
        public ParametrosCalculaJurosValidator()
        {
            RuleFor(x => x.Tempo).NotNull().NotEmpty();
            RuleFor(x => x.ValorInicial).NotNull().NotEmpty();
        }
    }
}
