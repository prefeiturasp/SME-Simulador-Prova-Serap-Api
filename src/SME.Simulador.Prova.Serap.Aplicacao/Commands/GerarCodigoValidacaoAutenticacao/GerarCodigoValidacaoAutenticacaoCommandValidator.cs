using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class GerarCodigoValidacaoAutenticacaoCommandValidator : AbstractValidator<GerarCodigoValidacaoAutenticacaoCommand>
{
    public GerarCodigoValidacaoAutenticacaoCommandValidator()
    {
        RuleFor(c => c.AutenticacaoUsuario)
            .NotNull()
            .WithMessage("Os dados da autenticação do usuário devem ser preenchidos.")
            .DependentRules(() =>
            {
                RuleFor(c => c.AutenticacaoUsuario.Login)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O login deve ser informado.");

                RuleFor(c => c.AutenticacaoUsuario.Perfil)
                    .NotNull()
                    .WithMessage("O perfíl deve ser informado.");
            });
    }
}