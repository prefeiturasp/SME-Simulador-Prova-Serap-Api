using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProvaLegado
{
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoIdAsync(long questaoId);
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoParaSeremSincronizadasAsync(FiltroProvasParaSeremSincronizadasDto filtro);
    Task<bool> EhProvaIniciadaAsync(long provaId);
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasNaoIniciadasPorQuestaoIdAsync(long questaoId);
    Task<bool> EhProvaBib(long provaId);
}