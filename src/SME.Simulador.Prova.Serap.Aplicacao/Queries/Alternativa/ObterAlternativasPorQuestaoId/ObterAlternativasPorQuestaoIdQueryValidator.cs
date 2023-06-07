using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterAlternativasPorQuestaoIdQueryValidator : AbstractValidator<ObterAlternativasPorQuestaoIdQuery>
    {
        public ObterAlternativasPorQuestaoIdQueryValidator()
        {
            RuleFor(c => c.QuestaoId)
            .NotNull()
            .NotEmpty()
            .WithMessage("QuestaoId deve ser informado.");
        }
    }
}
