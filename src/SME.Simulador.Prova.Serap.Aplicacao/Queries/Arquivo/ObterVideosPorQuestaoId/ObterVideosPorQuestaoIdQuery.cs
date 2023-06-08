using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterVideosPorQuestaoIdQuery : IRequest<IEnumerable<VideoDto>>
{
    public ObterVideosPorQuestaoIdQuery(long questaoId)
    {
        QuestaoId = questaoId;
    }

    public long QuestaoId { get; }
}