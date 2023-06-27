using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorStatusQueryValidator : AbstractValidator<ObterProvasPorStatusQuery>
{
    public ObterProvasPorStatusQueryValidator()
    {
        RuleFor(c => c.Status)
            .IsInEnum()
            .WithMessage("Informe uma status de prova válido.");
    }
}