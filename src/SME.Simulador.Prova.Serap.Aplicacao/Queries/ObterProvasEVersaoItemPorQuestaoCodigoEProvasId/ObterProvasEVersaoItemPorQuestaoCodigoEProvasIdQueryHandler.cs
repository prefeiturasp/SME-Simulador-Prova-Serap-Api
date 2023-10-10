using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQueryHandler : IRequestHandler<ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery, IEnumerable<ProvaLegadoDto>>
{
    private readonly IRepositorioProvaLegado repositorioProvaLegado;

    public ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQueryHandler(IRepositorioProvaLegado repositorioProvaLegado)
    {
        this.repositorioProvaLegado = repositorioProvaLegado ?? throw new ArgumentNullException(nameof(repositorioProvaLegado));
    }

    public async Task<IEnumerable<ProvaLegadoDto>> Handle(ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProvaLegado.ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdAsync(request.QuestaoCodigo, request.ProvasId);
    }
}