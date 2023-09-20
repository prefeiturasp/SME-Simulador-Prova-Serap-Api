using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAlternativasPorIdQueryValidator : AbstractValidator<ObterAlternativasPorIdQuery>
{
    public ObterAlternativasPorIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id do Texto Base deve ser informado.");
    }
}