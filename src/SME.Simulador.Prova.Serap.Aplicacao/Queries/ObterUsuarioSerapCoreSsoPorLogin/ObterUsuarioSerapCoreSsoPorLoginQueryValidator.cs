using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUsuarioSerapCoreSsoPorLoginQueryValidator : AbstractValidator<ObterUsuarioSerapCoreSsoPorLoginQuery>
{
    public ObterUsuarioSerapCoreSsoPorLoginQueryValidator()
    {
        RuleFor(c => c.Login)
            .NotEmpty()
            .NotNull()
            .WithMessage("O Login deve ser informado para obter o usuário do SERAp no CoreSSO.");
    }
}