using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioQuestao
{
    Task<QuestaoSerapDto> ObterQuestaoCadernoProva(long questaoId, long cadernoId);
    Task<IEnumerable<QuestaoResumoDto>> ObterQuestoesResumoPorCadernoId(long cadernoId);
}