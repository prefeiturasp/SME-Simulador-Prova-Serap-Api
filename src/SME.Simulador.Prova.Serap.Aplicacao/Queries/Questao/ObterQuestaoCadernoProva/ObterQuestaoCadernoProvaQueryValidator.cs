using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoCadernoProvaQueryValidator : AbstractValidator<ObterQuestaoCadernoProvaQuery>
{
    public ObterQuestaoCadernoProvaQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id da questão deve ser informado.");

        RuleFor(c => c.CadernoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id do caderno deve ser informado.");
    }
}