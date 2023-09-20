using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirTextoBaseCommandValidator : AbstractValidator<IncluirTextoBaseCommand>
{
    public IncluirTextoBaseCommandValidator()
    {
        RuleFor(c => c.TextoBase.DataCriacao)
            .NotNull()
            .WithMessage("A DataCriacao deve ser informada.");

        RuleFor(c => c.TextoBase.DataAtualizacao)
            .NotNull()
            .WithMessage("A DataAtualizacao deve ser informada.");

        RuleFor(c => c.TextoBase.Situacao)
            .NotNull()
            .WithMessage("A Situacao deve ser informada.");
    }
}