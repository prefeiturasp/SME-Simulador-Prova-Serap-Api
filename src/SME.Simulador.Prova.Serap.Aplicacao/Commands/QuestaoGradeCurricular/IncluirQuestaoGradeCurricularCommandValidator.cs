using FluentValidation;


namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class IncluirQuestaoGradeCurricularCommandValidator : AbstractValidator<IncluirQuestaoGradeCurricularCommand>
    {
        public IncluirQuestaoGradeCurricularCommandValidator()
        {
            RuleFor(c => c.QuestaoGradeCurricular.DataCriacao)
           .NotNull()
           .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.QuestaoGradeCurricular.DataAtualizacao)
           .NotNull()
           .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.QuestaoGradeCurricular.Situacao)
           .NotNull()
           .WithMessage("A Situacao deve ser informada.");
        }
    }
}