using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioQuestaoGradeCurricular : IRepositorioBase<QuestaoGradeCurricular>
    {
        Task<IEnumerable<QuestaoGradeCurricular>> ObterListaQuestaoGradesCurriculares(long questaoId);
    }

}
