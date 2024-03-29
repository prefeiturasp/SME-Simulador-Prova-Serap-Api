﻿using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterListaQuestaoGradesCurricularesQueryValidator : AbstractValidator<ObterListaQuestaoGradesCurricularesQuery>
{
    public ObterListaQuestaoGradesCurricularesQueryValidator()
    {
        RuleFor(c => c.QuestaoId)
            .GreaterThan(0)
            .WithMessage("O Id da questao deve ser informado.");
    }
}