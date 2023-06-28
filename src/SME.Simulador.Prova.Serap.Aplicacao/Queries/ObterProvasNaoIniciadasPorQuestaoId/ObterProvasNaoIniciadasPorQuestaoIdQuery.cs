using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasNaoIniciadasPorQuestaoIdQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasNaoIniciadasPorQuestaoIdQuery(long questaoId)
    {
        QuestaoId = questaoId;
    }

    public long QuestaoId { get; }
}