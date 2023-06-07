using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterTokenJwtQueryValidator : AbstractValidator<ObterTokenJwtQuery>
{
    public ObterTokenJwtQueryValidator()
    {
        RuleFor(c => c.AutenticacaoUsuario)
            .NotNull()
            .WithMessage("Os dados da autenticação do usuário devem ser informados")
            .DependentRules(() =>
            {
                RuleFor(c => c.AutenticacaoUsuario.Login)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("O login deve ser informado.");

                RuleFor(c => c.AutenticacaoUsuario.Perfil)
                    .NotNull()
                    .WithMessage("O perfíl deve ser informado.");
            });
    }
}