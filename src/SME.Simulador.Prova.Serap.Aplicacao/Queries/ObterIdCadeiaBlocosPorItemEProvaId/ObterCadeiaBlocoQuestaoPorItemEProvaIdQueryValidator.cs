using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.ObterIdCadeiaBlocosPorItemEProvaId
{
    public class ObterCadeiaBlocoQuestaoPorItemEProvaIdQueryValidator : AbstractValidator<ObterCadeiaBlocoQuestaoPorItemEProvaIdQuery>
    {
        public ObterCadeiaBlocoQuestaoPorItemEProvaIdQueryValidator()
        {
            RuleFor(c => c.ProvaId)
                .GreaterThan(0)
                .WithMessage("O Id da prova deve ser informado.");
            RuleFor(c => c.ItemId)
             .GreaterThan(0)
             .WithMessage("O Id do item deve ser informado.");
        }
    }
}