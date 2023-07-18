using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

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