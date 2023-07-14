using SME.Simulador.Prova.Serap.Dominio;


namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioQuestaoAudio : IRepositorioBase<QuestaoAudio>
    {
        Task<IEnumerable<QuestaoAudio>> ObterListaQuestaoAudio(long questaoId);
    }
}
