using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.TextoBase.Salvar
{
    public class IncluirTextoBaseCommandValidator : AbstractValidator<IncluirTextoBaseCommand>
    {
        public IncluirTextoBaseCommandValidator()
        {
            RuleFor(c => c.TextoBase.DataCriacao)
           .NotNull()
           .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.TextoBase.DataAtualizacao)
           .NotNull()
           .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.TextoBase.Situacao)
           .NotNull()
           .WithMessage("A Situacao deve ser informada.");
        }
    }
}