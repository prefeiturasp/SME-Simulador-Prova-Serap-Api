using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestoesBlocosPorItemEProvaIdQueryHandler : IRequestHandler<ObterQuestoesBlocosPorItemEProvaIdQuery, IEnumerable<BlocoItemDto>>
{
    private readonly IRepositorioBlocoQuestao repositorioBlocos;
    
    public ObterQuestoesBlocosPorItemEProvaIdQueryHandler(IRepositorioBlocoQuestao repositorioBlocos)
    {
        this.repositorioBlocos = repositorioBlocos ?? throw new ArgumentNullException(nameof(repositorioBlocos));
    }
    
    public async Task<IEnumerable<BlocoItemDto>> Handle(ObterQuestoesBlocosPorItemEProvaIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioBlocos.ObterQuestoesBlocosPorItemEProvaId(request.ProvaId, request.ItemId);
    }
}