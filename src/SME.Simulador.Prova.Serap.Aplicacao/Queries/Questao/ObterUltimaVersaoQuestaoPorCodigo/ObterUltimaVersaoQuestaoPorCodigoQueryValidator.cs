using FluentValidation;
namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterUltimaVersaoQuestaoPorCodigoQueryValidator : AbstractValidator<ObterUltimaVersaoQuestaoPorCodigoQuery>
    {
        public ObterUltimaVersaoQuestaoPorCodigoQueryValidator()
        {
            RuleFor(c => c.CodigoItem)
               .NotNull()
               .NotEmpty()
               .WithMessage("O codigo do item deve ser informado.");
        }
    }
}