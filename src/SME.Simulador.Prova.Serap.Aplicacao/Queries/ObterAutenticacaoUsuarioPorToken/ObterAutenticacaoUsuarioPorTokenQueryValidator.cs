using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorTokenQueryValidator : AbstractValidator<ObterAutenticacaoUsuarioPorTokenQuery>
{
    public ObterAutenticacaoUsuarioPorTokenQueryValidator()
    {
        RuleFor(c => c.Token)
            .NotNull()
            .NotEmpty()
            .WithMessage("O token deve ser informado.");
    }
}