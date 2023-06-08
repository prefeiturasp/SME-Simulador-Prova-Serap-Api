using SME.Simulador.Prova.Serap.Infra.Dtos;

namespace SME.Simulador.Prova.Serap.Dados
{
    public interface IRepositorioAlternativa
    {
        Task<IEnumerable<AlternativaDto>> ObterAlternativasPorQuestaoId(long questaoId);
    }
}
