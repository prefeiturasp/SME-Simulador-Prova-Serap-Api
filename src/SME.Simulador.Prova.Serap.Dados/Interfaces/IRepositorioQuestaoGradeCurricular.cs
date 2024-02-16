using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados;

public interface IRepositorioQuestaoGradeCurricular : IRepositorioBase<QuestaoGradeCurricular>
{
    Task<IEnumerable<QuestaoGradeCurricular>> ObterListaQuestaoGradesCurriculares(long questaoId);
}