using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoIdQueryValidator : AbstractValidator<ObterProvasPorQuestaoIdQuery>
{
    public ObterProvasPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .GreaterThan(0)
            .WithMessage("O Id da questão deve ser informado.");
    }
}