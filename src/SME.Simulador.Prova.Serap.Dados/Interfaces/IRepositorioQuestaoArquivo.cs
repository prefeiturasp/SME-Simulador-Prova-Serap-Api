using SME.Simulador.Prova.Serap.Dominio;


namespace SME.Simulador.Prova.Serap.Dados.Interfaces
{
    public interface IRepositorioQuestaoArquivo : IRepositorioBase<QuestaoArquivo>
    {
        Task<IEnumerable<QuestaoArquivo>> ObterListaQuestaoArquivos(long questaoId);
    }
}
