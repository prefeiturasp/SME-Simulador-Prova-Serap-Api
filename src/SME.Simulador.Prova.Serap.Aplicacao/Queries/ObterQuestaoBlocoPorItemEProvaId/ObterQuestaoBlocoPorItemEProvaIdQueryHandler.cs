using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterQuestaoBlocoPorItemEProvaIdQueryHandler : IRequestHandler<ObterQuestaoBlocoPorItemEProvaIdQuery, BlocoItemDto>
{
    private readonly IRepositorioBlocoQuestao repositorioBlocos;
    
    public ObterQuestaoBlocoPorItemEProvaIdQueryHandler(IRepositorioBlocoQuestao repositorioBlocos)
    {
        this.repositorioBlocos = repositorioBlocos ?? throw new ArgumentNullException(nameof(repositorioBlocos));
    }
    
    public async Task<BlocoItemDto> Handle(ObterQuestaoBlocoPorItemEProvaIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioBlocos.ObterBlocoIdPorItemEProvaId(request.ProvaId, request.ItemId);
    }
}