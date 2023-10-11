using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesBlocosPorItemEProvaIdQuery : IRequest<IEnumerable<BlocoItemDto>>
{
    public ObterQuestoesBlocosPorItemEProvaIdQuery(long provaId, long itemId)
    {
        ProvaId = provaId;
        ItemId = itemId;
    }

    public long ProvaId { get; }
    public long ItemId { get; }
}