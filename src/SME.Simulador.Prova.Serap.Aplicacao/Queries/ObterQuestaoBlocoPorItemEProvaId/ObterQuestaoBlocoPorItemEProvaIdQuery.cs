using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoBlocoPorItemEProvaIdQuery : IRequest<BlocoItemDto>
{
    public ObterQuestaoBlocoPorItemEProvaIdQuery(long provaId, long itemId)
    {
        ProvaId = provaId;
        ItemId = itemId;
    }

    public long ProvaId { get; }
    public long ItemId { get; }
}