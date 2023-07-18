using SME.Simulador.Prova.Serap.Dominio;

namespace SME.Simulador.Prova.Serap.Dados.Repositorios;

public class RepositorioQuestaoHabilidade : RepositorioGestaoAvaliacaoBase<QuestaoHabilidade>, IRepositorioQuestaoHabilidade
{
    private readonly GestaoAvaliacaoContexto gestaoAvaliacaoContexto;

    public RepositorioQuestaoHabilidade(GestaoAvaliacaoContexto gestaoAvaliacaoContexto) : base(gestaoAvaliacaoContexto)
    {
        this.gestaoAvaliacaoContexto = gestaoAvaliacaoContexto ?? throw new ArgumentNullException(nameof(gestaoAvaliacaoContexto));
    }  
     
    public async Task<IEnumerable<QuestaoHabilidade>> ObterListaQuestoesHabilidades(long questaoId)
    {
        const string query = @"SELECT [Id]
                                         ,[OriginalSkill] as HabilidadeOriginal
                                         ,[CreateDate] as DataCriacao
                                         ,[UpdateDate] as DataAtualizacao
                                         ,[State] as Situacao
                                         ,[Item_Id] as QuestaoId
                                         ,[Skill_Id] as HabilidadeId
                                     FROM [GestaoAvaliacao].[dbo].[ItemSkill]
                                     WHERE Item_id = @questaoId
                                       AND State = @state";

        return await gestaoAvaliacaoContexto.Conexao.QueryAsync<QuestaoHabilidade>(query,
            new
            {
                questaoId,
                state = (int)LegadoState.Ativo
            }, transaction: gestaoAvaliacaoContexto.Transacao);
    }
}