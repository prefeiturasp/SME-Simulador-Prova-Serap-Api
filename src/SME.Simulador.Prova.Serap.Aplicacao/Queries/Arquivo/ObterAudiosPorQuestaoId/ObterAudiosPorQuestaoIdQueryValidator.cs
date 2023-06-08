using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAudiosPorQuestaoIdQueryValidator : AbstractValidator<ObterAudiosPorQuestaoIdQuery>
{
    public ObterAudiosPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("QuestaoId deve ser informado.");
    }
}