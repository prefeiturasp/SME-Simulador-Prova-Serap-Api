using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioBlocoQuestao 
{
    Task<IEnumerable<BlocoItemDto>> ObterQuestoesBlocosPorItemEProvaId(long provaId, long itemId);
    Task<long> SalvarAsync(QuestaoBloco entidade);
}