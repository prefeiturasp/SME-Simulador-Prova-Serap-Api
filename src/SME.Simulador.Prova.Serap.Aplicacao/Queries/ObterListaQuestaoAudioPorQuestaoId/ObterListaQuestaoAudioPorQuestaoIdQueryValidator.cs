using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId
{
    public class ObterListaQuestaoAudioPorQuestaoIdQueryValidator : AbstractValidator<ObterListaQuestaoAudioPorQuestaoIdQuery>
    {
        public ObterListaQuestaoAudioPorQuestaoIdQueryValidator()
        {
            RuleFor(c => c.QuestaoId)
                .GreaterThan(0)
                .WithMessage("O Id da questao deve ser informado.");
        }
    }
}