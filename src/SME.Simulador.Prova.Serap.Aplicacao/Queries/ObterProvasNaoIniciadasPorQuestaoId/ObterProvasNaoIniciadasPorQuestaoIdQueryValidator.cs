using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasNaoIniciadasPorQuestaoIdQueryValidator : AbstractValidator<ObterProvasNaoIniciadasPorQuestaoIdQuery>
{
    public ObterProvasNaoIniciadasPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoCodigo)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id da questão deve ser informado.");
    }
}