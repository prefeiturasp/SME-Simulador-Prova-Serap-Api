using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioProvaLegado
{
    Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoIdAsync(long questaoId);

    Task<IEnumerable<ProvaLegadoDto>> ObterProvasPorQuestaoParaSeremSincronizadasAsync(FiltroProvasParaSeremSincronizadasDto filtro);
    
    Task<bool> EhProvaIniciada(long provaId);
}