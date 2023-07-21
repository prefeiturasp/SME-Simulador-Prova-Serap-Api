using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoParaSeremSincronizadasQueryValidator : AbstractValidator<ObterProvasPorQuestaoParaSeremSincronizadasENaoForamIniciadasQuery>
{
    public ObterProvasPorQuestaoParaSeremSincronizadasQueryValidator()
    {
        RuleFor(c => c.Filtro)
            .NotNull()
            .WithMessage("Os filtros devem ser informados para obter as provas da questão.")
            .DependentRules(() =>
            {
                RuleFor(c => c.Filtro.QuestaoId)
                    .GreaterThan(0)
                    .WithMessage("O Id da questão deve ser informado.");

                RuleFor(c => c.Filtro.UltimaAtualizacao)
                    .NotNull()
                    .WithMessage("A data da última atualização deve ser informada.");
            });
    }
}