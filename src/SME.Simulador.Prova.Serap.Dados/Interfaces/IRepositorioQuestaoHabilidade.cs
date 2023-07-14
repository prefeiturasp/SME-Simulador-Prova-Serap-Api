using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioQuestaoHabilidade : IRepositorioBase<QuestaoHabilidade>
    {
        Task<IEnumerable<QuestaoHabilidade>> ObterListaQuestoesHabilidades(long questaoId);
    }
}
