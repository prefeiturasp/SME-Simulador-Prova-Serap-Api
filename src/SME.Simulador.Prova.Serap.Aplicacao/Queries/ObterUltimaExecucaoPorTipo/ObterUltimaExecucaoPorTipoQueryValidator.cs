using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterUltimaExecucaoPorTipoQueryValidator : AbstractValidator<ObterUltimaExecucaoPorTipoQuery>
{
    public ObterUltimaExecucaoPorTipoQueryValidator()
    {
        RuleFor(c => c.ExecucaoTipo)
            .IsInEnum()
            .WithMessage("Informe um tipo de execução válido.");
    }
}