using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioArquivo
{
    Task<IEnumerable<ArquivoDto>> ObterAudiosPorQuestaoIdAsync(long questaoId);
    Task<IEnumerable<VideoDto>> ObterVideosPorQuestaoIdAsync(long questaoId);
}