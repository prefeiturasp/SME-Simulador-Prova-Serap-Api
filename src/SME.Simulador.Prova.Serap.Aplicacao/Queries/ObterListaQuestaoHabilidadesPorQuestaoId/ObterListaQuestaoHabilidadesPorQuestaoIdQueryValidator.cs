using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterListaQuestaoHabilidadesPorQuestaoIdQueryValidator : AbstractValidator<ObterListaQuestaoHabilidadesPorQuestaoIdQuery>
    {
        public ObterListaQuestaoHabilidadesPorQuestaoIdQueryValidator()
        {
            RuleFor(c => c.QuestaoId)
                .GreaterThan(0)
                .WithMessage("O Id da questao deve ser informado.");
        }
    }
}