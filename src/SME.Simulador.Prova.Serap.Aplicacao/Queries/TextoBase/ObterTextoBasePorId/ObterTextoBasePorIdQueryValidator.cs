using FluentValidation;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class ObterTextoBasePorIdQueryValidator : AbstractValidator<ObterTextoBasePorIdQuery>
    {
        public ObterTextoBasePorIdQueryValidator()
        {
            RuleFor(c => c.TextoBaseId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id do Texto Base deve ser informado.");
        }
    }
}