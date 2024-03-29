﻿using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterListaQuestaoArquivoPorQuestaoIdQueryValidator : AbstractValidator<ObterListaQuestaoArquivoPorQuestaoIdQuery>
{
    public ObterListaQuestaoArquivoPorQuestaoIdQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .GreaterThan(0)
            .WithMessage("O Id da questao deve ser informado.");
    }
}