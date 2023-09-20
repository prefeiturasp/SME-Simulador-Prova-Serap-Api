using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class DesabilitarUltimaVersaoQuestaoPorCodigoCommandValidator : AbstractValidator<DesabilitarUltimaVersaoQuestaoPorCodigoCommand>
{
    public DesabilitarUltimaVersaoQuestaoPorCodigoCommandValidator()
    {
        RuleFor(c => c.CodigoQuestao)
            .NotNull()
            .WithMessage("O codigo da questão deve ser informado.");
    }
}