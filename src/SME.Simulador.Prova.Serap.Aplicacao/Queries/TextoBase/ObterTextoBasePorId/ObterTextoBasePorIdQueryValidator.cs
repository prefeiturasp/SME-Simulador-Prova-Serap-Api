using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterTextoBasePorIdQueryValidator : AbstractValidator<ObterTextoBasePorIdQuery>
{
    public ObterTextoBasePorIdQueryValidator()
    {
        RuleFor(c => c.TextoBaseId)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id do Texto Base deve ser informado.");
    }
}