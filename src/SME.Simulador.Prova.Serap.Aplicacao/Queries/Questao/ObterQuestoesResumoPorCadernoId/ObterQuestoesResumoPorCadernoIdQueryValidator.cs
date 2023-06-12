using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesResumoPorCadernoIdQueryValidator : AbstractValidator<ObterQuestoesResumoPorCadernoIdQuery>
{
    public ObterQuestoesResumoPorCadernoIdQueryValidator()
    {
        RuleFor(c => c.CadernoId)
            .GreaterThan(0)
            .WithMessage("O Id do caderno deve ser informado.");
    }
}