using MediatR;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Aplicacao;

public class ObterProvasPorQuestaoParaSeremSincronizadasQuery : IRequest<IEnumerable<ProvaLegadoDto>>
{
    public ObterProvasPorQuestaoParaSeremSincronizadasQuery(FiltroProvasParaSeremSincronizadasDto filtro)
    {
        Filtro = filtro;
    }

    public FiltroProvasParaSeremSincronizadasDto Filtro { get; }
}