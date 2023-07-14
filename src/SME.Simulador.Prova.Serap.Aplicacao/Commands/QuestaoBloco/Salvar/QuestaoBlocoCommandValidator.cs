using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class QuestaoBlocoCommandValidator : AbstractValidator<QuestaoBlocoCommand>
    {
        public QuestaoBlocoCommandValidator()
        {
            RuleFor(c => c.QuestaoBloco.BlocoId)
            .NotNull()
            .WithMessage("A BlocoId deve ser informada.");

            RuleFor(c => c.QuestaoBloco.QuestaoId)
           .NotNull()
           .WithMessage("A QuestaoId deve ser informada.");

            RuleFor(c => c.QuestaoBloco.Ordem)
           .NotNull()
           .WithMessage("A Ordem deve ser informada.");

            RuleFor(c => c.QuestaoBloco.DataCricao)
           .NotNull()
           .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.QuestaoBloco.DataAtualizacao)
           .NotNull()
           .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.QuestaoBloco.Situacao)
           .NotNull()
           .WithMessage("A Situacao deve ser informada.");
        }
    }
}
