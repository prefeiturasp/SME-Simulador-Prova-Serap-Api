using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoIdQueryValidator : AbstractValidator<ObterProvasPorQuestaoIdQuery>
{
    public ObterProvasPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoCodigo)
             .NotNull()
            .NotEmpty()
            .WithMessage("O Id da questão deve ser informado.");
    }
}