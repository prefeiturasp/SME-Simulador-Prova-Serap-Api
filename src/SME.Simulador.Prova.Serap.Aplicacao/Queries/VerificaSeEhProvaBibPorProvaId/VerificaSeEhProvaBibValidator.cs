using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId;

public class VerificaSeEhProvaBibValidator : AbstractValidator<VerificaSeEhProvaBibQuery>
{
    public VerificaSeEhProvaBibValidator()
    {
        RuleFor(c => c.ProvaId)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id da prova deve ser informado.");
    }
}