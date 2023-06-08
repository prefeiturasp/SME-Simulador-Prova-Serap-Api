using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoCadernoProvaQueryValidator : AbstractValidator<ObterQuestaoCadernoProvaQuery>
{
    public ObterQuestaoCadernoProvaQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("QuestaoId deve ser informado.");

        RuleFor(c => c.ProvaId)
            .NotNull()
            .NotEmpty()
            .WithMessage("ProvaId deve ser informado.");
    }
}