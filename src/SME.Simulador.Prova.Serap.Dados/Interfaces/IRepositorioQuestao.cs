using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioQuestao : IRepositorioBase<Questao>
{
    Task<QuestaoSerapDto> ObterQuestaoCadernoProvaAsync(long questaoId, long cadernoId);
    Task<IEnumerable<QuestaoResumoDto>> ObterQuestoesResumoPorCadernoIdAsync(long cadernoId);

    Task<Questao> ObterPorIdAsync(long id);

    Task<long> SalvarAsync(Questao entidade);
}