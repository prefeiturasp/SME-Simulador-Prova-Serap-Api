using FluentValidation;

namespace SME.Simulador.Prova.Serap.Aplicacao
{
    public class GerarNovaVersaoQuestaoCommandValidator : AbstractValidator<GerarNovaVersaoQuestaoCommand>
    { 
        public GerarNovaVersaoQuestaoCommandValidator()
        { 
            RuleFor(c => c.Questao.CodigoItem)
            .NotEmpty()
            .NotNull()
            .WithMessage("O Codigo Item deve ser informado e não pode ser vazio.");

            RuleFor(c => c.Questao.VersaoItem)
            .NotNull()
            .WithMessage("A Versão do item deve ser informado.");

            RuleFor(c => c.Questao.MatrizId)
            .GreaterThan(0)
            .NotNull()
            .WithMessage("A MatrizId deve ser informada e ser maior que zero.");
        
            RuleFor(c => c.Questao.SituacaoItemId)
            .NotNull()
            .WithMessage("A SituacaoItemId deve ser informado.");

            RuleFor(c => c.Questao.TipoItem)
            .NotNull()
            .WithMessage("A TipoItem deve ser informado.");

            RuleFor(c => c.Questao.EhRestrito)
            .NotNull()
            .WithMessage("A EhRestrito deve ser informado.");

            RuleFor(c => c.Questao.VersaoCodigoQuestao)
            .NotNull()
            .WithMessage("A VersaoCodigoQuestao deve ser informado.");

            RuleFor(c => c.Questao.DataCriacao)
            .NotNull()
            .WithMessage("A DataCriacao deve ser informada.");

            RuleFor(c => c.Questao.DataAtualizacao)
            .NotNull()
            .WithMessage("A DataAtualizacao deve ser informada.");

            RuleFor(c => c.Questao.Situacao)
            .NotNull()
            .WithMessage("A Situacao deve ser informada.");
        }
    }
}
