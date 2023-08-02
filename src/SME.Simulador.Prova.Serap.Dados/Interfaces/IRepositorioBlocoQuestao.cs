using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioBlocoQuestao 
{
    Task<BlocoItemDto?> ObterBlocoIdPorItemEProvaId(long provaId, long itemId);
    Task<long> SalvarAsync(QuestaoBloco entidade);
}