using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirAlternativaCommandValidator : AbstractValidator<IncluirAlternativaCommand>
{
    public IncluirAlternativaCommandValidator()
    {
        RuleFor(c => c.Alternativa.DataCriacao)
            .NotNull()
            .WithMessage("A data de criação deve ser informada.");
        RuleFor(c => c.Alternativa.DataAtualizacao)
            .NotNull()
            .WithMessage("A data de atualização deve ser informada.");
        RuleFor(c => c.Alternativa.Situacao)
            .NotNull()
            .WithMessage("A situação deve ser informada.");
    }
}