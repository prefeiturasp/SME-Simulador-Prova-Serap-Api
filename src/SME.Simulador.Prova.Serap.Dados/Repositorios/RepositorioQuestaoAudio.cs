using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios;

public class RepositorioQuestaoAudio : RepositorioGestaoAvaliacaoBase<QuestaoAudio>, IRepositorioQuestaoAudio
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioQuestaoAudio(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }

    public async Task<IEnumerable<QuestaoAudio>> ObterListaQuestaoAudio(long questaoId)
    {
        const string query = @"  SELECT [Id]
                                           ,[CreateDate] as  DataCriacao
                                           ,[UpdateDate] as DataAtualizacao
                                           ,[State]      as Situacao
                                           ,[File_Id]    as ArquivoId
                                           ,[Item_Id]    as  QuestaoId
                                       FROM [GestaoAvaliacao].[dbo].[ItemAudio]
                                     WHERE Item_id = @questaoId
                                       AND State = @state";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<QuestaoAudio>(query,
            new
            {
                questaoId,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }
}