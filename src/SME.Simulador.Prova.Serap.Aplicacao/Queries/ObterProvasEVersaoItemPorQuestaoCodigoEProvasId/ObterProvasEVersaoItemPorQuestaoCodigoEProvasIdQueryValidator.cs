using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQueryValidator : AbstractValidator<ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery>
{
    public ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQueryValidator()
    {
        RuleFor(c => c.QuestaoCodigo)
            .NotNull()
            .NotEmpty()
            .WithMessage("O Id da questão deve ser informado.");

        RuleFor(c => c.ProvasId)
            .NotNull()
            .WithMessage("Os ids das provas devem ser informados.");
    }
}