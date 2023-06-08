using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterVideosPorQuestaoIdQueryValidator : AbstractValidator<ObterAlternativasPorQuestaoIdQuery>
{
    public ObterVideosPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("QuestaoId deve ser informado.");
    }
}