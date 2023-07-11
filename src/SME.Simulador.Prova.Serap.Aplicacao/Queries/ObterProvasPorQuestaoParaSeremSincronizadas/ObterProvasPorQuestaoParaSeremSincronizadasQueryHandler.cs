using MediatR;
using SME.Simulador.Prova.Serap.Dados;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoParaSeremSincronizadasQueryHandler : IRequestHandler<ObterProvasPorQuestaoParaSeremSincronizadasQuery, IEnumerable<ProvaLegadoDto>>
{
    private readonly IRepositorioProvaLegado repositorioProvaLegado;

    public ObterProvasPorQuestaoParaSeremSincronizadasQueryHandler(IRepositorioProvaLegado repositorioProvaLegado)
    {
        this.repositorioProvaLegado = repositorioProvaLegado ?? throw new ArgumentNullException(nameof(repositorioProvaLegado));
    }

    public async Task<IEnumerable<ProvaLegadoDto>> Handle(ObterProvasPorQuestaoParaSeremSincronizadasQuery request, CancellationToken cancellationToken)
    {
        return await repositorioProvaLegado.ObterProvasPorQuestaoParaSeremSincronizadasAsync(request.Filtro);
    }
}