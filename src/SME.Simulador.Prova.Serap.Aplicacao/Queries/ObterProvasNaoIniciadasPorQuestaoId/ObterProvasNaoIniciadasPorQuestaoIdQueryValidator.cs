using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasNaoIniciadasPorQuestaoIdQueryValidator : AbstractValidator<ObterProvasNaoIniciadasPorQuestaoIdQuery>
{
    public ObterProvasNaoIniciadasPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .GreaterThan(0)
            .WithMessage("O Id da questão deve ser informado.");
    }
}