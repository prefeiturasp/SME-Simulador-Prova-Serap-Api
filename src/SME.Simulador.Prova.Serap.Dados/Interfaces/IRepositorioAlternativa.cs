using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioAlternativa
{
    Task<IEnumerable<AlternativaDto>> ObterAlternativasPorQuestaoIdAsync(long questaoId);
}