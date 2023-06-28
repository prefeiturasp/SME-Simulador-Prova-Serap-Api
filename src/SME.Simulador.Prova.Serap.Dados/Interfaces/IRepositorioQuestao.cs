using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioQuestao
{
    Task<QuestaoSerapDto> ObterQuestaoCadernoProvaAsync(long questaoId, long cadernoId);
    Task<IEnumerable<QuestaoResumoDto>> ObterQuestoesResumoPorCadernoIdAsync(long cadernoId);
}