using SME.Simulador.Prova.Serap.Dominio;
using SME.Simulador.Prova.Serap.Infra;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioAlternativa : IRepositorioBase<Alternativa>
{
    Task<IEnumerable<AlternativaDto>> ObterAlternativasPorQuestaoIdAsync(long questaoId);
}