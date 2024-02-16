using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoParaSeremSincronizadasENaoForamIniciadasQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasPorQuestaoParaSeremSincronizadasENaoForamIniciadasQuery(FiltroProvasParaSeremSincronizadasDto filtro)
    {
        Filtro = filtro;
    }

    public FiltroProvasParaSeremSincronizadasDto Filtro { get; }
}