using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoIdQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasPorQuestaoIdQuery(long questaoId)
    {
        QuestaoId = questaoId;
    }

    public long QuestaoId { get; }
}