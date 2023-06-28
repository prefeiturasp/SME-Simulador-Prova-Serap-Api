using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioArquivo
{
    Task<IEnumerable<ArquivoDto>> ObterAudiosPorQuestaoId(long questaoId);
    Task<IEnumerable<VideoDto>> ObterVideosPorQuestaoId(long questaoId);
}