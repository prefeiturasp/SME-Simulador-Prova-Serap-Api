using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class IncluirQuestaoHabilidadeCommandValidator : AbstractValidator<IncluirQuestaoHabilidadeCommand>
{
    public IncluirQuestaoHabilidadeCommandValidator()
    {
        RuleFor(c => c.QuestaoHabilidade.DataCriacao)
            .NotNull()
            .WithMessage("A DataCriacao deve ser informada.");

        RuleFor(c => c.QuestaoHabilidade.DataAtualizacao)
            .NotNull()
            .WithMessage("A DataAtualizacao deve ser informada.");

        RuleFor(c => c.QuestaoHabilidade.Situacao)
            .NotNull()
            .WithMessage("A Situacao deve ser informada.");

        RuleFor(c => c.QuestaoHabilidade.QuestaoId)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("A QuestaoId deve ser informada.");

        RuleFor(c => c.QuestaoHabilidade.HabilidadeId)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("A HabilidadeId deve ser informada.");
    }
}