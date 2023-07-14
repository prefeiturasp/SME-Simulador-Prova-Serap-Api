using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioCadeiaBlocos : IRepositorioBase<CadeiaBlocoQuestao>
    {
        Task<CadeiaBlocoQuestaoDto?> ObterBlocoIdPorItemEhProvaId(long provaId, long itemId);
    }
}
