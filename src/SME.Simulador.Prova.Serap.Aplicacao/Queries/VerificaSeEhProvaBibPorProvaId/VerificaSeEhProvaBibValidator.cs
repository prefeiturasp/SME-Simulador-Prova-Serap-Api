using FluentValidation;
using SME.Simulador.Prova.Serap.Aplicacao.Queries.Questao.ObterQuestaoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.Simulador.Prova.Serap.Aplicacao.Queries.VerificaSeEhProvaBibPorProvaId
{
    public class VerificaSeEhProvaBibValidator : AbstractValidator<VerificaSeEhProvaBibQuery>
    {
        public VerificaSeEhProvaBibValidator()
        {
            RuleFor(c => c.ProvaId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id da prova deve ser informado.");
        }
    }
}
