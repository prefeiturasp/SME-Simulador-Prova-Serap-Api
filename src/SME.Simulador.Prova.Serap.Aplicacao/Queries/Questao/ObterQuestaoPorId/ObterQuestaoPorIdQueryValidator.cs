using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId
{
    public class ObterQuestaoPorIdQueryValidator : AbstractValidator<ObterQuestaoPorIdQuery>
    {
        public ObterQuestaoPorIdQueryValidator()
        {
            RuleFor(c => c.QuestaoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id da questão deve ser informado.");
        }
    }
}
