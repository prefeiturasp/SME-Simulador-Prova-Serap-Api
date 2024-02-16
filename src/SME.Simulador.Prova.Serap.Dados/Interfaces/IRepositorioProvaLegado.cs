using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProvaLegado
{
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasEVersaoItemPorQuestaoCodigoEProvasIdAsync(string questaoCodigo, long[] provasId);
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoParaSeremSincronizadasAsync(FiltroProvasParaSeremSincronizadasDto filtro);
    Task<bool> EhProvaIniciadaAsync(long provaId);
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasNaoIniciadasPorQuestaoIdAsync(string questaoCodigo);
    Task<bool> EhProvaBib(long provaId);
}