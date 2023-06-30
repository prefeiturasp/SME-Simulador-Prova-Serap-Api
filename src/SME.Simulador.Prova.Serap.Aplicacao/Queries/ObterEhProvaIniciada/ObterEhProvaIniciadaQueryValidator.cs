using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterEhProvaIniciadaQueryValidator : AbstractValidator<ObterEhProvaIniciadaQuery>
{
    public ObterEhProvaIniciadaQueryValidator()
    {
        RuleFor(c => c.ProvaId)
            .GreaterThan(0)
            .WithMessage("O Id da prova deve ser informado.");
    }
}