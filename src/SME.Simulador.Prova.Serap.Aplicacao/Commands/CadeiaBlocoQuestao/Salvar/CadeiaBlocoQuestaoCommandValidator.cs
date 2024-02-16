using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class CadeiaBlocoQuestaoCommandValidator : AbstractValidator<CadeiaBlocoQuestaoCommand>
{
    public CadeiaBlocoQuestaoCommandValidator()
    {
        RuleFor(c => c.CadeiaBlocoQuestao.CadeiaBlocoId)
            .NotNull()
            .WithMessage("A CadeiaBlocoId deve ser informada.");

        RuleFor(c => c.CadeiaBlocoQuestao.QuestaoId)
            .NotNull()
            .WithMessage("A QuestaoId deve ser informada.");

        RuleFor(c => c.CadeiaBlocoQuestao.Ordem)
            .NotNull()
            .WithMessage("A QuestaoId deve ser informada.");

        RuleFor(c => c.CadeiaBlocoQuestao.DataCricao)
            .NotNull()
            .WithMessage("A DataCriacao deve ser informada.");

        RuleFor(c => c.CadeiaBlocoQuestao.DataAtualizacao)
            .NotNull()
            .WithMessage("A DataAtualizacao deve ser informada.");

        RuleFor(c => c.CadeiaBlocoQuestao.Situacao)
            .NotNull()
            .WithMessage("A Situacao deve ser informada.");
    }
}