using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoCadernoProvaQuery : IRequest<QuestaoSerapDto>
{
    public ObterQuestaoCadernoProvaQuery(long questaoId, long provaId, string? caderno)
    {
        QuestaoId = questaoId;
        ProvaId = provaId;
        Caderno = caderno;
    }

    public long QuestaoId { get; }
    public long ProvaId { get; }
    public string? Caderno { get; }
}