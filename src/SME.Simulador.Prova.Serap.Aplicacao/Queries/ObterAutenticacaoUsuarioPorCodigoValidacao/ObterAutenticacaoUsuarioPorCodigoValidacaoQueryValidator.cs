using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterAutenticacaoUsuarioPorCodigoValidacaoQueryValidator : AbstractValidator<ObterAutenticacaoUsuarioPorCodigoValidacaoQuery>
{
    public ObterAutenticacaoUsuarioPorCodigoValidacaoQueryValidator()
    {
        RuleFor(c => c.Codigo)
            .NotNull()
            .NotEmpty()
            .WithMessage("A código deve ser informada.");
    }
}