using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.QuestaoAudio
{
    public  class IncluirQuestaoAudioCommandValidator : AbstractValidator<IncluirQuestaoAudioCommand>
    {
        public IncluirQuestaoAudioCommandValidator()
        {
            RuleFor(c => c.QuestaoAudio.DataCriacao)
           .NotNull()
           .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.QuestaoAudio.DataAtualizacao)
           .NotNull()
           .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.QuestaoAudio.Situacao)
           .NotNull()
           .WithMessage("A Situacao deve ser informada.");
        }
    }
}
