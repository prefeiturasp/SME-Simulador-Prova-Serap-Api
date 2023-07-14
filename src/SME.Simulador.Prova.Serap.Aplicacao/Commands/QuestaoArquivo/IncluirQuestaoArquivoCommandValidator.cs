using FluentValidation;
namespace SME.Simulador.Prova.Serap.Aplicacao.Commands.QuestaoArquivo
{
    public class IncluirQuestaoArquivoCommandValidator : AbstractValidator<IncluirQuestaoArquivoCommand>
    {
        public IncluirQuestaoArquivoCommandValidator()
        {
            RuleFor(c => c.QuestaoArquivo.DataCriacao)
           .NotNull()
           .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.QuestaoArquivo.DataAtualizacao)
           .NotNull()
           .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.QuestaoArquivo.Situacao)
           .NotNull()
           .WithMessage("A Situacao deve ser informada.");
        }
    }
}
