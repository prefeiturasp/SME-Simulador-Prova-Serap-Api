using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterListaQuestaoAudioPorQuestaoId;

public class ObterListaQuestaoAudioPorQuestaoIdQueryValidator : AbstractValidator<ObterListaQuestaoAudioPorQuestaoIdQuery>
{
    public ObterListaQuestaoAudioPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .GreaterThan(0)
            .WithMessage("O Id da questao deve ser informado.");
    }
}