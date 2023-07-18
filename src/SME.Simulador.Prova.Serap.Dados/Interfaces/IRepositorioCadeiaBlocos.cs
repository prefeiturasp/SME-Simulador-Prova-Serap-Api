using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioCadeiaBlocos : IRepositorioBase<CadeiaBlocoQuestao>
{
    Task<CadeiaBlocoQuestaoDto?> ObterBlocoIdPorItemEProvaId(long provaId, long itemId);
}