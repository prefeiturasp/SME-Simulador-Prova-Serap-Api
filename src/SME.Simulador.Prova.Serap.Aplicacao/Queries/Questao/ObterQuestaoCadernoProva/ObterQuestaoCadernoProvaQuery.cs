using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoCadernoProvaQuery : IRequest<QuestaoSerapDto>
{
    public ObterQuestaoCadernoProvaQuery(long questaoId, long cadernoId)
    {
        QuestaoId = questaoId;
        CadernoId = cadernoId;
    }

    public long QuestaoId { get; }
    public long CadernoId { get; }
}